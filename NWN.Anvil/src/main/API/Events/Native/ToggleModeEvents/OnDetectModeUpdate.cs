using System;
using System.Runtime.InteropServices;
using Anvil.API.Events;
using Anvil.Services;
using NWN.Native.API;

namespace Anvil.API.Events
{
  public sealed class OnDetectModeUpdate : IEvent
  {
    public NwCreature Creature { get; private init; } = null!;

    public ToggleModeEventType EventType { get; private init; }

    /// <summary>
    /// Gets or sets a value indicating whether this creature should be prevented from entering/exiting detect mode.
    /// </summary>
    public bool Prevent { get; set; }

    NwObject IEvent.Context => Creature;

    public sealed unsafe class Factory : HookEventFactory
    {
      private static FunctionHook<SetDetectModeHook> Hook { get; set; } = null!;

      private delegate void SetDetectModeHook(void* pCreature, byte nDetectMode);

      protected override IDisposable[] RequestHooks()
      {
        delegate* unmanaged<void*, byte, void> pHook = &OnSetDetectMode;
        Hook = HookService.RequestHook<SetDetectModeHook>(pHook, FunctionsLinux._ZN12CNWSCreature13SetDetectModeEh, HookOrder.Early);
        return new IDisposable[] { Hook };
      }

      private static void HandleEnter(CNWSCreature creature, byte nDetectMode)
      {
        OnDetectModeUpdate eventData = ProcessEvent(EventCallbackType.Before, new OnDetectModeUpdate
        {
          Creature = creature.ToNwObject<NwCreature>()!,
          EventType = ToggleModeEventType.Enter,
        });

        if (!eventData.Prevent)
        {
          Hook.CallOriginal(creature, nDetectMode);
        }
        else
        {
          creature.ClearActivities(0);
        }

        ProcessEvent(EventCallbackType.After, eventData);
      }

      private static void HandleExit(CNWSCreature creature, byte nDetectMode)
      {
        OnDetectModeUpdate eventData = ProcessEvent(EventCallbackType.Before, new OnDetectModeUpdate
        {
          Creature = creature.ToNwObject<NwCreature>()!,
          EventType = ToggleModeEventType.Exit,
        });

        if (!eventData.Prevent)
        {
          Hook.CallOriginal(creature, nDetectMode);
        }
        else
        {
          creature.SetActivity(0, true.ToInt());
        }

        ProcessEvent(EventCallbackType.After, eventData);
      }

      [UnmanagedCallersOnly]
      private static void OnSetDetectMode(void* pCreature, byte nDetectMode)
      {
        CNWSCreature creature = CNWSCreature.FromPointer(pCreature);

        bool willBeDetecting = nDetectMode != 0;
        bool currentlyDetecting = creature.m_nDetectMode != 0;

        if (!currentlyDetecting && willBeDetecting)
        {
          HandleEnter(creature, nDetectMode);
        }
        else if (currentlyDetecting && !willBeDetecting)
        {
          HandleExit(creature, nDetectMode);
        }
        else
        {
          Hook.CallOriginal(pCreature, nDetectMode);
        }
      }
    }
  }
}

namespace Anvil.API
{
  public sealed partial class NwCreature
  {
    /// <inheritdoc cref="Events.OnDetectModeUpdate"/>
    public event Action<OnDetectModeUpdate> OnDetectModeUpdate
    {
      add => EventService.Subscribe<OnDetectModeUpdate, OnDetectModeUpdate.Factory>(this, value);
      remove => EventService.Unsubscribe<OnDetectModeUpdate, OnDetectModeUpdate.Factory>(this, value);
    }
  }

  public sealed partial class NwModule
  {
    /// <inheritdoc cref="Events.OnDetectModeUpdate"/>
    public event Action<OnDetectModeUpdate> OnDetectModeUpdate
    {
      add => EventService.SubscribeAll<OnDetectModeUpdate, OnDetectModeUpdate.Factory>(value);
      remove => EventService.UnsubscribeAll<OnDetectModeUpdate, OnDetectModeUpdate.Factory>(value);
    }
  }
}
