# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## Unreleased
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.23...HEAD

### Added
- Implemented AI message and listen system.
  - NwGameObject: Added `IsListening` property.
  - NwGameObject: Added `SetListenPattern` method.
  - NwCreature: Added `SetAssociateListenPatterns` method.
  - OnConversation events: Added `ListenPattern`, `AssociateCommand` properties.
- OnTrapTriggered: Added `TriggeredBy` property to door/placeable traps.
- CreatureClassInfo: Added `Domains` array for reading/modifying creature domains.

### Package Updates
- NWN.Core: 8193.34.10 -> 8193.34.12

### Changed
- N/A

### Deprecated
- `DoorEvents.OnDialogue` - use `DoorEvents.OnConversation` instead.
- `PlaceableEvents.OnDialogue` - use `PlaceableEvents.OnConversation` instead.

### Removed
- N/A

### Fixed
- Fixed an issue with events that caused script handlers not to be called after reloading anvil.

## 8193.34.23
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.22...v8193.34.23

### Added
- Added `ANVIL_ENCODING` environment variable for specifying a custom encoding when converting native strings from nwserver.
- Added `EncodingService` for changing the server encoding at runtime.
- NUI: Added StrRef support with `NuiBindStrRef` and `NuiValueStrRef` types.
- Events: Added `OnDoorSetOpenState` event.
- Events: Added `OnObjectUse` event.
- Extensions: Added `TryParseObject` extension for parsing object ID strings.
- NwCreature: Added `GetInitiativeModifier`,`SetInitiativeModifier`,`ClearInitiativeModifier` methods.
- NwCreature: Added `IsDMAvatar` property.
- NwCreature: Added `IsFlanking` method.
- NwDoor: Added `DoorOpenState` property.
- NwRuleset: Added NwDomain ruleset table and replaced constant usages with table references.
- NwServer: Added `IsActivePaused` property.
- NwServer: Added `IsTimestopPaused` property.

### Package Updates
- Microsoft.CodeAnalysis.CSharp: 4.3.1 -> 4.4.0
- NWN.Core: 8193.34.7 -> 8193.34.10
- NWN.Native: 8193.34.4 -> 8193.34.5
- LightInject: 6.6.1 -> 6.6.3
- Newtonsoft.Json: 13.0.1 -> 13.0.2
- NLog: 5.0.5 -> 5.1.1
- Paket.Core: 7.1.5 -> 7.2.0
- NWNX: fe195ec -> 2692ecb

### Changed
- Events: `OnSpellAction` Domain and Feat is now nullable.
- Events: `OnSpellInterrupt` Domain and Feat is now nullable.
- Events: `OnSpellSlotMemorize` Domain is now nullable.
- `System.Random` usages now use the `System.Random.Shared` instance, instead of individual instances.

### Fixed
- Fixed an issue where a GameObject or Player could become stuck in a hash-based collection when it became invalid.
- NwPlayer: `IsDM` now correctly returns true when a DM is possessing a creature. Use `ControlledCreature.IsDM` for the prior behaviour.

## 8193.34.22
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.21...v8193.34.22

### Package Updates
- NLog: 5.0.4 -> 5.0.5

### Changed
- OnSpellCast: Item, Spell and TargetObject can be null.
- NwItem: `Clone()` now preserves the item's `Droppable` flag. An optional parameter is provided to keep the old behaviour.

## 8193.34.21
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.20...v8193.34.21

### Added
- NwAreaOfEffect: Added `Radius` property.

### Package Updates
- NWNX: 8faa9d4 -> fe195ec

### Changed
- OnSpellCast: `Caster` and `TargetObject` now correctly use `NwObject` as the event data type.

### Fixed
- Fixed a server crash when a module or area attempted to cast a spell.
- Fixed an edge case where a deleted player's TURD would not be deleted.

## 8193.34.20
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.19...v8193.34.20

### Added
- CollectionExtensions: Added IList `AddRange` extension.
- NwCreature: Added `IsBartering` property.
- NwObject: Added `TryGetUUID` method.
- NwObject: Added `SerializeToJson` method.
- NwStore: Added `BuyStolenGoods`, `MarkDown`, `MarkDownStolen`, `MarkUp`, `WillNotBuyItems`, `WillOnlyBuyItems` properties.

### Package Updates
- LightInject: 6.5.1 -> 6.6.1

### Changed
- Exposed Json engine structure.

### Fixed
- VirtualMachine: Fixed an issue where ObjectSelf would not be correctly assigned.

## 8193.34.19
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.18...v8193.34.19

### Added
- Events: Added `OnLoadCharacterFinish` event.

## 8193.34.18
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.17...v8193.34.18

### Fixed
- Fix an InvalidOperationException being thrown when checking player for equality.

## 8193.34.17
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.16...v8193.34.17

### Added
- NwCreature: Added `SittingObject` property.
- NwArea: Added `LoadScreen` property.
- ResourceManager: Added `CreateResourceDirectory`.

### Fixed
- NwBaseItem: Fixed `ItemClass` returning a type name instead of the item class name.
- Fixed a rare compile issue when using `ToNwObject` caused by exposed native types.

## 8193.34.16
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.15...v8193.34.16

### Added
- Events: Added `OnDebugPlayVisualEffect`, `OnDebugRunScript`, `OnDebugRunScriptChunk` events.
- NwGameObject: Added `AnimationState`.
- Effect: Added `Effect.VisualEffect(VisualEffectTableEntry, bool, float, Vector3, Vector3)` overload.

### Package Updates
- NWN.Core 8193.34.6 -> 8193.34.7
- LightInject 6.4.1 -> 6.5.1
- NLog 5.0.1 -> 5.0.4
- NWNX 5ade7de -> 8faa9d4

### Changed
- SchedulerService: Use `PriorityQueue` to improve main server loop performance.

## 8193.34.15
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.14...v8193.34.15

### Added
- ItemProperty: Added `SubTypeTable`.

### Fixed
- Fixed `CalculateValidItemsForProperty` returning false for base items using column 0.

## 8193.34.14
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.13...v8193.34.14

### Added
- NuiText: Added `Border` and `Scrollbars` properties.
- ItemProperty: Added properties for referencing 2da data.
- ItemProperty: Added Create() factory method overload using the new table class types.
- NwGameTables: Added `ItemPropertyTable`, `ItemPropertyItemMapTable`, `ItemPropertyCostTables`, `ItemPropertyParamTables`

### Changed
- **BREAKING CHANGE:** TwoDimArrays must now be initialized via `NwGameTables.GetTable`.

### Fixed
- Fixed a server crash when using TwoDimArray after the native array structure was evicted from the 2da cache.
- Fixed updating the weight of a equipped item with `NwItem.Weight` not correctly updating creature weight and encumbrance.
- Fixed `NwBaseItem.ArmorCheckPenalty` returning an unsigned integer.

## 8193.34.13
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.12...v8193.34.13

### Package Updates
- NLog 5.0.0 -> 5.0.1
- NWN.Core 8193.34.5 -> 8193.34.6
- NWNX 95e700a -> 5ade7de

### Changed
- NUI: DrawList is now supported on all NUI elements, instead of just layout elements.
- NUI: NuiGroup now supports a non-layout element.

## 8193.34.12
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.11...v8193.34.12

### Added
- NwGameTables: Exposed armor (armor.2da) and parts (parts_*.2da) tables.

## 8193.34.11
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.10...v8193.34.11

### Added
- NwCreature: Added `GetSlotFromItem`
- NwCreature: Added `RunEquip(item, EquipmentSlots)`
- ItemAppearance: Added `ChangeAppearance`
- NuiWindowToken: Added `Get/SetUserData()`
- Effect: Added `SkillIncreaseAll`, `SkillDecreaseAll`

### Package Updates
- NWNX 4842f60 -> 95e700a
- NWN.Native 8193.34.3 -> 8193.34.4
- NWN.Core 8193.34.4 -> 8193.34.5
- NLog 4.7.15 -> 5.0.0

### Deprecated
- `ItemAppearanceArmorModel` enum. Use `CreaturePart` instead.
- `NwPlayer.NuiDestroy`. Use `NuiWindowToken.Close` instead.
- `NwPlayer.NuiGetUserData`. Use `NuiWindowToken.NuiGetUserData` instead.
- `NwPlayer.NuiSetUserData`. Use `NuiWindowToken.NuiSetUserData` instead.
- `NwPlayer.NuiGetWindowId`. Use `NuiWindowToken.NuiGetWindowId` instead.

### Fixed
- Fixed `NwGameObject.Location` setter not working for newly deserialized game objects.
- Fixed a crash when an equipped item was sent to limbo with `NwModule.MoveObjectToLimbo`.
- Fixed `NuiWindowToken.WindowId` returning an empty string from events.
- Speculative fix for a rare native crash when fetching 2da strings.

## 8193.34.10
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.9...v8193.34.10

### Added
- Added ClientVersion/ClientPlatform properties to OnClientConnect event.

### Package Updates
- NWNX 3227d60 -> 4842f60
- NWN.Core 8193.34.3 -> 8193.34.4

## 8193.34.9
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.8...v8193.34.9

### Added
- NwCreature - Added setters for base armor & shield arcane spell failure
- `NuiWindowToken` - small structure with helper methods for controlling NuiWindow instances. Can be created from `NwPlayer.TryCreateNuiWindow`
- NwCreature - Added getter for BaseAttackCount
- NwCreature - Added setter for ChallengeRating.

### Package Updates
- Paket 7.1.4 -> 7.1.5

### Changed
- `NwCreature.Position` will no-longer block the action queue from being modified.
  - This fixes inconsistencies with actions queued after setting the position, but the new position can sometimes not apply for players using drive mode.
  - For players, it is recommended to immobilize them before setting their position.

### Deprecated
- `NwPlayer.TryCreateNuiWindow` - use the `NuiWindowToken` overload instead.
- `NwPlayer.CreateNuiWindow` - use `TryCreateNuiWindow` instead.
- `ModuleEvents.OnNuiEvent.WindowToken` - use `ModuleEvents.OnNuiEvent.Token` instead.

### Fixed
- Fixed `NwGameObject.Location` setter re-triggering Area Enter events.
- Fixed `NwPlayer.PartyMembers` throwing a NRE when a party contained associate creatures.
- Fixed a typo in PlayOptions.OnePartyOnly.

## 8193.34.8
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.7...v8193.34.8

### Deprecated
- `NwObject.Destroy(float delay)` - Use the non-delay overload instead, with the `SchedulerService`.

### Fixed
- Fixed `NwEncounter.Destroy()` not destroying the encounter object.
- Fixed `PlaceableEvents.OnPhysicalAttacked` event always returning no data.

## 8193.34.7
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.6...v8193.34.7

### Package Updates
- NWNX 6a552d9 -> 3227d60

### Fixed
- Fixed an edge case issue that caused some servers to enter an infinite crash loop when shutting down.
- Fixed `NWNX_CORE_SHUTDOWN_SCRIPT` throwing a NRE during shutdown.

## 8193.34.6
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.5...v8193.34.6

### Added
- Added `Color` equality members `Equals` and operators `==` `!=`
- `NwGameTables`: Added `ExpTable`
- `NwGameTables`: Added `SkillItemCostTable`

### Package Updates
- Paket.Core 7.0.2 -> 7.1.4
- NWNX d15bc22 -> 6a552d9

### Fixed
- Fixed an issue that prevented .NET 6 plugins from being loaded with Paket.

## 8193.34.5
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.4...v8193.34.5

### Added
- `NwCreature.Encounter`: Gets the encounter that spawned the creature.
- `NwAreaOfEffect.Spell`: Gets the spell that created the area of effect.
- `NwAreaOfEffect.RemainingDuration`: Gets the remaining duration on the area of effect.

## 8193.34.4
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.3...v8193.34.4

### Fixed
- Fixed an issue where API services would not be constructed in the expected order.

## 8193.34.3
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.2...v8193.34.3

### Added
- `StrRef.ToParsedString()`: Gets the string associated with a StrRef and parses any tokens (e.g. \<CUSTOM0\>)
- `StrTokenCustom`: New structure for resolving/setting custom token values.
- `NwGameTables`: Added new 2da tables
  - `BodyBagTable`
  - `LightColorTable`
  - `PlaceableSoundTable`
  - `PlaceableTable`
  - `ProgrammedEffectTable`
  - `VisualEffectTable`
- `NwArea`: Added `GetTileInfo()`
- Added `InjectionService` & `ServiceBinding` tests.
- `NwPlaceable.Appearance`: Gets or sets the appearance for the placeable.
- `ModuleLoadTracker`: Added core service for tracking module load progress as debug log messages.
  - If a module fails to load due to an error with an area, the area is logged as an error instead.
- `NwPlayer`: Added player name override methods.
  - `PlayerNameOverrideService` contains configuration options.
- `NwCreature`: Added `GetFeatRemainingUses` `GetFeatTotalUses` `SetFeatRemainingUses`
- Added `OnMapPinAddPin`, `OnMapPinChangePin`, `OnMapPinDestroyPin` events.
- `NwCreature`: Added damage level override functions (`ClearDamageLevelOverride`, `GetDamageLevelOverride`, `SetDamageLevelOverride`)
- `NwCreature`: Added `DamageLevel` property.
- `NwGameTables`: Added `DamageLevelTable`

### Package Updates
- NWNX c51d233 -> d15bc22
- NWN.Core 8193.34.2 -> 8193.34.3
- LightInject 6.4.0 -> 6.4.1
- NLog 4.7.13 -> 4.7.15
- Paket.Core 6.2.1 -> 7.0.2

### Changed
- Rewrote core services and initialisation logic for easier extensibility, and reduced coupling with AnvilCore.
  - All core services now implement `ICoreService`, an interface containing specific event functions that are called at specific times in the server lifecycle.
  - Core services are executed in the order defined by `ServiceBindingOptions`.
  - The CoreService composition root is defined in `AnvilServiceManager`.
  - AnvilCore is now "dumber", and simply passes signals to `AnvilServiceManager` and `VirtualMachineFunctionHandler`.
  - `AnvilServiceManager` merges service initialization in `AnvilCore`, with the container/composition root setup from `IContainerFactory`
- `OnPlayerDeath.Killer` now tries to `GetLastDamager` when `GetLastHostileActor` is invalid.

### Deprecated
- `NwGameObject.CreatureAppearanceType`. Use `NwCreature.Appearance` instead.
- APIs using int-based StrRef parameters have been deprecated. Please use the StrRef overloads:
  - `NwGameObject.PlaySoundByStrRef()`
  - `NwPlayer.ClearTlkOverride()`
  - `NwPlayer.SetTlkOverride()`
  - `NwBaseItem.BaseItemStatsText`
  - `NwBaseItem.Description`
  - `NwBaseItem.Name`
  - `NwClass.Description`
  - `NwClass.Name`
  - `NwClass.NameLower`
  - `NwClass.NamePlural`
  - `NwFeat.Description`
  - `NwFeat.Name`
  - `NwSkill.Description`
  - `NwSkill.Name`
  - `NwSpell.AltMessage`
  - `NwSpell.Description`
  - `NwSpell.Name`
  - `OnELCValidationFailure.StrRef`

### Fixed
- Fixed a stack overflow when injecting the `InjectionService` as a property dependency.
- Unload is now triggered on all plugins before waiting for the assemblies to be unloaded. This fixes some edge cases where assemblies would not unload.

## 8193.34.2
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.1...v8193.34.2

### Added
- Added net6.0 target framework. Since multiple frameworks are now being targeted, there is a small change to the binary output paths.
  - When building locally, binaries are now located in `NWN.Anvil/bin/Release/<framework>`. Release binaries on github will now have a folder for each framework.
- `NwColor`: Added `FromRGBA`, `ToRGBA` `ToUnsignedRGBA` methods. `ToString` is now more explicit.
- Added various tests for `Color` conversion.
- Added `ResourceManager` tests.
- `NwArea`: Added various properties for environment visual options and metadata.
- `NwArea`: Added `CreateEnvironmentPreset`, `ApplyEnvironmentPreset` for saving and loading preset visual options.
- `NwWaypoint.Create`: Added overload without template parameter for creating a general waypoint.
- `PlayOptions`: Added PlayerPartyControl option.
- `StrRef`: Added value structure for string references (StrRefs). The associated talk table string can be resolved by invoking `ToString`.
- `NwGameTables`: Contains static members for commonly used 2das (internally cached by `CTwoDimArrays`).
  - Implemented `AppearanceTable` & `EnvironmentPresetTable`
- Implemented new `TwoDimArray`, `TwoDimArrayEntry` and `ITwoDimArrayEntry` APIs.
  - Supports general usage through `TwoDimArray`, and a generic `TwoDimArray<T>` type for specifying a custom row format. See the docs for more info.
- `ResourceManager`: Added `DeleteTempResource` and `GetResourceText`.
- `ResourceManager`: Added string overload for `WriteTempResource`.
- `LocalVariableStruct`: Added local variable type for serializing any C# type to JSON.
- `PersistentVariableStruct`: Added persistent variable type for serializing any C# type to JSON.
- Added `OnTriggerEnter` event.

### Package Updates
- NWNX: 790a54b -> c51d233
- NWN.Core: 8193.34.1 -> 8193.34.2
- NWN.Native: 8193.34.2 -> 8193.34.3

### Changed
- Change test assertion pattern to use NUnit constraints: https://docs.nunit.org/artcles/nunit/writing-tests/assertions/assertion-models/constraint.html
- Code samples are now built as a separate plugin project, and included in CI analysis.
- Improved path validation for `Delete/WriteTempResource`. It should no-longer be possible to navigate outside of the resource folder.

### Deprecated
- `NwServer.ReloadRules()`. Use `NwRuleset.ReloadRules()` instead.
- `NwColor.ToInt()`. Use `NwColor.ToRGBA()` instead.
- `ITwoDimArray`/`TwoDimArrayFactory`: The 2da APIs have been superseded by a simpler API. See the `ITwoDimArrayEntry` example for more info.
- `NwArea.GetFogAmount`: Use `SunFogAmount` and `MoonFogAmount` instead.
- `NwArea.GetFogColor`: Use `SunFogColor` and `MoonFogColor` instead.

### Removed
- NuiColor was removed and functionality replaced with the standard `Color` class. The intention is to remove confusion and conversion issues when interacting with both types.

### Fixed
- Fixed a NRE when using visibility properties.
- Fixed a NRE when using `PersistentVariableEnum`.

## 8193.34.1
https://github.com/nwn-dotnet/Anvil/compare/v8193.34.0...v8193.34.1

### Added
- NwPlayer: `IsConnected` boolean added. Should be checked when enumerating `NwModule.Players`
- NwPlayer: Added `DMPossessCreature` and `UnpossessCreature` for controlling player creature.
- NwPlayer: `ForceExamine` now supports creatures, placeables, items and doors.
- Implemented `NWN.Anvil.TestRunner` for running automated tests.
- NwPlayer: Added `Get/SetPersonalVisibilityOverride` methods for customizing object visibility per player.
- NwGameObject: Added `VisibilityOverride` property for customizing object visibility globally.
- Creature Events: Added `OnCreatureCheckProficiencies` event.
- Added `Local/Campaign/PersistentVariableEnum<T>` object variable type for user enum types.  The underlying type must be an integer.
- NwGameObject: Added `Clone` method for cloning non-creature and item objects.
- NwDoor: Added `Create` method for creating doors from ResRefs.
- NwEncounter: Added `Create` method for creating encounters from ResRefs.
- NwSound: Added `Create` method for creating sound objects from ResRefs.
- NwTrigger: Added `Create` method for creating triggers from ResRefs.
- NWN.Anvil.TestRunner: Added generator for generating ResRef constants from the standard creator palette.

### Package Updates
- NWN.Core: 8193.34.0 -> 8193.34.1

### Changed
- `NwCreature.WalkRateCap` and `NwCreature.AlwaysWalk` properties are no-longer persistent. Additionally, the services and functions are not hooked until the associated property is used for the first time.
- `NwObject.ObjectId` is now public.

### Fixed
- `AnvilCore.Reload()` now uses the scheduler service to schedule the reload. This should fix some edge cases where async methods would hold a reference preventing unload.
- Fixed an issue where the `SchedulerService` would throw an exception if the server was shutdown/reloaded during a schedule callback.
- Fixed a rare crash when subscribed to effect events.

## 8193.34.0
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.5...v8193.34.0

### Added
- `NwBaseItem`: Added various properties.
- `NwSpell`: Added various properties.
- `NwClass`: Added various properties.
- Added support for `NuiList` & `NuiListTemplateCell`.
- `Effect.DurationType`: Added setter.
- Added assembly attribute `PluginInfo` for defining optional dependencies.
- `PluginManager`: Added check for missing types from optional plugins.

### Package Updates
- (Docker) NWNX: 16b2c88 -> 790a54b
- NWN.Core: 8193.33.4 -> 8193.34.0
- NWN.Native: 8193.33.4 -> 8193.34.2

### Changed
- Services implementing `IInitializable` are now executed in deterministic order based on the service binding order defined in `ServiceBindingOptions`.
- Updated APIs to use ruleset classes
  - `Effect.SkillDecrease(NwSkill,int)`
  - `Effect.SkillIncrease(NwSkill,int)`
  - `Effect.Spell`
  - `ItemProperty.DecreaseSkill(NwSkill,int)`
  - `ItemProperty.SkillBonus(NwSkill,int)`
  - `Talent.Feat`
  - `Talent.Skill`
  - `Talent.Spell`
  - `NwSkill.ToTalent(this NwSkill)`
  - `NwSkill.ToTalent(this NwSpell)`
  - `NwSkill.ToTalent(this NwFeat)`
  - `CreatureEvents.OnSpellCastAt.Spell`
  - `CreatureEvents.OnSpellCastAt.Signal(NwObject,NwCreature,NwSpell,bool)`
  - `DoorEvents.OnSpellCastAt.Spell`
  - `DoorEvents.OnSpellCastAt.Signal(NwObject,NwDoor,NwSpell,bool)`
  - `ModuleEvents.OnPlayerGuiEvent.FeatSelection`
  - `ModuleEvents.OnPlayerGuiEvent.SkillSelection`
  - `PlaceableEvents.OnSpellCastAt.Spell`
  - `PlaceableEvents.OnSpellCastAt.Signal(NwObject,NwPlaceable,NwSpell,bool)`
  - `OnDisarmWeapon.Feat`
  - `OnUseFeat.Feat`
  - `OnUseSkill.Skill`
  - `OnSpellAction.Feat`
  - `OnSpellAction.Spell`
  - `OnSpellBroadcast.Feat`
  - `OnSpellBroadcast.Spell`
  - `OnSpellCast.Spell`
  - `OnSpellInterrupt.Feat`
  - `OnSpellInterrupt.Spell`
  - `OnSpellSlotMemorize.Spell`
  - `SpellEvents.OnSpellCast.Spell`
  - `SpellEvents.OnSpellCast.SpellCastClass`
  - `CreatureClassInfo.Class`
  - `CreatureClassInfo.AddKnownSpell(NwSpell,byte)`
  - `CreatureClassInfo.ClearMemorizedKnownSpells(NwSpell)`
  - `CreatureClassInfo.GetKnownSpells(byte)`
  - `CreatureClassInfo.RemoveKnownSpell(byte,NwSpell)`
  - `CreatureLevelInfo.Class`
  - `CreatureLevelInfo.Feats`
  - `CreatureLevelInfo.GetSkillRank(NwSkill)`
  - `CreatureLevelInfo.SetSkillRank(NwSkill,sbyte)`
  - `CreatureTypeFilter.Class(NwClass)`
  - `CreatureTypeFilter.DoesNotHaveSpellEffect(NwSpell)`
  - `CreatureTypeFilter.HasSpellEffect(NwSpell)`
  - `MemorizedSpellSlot.Spell`
  - `NwCreature.Classes`
  - `NwCreature.Feats`
  - `NwCreature.ActionCastFakeSpellAt(NwSpell,Location,ProjectilePathType)`
  - `NwCreature.ActionCastFakeSpellAt(NwSpell,NwGameObject,ProjectilePathType)`
  - `NwCreature.ActionUseFeat(NwFeat,NwGameObject)`
  - `NwCreature.ActionUseSkill(NwSkill,NwGameObject,SubSkill,NwItem)`
  - `NwCreature.AddFeat(NwFeat)`
  - `NwCreature.AddFeat(NwFeat,int)`
  - `NwCreature.DecrementRemainingFeatUses(NwFeat,int)`
  - `NwCreature.DoSkillCheck(NwSkill,int)`
  - `NwCreature.GetClassDomains(NwClass)`
  - `NwCreature.GetClassInfo(NwClass)`
  - `NwCreature.GetFeatGainLevel(NwFeat)`
  - `NwCreature.GetSkillRank(NwSkill,bool)`
  - `NwCreature.GetSpecialization(NwClass)`
  - `NwCreature.HasFeatEffect(NwFeat)`
  - `NwCreature.HasFeatPrepared(NwFeat)`
  - `NwCreature.HasSkill(NwSkill)`
  - `NwCreature.HasSpellEffect(NwSpell)`
  - `NwCreature.HasSpellUse(NwSpell)`
  - `NwCreature.IncrementRemainingFeatUses(NwFeat,int)`
  - `NwCreature.KnowsFeat(NwFeat)`
  - `NwCreature.LevelUpHenchman(NwClass,PackageType,bool)`
  - `NwCreature.MeetsFeatRequirements(NwFeat)`
  - `NwCreature.RemoveFeat(NwFeat)`
  - `NwCreature.SetSkillRank(NwSkill)`
  - `NwGameObject.ActionCastSpellAt(NwSpell,NwGameObject,MetaMagic,bool,int,ProjectilePathType,bool)`
  - `NwGameObject.ActionCastSpellAt(NwSpell,Location,MetaMagic,bool,int,ProjectilePathType,bool)`
  - `SpecialAbility(NwSpell,byte,bool)`
  - `SpecialAbility.Spell`
  - `OnELCSkillValidationFailure.Skill`
  - `OnELCSkillValidationFailure.Feat`
  - `OnELCSkillValidationFailure.Spell`
  - `WeaponService.Add***Feat(NwBaseItem,NwFeat)`

### Deprecated
- `CursorTargetService.EnterTargetMode` - Use NwPlayer.EnterTargetMode/NwPlayer.TryEnterTargetMode instead.

### Removed
- `Effect.AreaOfEffect(int,string,string,string)`
- `AttributeExtensions`
- `StandardFactionExtensions`
- `CreatureTypeFilter.RacialType`
- `Inventory.CheckFit(BaseItemType)`
- `NwCreature.RacialType`
- `NwCreature.ChangeToStandardFaction`
- `NwItem.BaseItemType`
- `NwItem.CanStack`
- `NwItem.IsStackable`
- `NwPlayer.NuiSetGroupLayout(int,string,NuiGroup)`
- `NwPlayer.NuiSetGroupLayout(int,string,NuiWindow)`
- `NwFaction(int)`
- `Anvil.Services.NwDateTime`
- `LoopTimeService`
- `ServiceBindingOptions.MissingPluginDependencies`
- `ServiceBindingOptions.Order`

## 8193.33.5
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.4...v8193.33.5

### Added
- NwModule: Added `LimboGameObjects` property to list all GameObjects currently stored in limbo.
- NwModule: Added `MoveObjectToLimbo` method to remove a GameObject from an area and store it in limbo.
- NwCreature: Added `AlwaysWalk` and `WalkRateCap` for restricting creature & player movement.
- Added `OnCheckEffectImmunity` event for bypassing effect immunity checks.
- Added `OnEffectApply` and `OnEffectRemove` events.
- Added ruleset APIs: `NwRuleset`, `NwBaseItem`, `NwClass`, `NwFeat`, `NwRace` `NwSkill` and `NwSpell`

### Changed
- Migrated LoopTimeService properties to static class `Anvil.API.Time`.
- Exposed `ScheduledTask` to Scheduler Service.
- Services implementing `IUpdateable` are now executed in deterministic order based on the service binding order defined in `ServiceBindingOptions`.

### Deprecated
- `LoopTimeService` - use `Anvil.API.Time` instead.
- Moved `NwDateTime` and `NwTimeSpan` to `Anvil.API` namespace.
- Duplicated APIs `NwItem.CanStack`/`NwItem.IsStackable`. Use `NwBaseItem.IsStackable` instead.

## 8193.33.4
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.3...v8193.33.4

### Package Updates
- (Docker) Update NWNX to [16b2c88](https://github.com/nwnxee/unified/commit/16b2c88b1f3e0ff929a8cad759090ce98d7d0b3c).

### Changed
- Startup log now includes the git revision of the current running server binary.
- Server revision is now printed to stdout if startup fails.

## 8193.33.3
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.2...v8193.33.3

### Added
- Implemented `PaketPluginSource` for installing and running NuGet-based plugins.
- Implemented support for custom plugin sources with the `IPluginSource` interface.
- Implemented `PluginStorageService` - a unified API for storing plugin data and configurations.
- Added `ANVIL_HOME` environment variable. This variable defines the root path where Anvil config files, plugins and plugin data are read from.
- Added additional properties to `NwEncounter`.
- Added IsStackable to 'NwItem'

### Package Updates
- NWN.Core -> 8193.33.4
- NWN.Native -> 8193.33.4

### Removed
- <u>**BREAKING CHANGE**</u> - Removed `ANVIL_NLOG_CONFIG` environment variable. The config path is now fixed to `{ANVIL_HOME}/nlog.config`
- <u>**BREAKING CHANGE**</u> - Removed `ANVIL_PLUGIN_PATH` environment variable. The plugin load path is now fixed to `{ANVIL_HOME}/Plugins`

### Fixed
- Fixed a server crash when preventing player connections in the `OnClientConnect` event.
- Fixed `OnClientConnect.CDKey` returning a type name instead of the client's public CD key.

## 8193.33.2
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.1...v8193.33.2

### Added
- ResourceManager: Implemented GffResource API.
- [Inject]: Property-based dependencies can now be flagged as "Optional". Optional dependencies do not throw exceptions if the service could not be loaded from a missing plugin assembly.

### Changed
- `[ServiceBindingOptions]` - The `BindingPriority` property defines the initialization order of a service. (Higher priority = initialized first).
- When injecting a dependency of an interface/base class and multiple candidates are available, the service with the highest `BindingPriority` will be injected.
- `NwCreature.Age` can now be set.

### Deprecated
- `[ServiceBindingOptions]` - `Order` has been deprecated and replaced with the `BindingPriority` property.
- `[ServiceBindingOptions]` - `MissingPluginDependencies` has been deprecated as functionality is covered by the `BindingPriority` dependency resolve behaviour.
- `AttributeExtensions` - moved to `ReflectionExtensions`.
- `NwPlayer.NuiSetGroupLayout` - moved to `NuiGroup.SetLayout`.

### Fixed
- Properties injected into service classes with plugin dependency requirements will no-longer throw an exception when the assembly is missing.
- Fixed NuiGroup.SetLayout creating nested layout elements instead of updating the existing element (`NwPlayer.NuiSetGroupLayout` still has the old behaviour.)

## 8193.33.1
https://github.com/nwn-dotnet/Anvil/compare/v8193.33.0...v8193.33.1

### Changed
- Update to NWN.Core 8193.33.1

### Fixed
- Fixed an issue when retrieving bind values for certain class/structures (NuiRect, NuiVector, etc.) would return the default value.
- Fixed an incorrect API/object mapping for NuiDrawList.

## 8193.33.0
https://github.com/nwn-dotnet/Anvil/compare/v8193.26.3...v8193.33.0

### Added
- NUI: Implement API with classes, added methods to NwPlayer.
- Effect: Added `Effect.Icon()` factory method for creating Icon effects.
- Effect: Added `Effect.RunAction()` factory methods for creating effects that invoke C# actions.
- ScriptHandleFactory: New service for dynamically creating function callbacks at runtime that are bound to script names. The returned handle is currently used for script parameters in effects.
- ModuleEvents: Added `OnPlayerGuiEvent`, `OnNuiEvent` and `OnPlayerTarget` events.
- GUIPanel: Added new constants published with NWN 8193.31
- NwPlayer: Added `SetGuiPanelDisabled` for disabling built-in GUI elements.
- NwPlayer: Added `RestDurationOverride` property.
- VirtualMachine: Added `RecursionLevel` property.
- LocalVariableCassowary: Added to support cassowary local variables.
- ILateDisposable: Added a new service event interface that is invoked after the server is destroyed.
- ServiceBindingOptions: Added `PluginDependencies` and `MissingPluginDependencies` properties for setting up services with optional plugin dependencies.
- Added `PRELINK_ENABLED` setting for disabling native prelink checks.

### Changed
- Refactored various internal usages of NWN.Native to use collection/list accessors for native types.
- VirtualMachine: `IsInScriptContext` now checks the current executing thread, and now only returns true while on the main thread and inside of a VM script context.
- HookService: Hooks are now returned/disposed after the server has been destroyed.
- IScriptDispatcher: Custom Script Dispatchers must now define an execution order. This order is used when a script call is triggered from the VM, and determines which service/s implementing this interface get executed first.
- ObjectStorageService (**Breaking**): Persistent data written in Anvil can no-longer be accessed by NWNX. Anvil can still import NWNX persistent data.
- ObjectStorageSerive: Anvil no-longer writes a duplicate `NWNX_POS` serialized field and instead writes its own `ANVIL_POS` field for persistent object data.

### Deprecated
- Effect: Deprecated `Effect.AreaOfEffect` that uses strings for the script handlers. Use the overload that uses `ScriptCallbackHandle` parameters instead.

### Removed
- HookService: Removed the optional `shutdownDispose` parameter (superseded by `ILateDisposable`).
- AnvilCore: Removed custom `ITypeLoader` support, and hardcoded references to the updated `PluginManager`.

### Fixed
- Fixed an issue where the `ObjectStorageService` would cause errors when performing hot reloads with `AnvilCore.Reload()`
- Fixed an issue where the PluginLoader would attempt to unload plugins too early during server shutdown/hot reload.
- Fixed an issue where the `EnforceLegalCharacterService` would call the `ELCValidationBefore` event outside of a script context.
- Fixed `OnChatMessageSend.Target` always being null.
- Fixed Plugin Unloadability & Hot Reload.
- Fixed a native crash caused by a conflict with Anvil's `ObjectStorageService` and NWNX's Object Storage (POS).

## 8193.26.3
https://github.com/nwn-dotnet/Anvil/compare/v8193.26.2...v8193.26.3

### Fixed
- OnCreatureDamage: Fixed damage hook function returning void instead of an int. Resolves an issue where damage effects would persist on a character, and be applied again after login.

## 8193.26.2
https://github.com/nwn-dotnet/Anvil/compare/v8193.26.1...v8193.26.2

### Changed
- IEvent: Exposed "Context" property, allowing plugins to implement custom events.

## 8193.26.1
https://github.com/nwn-dotnet/Anvil/compare/v8193.26.0...v8193.26.1

### Fixed
- OnCreatureDamage: Fixed a server crash when a creature received damage from non-object sources. (EffectDamage from a module/area event, etc.)

## 8193.26.0
https://github.com/nwn-dotnet/Anvil/compare/ffd9cd6dd0d6626ebc325265a8a8b370dd74d66b...v8193.26.0

### Initial Release!
