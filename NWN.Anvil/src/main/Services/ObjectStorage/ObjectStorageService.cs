using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Anvil.API;
using NLog;
using NWN.Native.API;

namespace Anvil.Services
{
  [ServiceBinding(typeof(ObjectStorageService))]
  public sealed unsafe class ObjectStorageService
  {
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    private static readonly byte* AnvilGffFieldNamePtr = "ANVIL_POS".GetNullTerminatedString();
    private static readonly byte* NWNXGffFieldNamePtr = "NWNX_POS".GetNullTerminatedString();

    private readonly FunctionHook<AreaDestructorHook> areaDestructorHook;
    private readonly FunctionHook<DropTURDHook> dropTURDHook;
    private readonly FunctionHook<EatTURDHook> eatTURDHook;
    private readonly FunctionHook<LoadFromGffHook> loadFromGffHook;
    private readonly FunctionHook<ObjectDestructorHook> objectDestructorHook;
    private readonly Dictionary<IntPtr, ObjectStorage> objectStorage = new Dictionary<IntPtr, ObjectStorage>();
    private readonly FunctionHook<SaveToGffHook> saveToGffHook;

    public ObjectStorageService(HookService hookService)
    {
      objectDestructorHook = hookService.RequestHook<ObjectDestructorHook>(OnObjectDestructor, FunctionsLinux._ZN10CNWSObjectD1Ev, HookOrder.VeryEarly);
      areaDestructorHook = hookService.RequestHook<AreaDestructorHook>(OnAreaDestructor, FunctionsLinux._ZN8CNWSAreaD1Ev, HookOrder.VeryEarly);
      eatTURDHook = hookService.RequestHook<EatTURDHook>(OnEatTURD, FunctionsLinux._ZN10CNWSPlayer7EatTURDEP14CNWSPlayerTURD, HookOrder.VeryEarly);
      dropTURDHook = hookService.RequestHook<DropTURDHook>(OnDropTURD, FunctionsLinux._ZN10CNWSPlayer8DropTURDEv, HookOrder.VeryEarly);
      saveToGffHook = hookService.RequestHook<SaveToGffHook>(OnSaveToGff, FunctionsLinux._ZN8CNWSUUID9SaveToGffEP7CResGFFP10CResStruct, HookOrder.VeryEarly);
      loadFromGffHook = hookService.RequestHook<LoadFromGffHook>(OnLoadFromGff, FunctionsLinux._ZN8CNWSUUID11LoadFromGffEP7CResGFFP10CResStruct, HookOrder.VeryEarly);
    }

    private delegate void AreaDestructorHook(void* pArea);

    private delegate void DropTURDHook(void* pPlayer);

    private delegate void EatTURDHook(void* pPlayer, void* pTURD);

    private delegate int LoadFromGffHook(void* pUUID, void* pRes, void* pStruct);

    private delegate void ObjectDestructorHook(void* pObject);

    private delegate void SaveToGffHook(void* pUUID, void* pRes, void* pStruct);

    public void DestroyObjectStorage(NwObject gameObject)
    {
      DestroyObjectStorage(gameObject.Object);
    }

    public void DestroyObjectStorage(ICGameObject gameObject)
    {
      objectStorage.Remove(gameObject.Pointer);
    }

    public ObjectStorage GetObjectStorage(NwObject gameObject)
    {
      return GetObjectStorage(gameObject.Object);
    }

    public ObjectStorage GetObjectStorage(ICGameObject gameObject)
    {
      if (!objectStorage.TryGetValue(gameObject.Pointer, out ObjectStorage? storage))
      {
        storage = new ObjectStorage();
        objectStorage[gameObject.Pointer] = storage;
      }

      return storage;
    }

    public bool TryGetObjectStorage(NwObject gameObject, [NotNullWhen(true)] out ObjectStorage? storage)
    {
      return TryGetObjectStorage(gameObject.Object, out storage);
    }

    public bool TryGetObjectStorage(ICGameObject gameObject, [NotNullWhen(true)] out ObjectStorage? storage)
    {
      return objectStorage.TryGetValue(gameObject.Pointer, out storage);
    }

    private void OnAreaDestructor(void* pArea)
    {
      CNWSArea area = CNWSArea.FromPointer(pArea);
      areaDestructorHook.CallOriginal(pArea);
      DestroyObjectStorage(area);
    }

    private void OnDropTURD(void* pPlayer)
    {
      dropTURDHook.CallOriginal(pPlayer);

      // Be very, very paranoid. Bad things happen when the TURD list doesn't exist
      // This can happen when you BootPC() the very first PC to connect to your sever
      //     https://github.com/nwnxee/unified/issues/319
      CExoLinkedListInternal turdList = NwModule.Instance.Module.m_lstTURDList.m_pcExoLinkedListInternal;
      CExoLinkedListNode pHead;

      if (turdList != null && (pHead = turdList.pHead) != null && pHead.pObject != null)
      {
        CNWSPlayer player = CNWSPlayer.FromPointer(pPlayer);
        CNWSPlayerTURD turd = CNWSPlayerTURD.FromPointer(pHead.pObject);

        ICGameObject? playerObj = player.m_oidNWSObject.ToNwObject()?.Object;
        if (playerObj != null)
        {
          objectStorage[turd.Pointer] = GetObjectStorage(playerObj).Clone();
        }
      }
    }

    private void OnEatTURD(void* pPlayer, void* pTURD)
    {
      CNWSPlayer player = CNWSPlayer.FromPointer(pPlayer);
      CNWSPlayerTURD turd = CNWSPlayerTURD.FromPointer(pTURD);

      ICGameObject? playerObj = player.m_oidNWSObject.ToNwObject()?.Object;
      if (playerObj != null)
      {
        objectStorage[playerObj.Pointer] = GetObjectStorage(turd).Clone();
      }

      eatTURDHook.CallOriginal(pPlayer, pTURD);
    }

    private int OnLoadFromGff(void* pUUID, void* pRes, void* pStruct)
    {
      CNWSUUID uuid = CNWSUUID.FromPointer(pUUID);
      CResGFF resGff = CResGFF.FromPointer(pRes);
      CResStruct resStruct = CResStruct.FromPointer(pStruct);

      bool hasAnvilPos = resGff.TryReadCExoString(resStruct, AnvilGffFieldNamePtr, out CExoString anvilSerialized);
      bool hasNwnxPos = resGff.TryReadCExoString(resStruct, NWNXGffFieldNamePtr, out CExoString nwnxSerialized);

      if (!hasAnvilPos && !hasNwnxPos)
      {
        return loadFromGffHook.CallOriginal(pUUID, pRes, pStruct);
      }

      ObjectStorage storage = GetObjectStorage(uuid.m_parent);
      storage.Clear();

      if (hasNwnxPos)
      {
        try
        {
          storage.Deserialize(nwnxSerialized.ToString());
        }
        catch (Exception e)
        {
          Log.Error(e, "Failed to import NWNX object storage");
        }
      }

      if (hasAnvilPos)
      {
        try
        {
          storage.Deserialize(anvilSerialized.ToString());
        }
        catch (Exception e)
        {
          Log.Error(e, "Failed to load Anvil object storage");
        }
      }

      return loadFromGffHook.CallOriginal(pUUID, pRes, pStruct);
    }

    private void OnObjectDestructor(void* pObject)
    {
      CNWSObject gameObject = CNWSObject.FromPointer(pObject);
      objectDestructorHook.CallOriginal(pObject);
      DestroyObjectStorage(gameObject);
    }

    private void OnSaveToGff(void* pUUID, void* pRes, void* pStruct)
    {
      CNWSUUID uuid = CNWSUUID.FromPointer(pUUID);
      CResGFF resGff = CResGFF.FromPointer(pRes);
      CResStruct resStruct = CResStruct.FromPointer(pStruct);

      string? serialized = GetObjectStorage(uuid.m_parent).Serialize();
      resGff.WriteFieldCExoString(resStruct, serialized.ToExoString(), AnvilGffFieldNamePtr);

      saveToGffHook.CallOriginal(pUUID, pRes, pStruct);
    }
  }
}
