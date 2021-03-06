using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UnrealSharp;
using SDK.Script.EngineSDK;
using SDK.Script.FSDSDK;

namespace DeepRockGahactic
{
    public class DeepRockGahactic
    {
        String staticGameName => "FSD-Win64-Shipping";
        Process process;
        public Overlay esp;
        public void InitWindow()
        {
            while (true)
            {
                process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.Contains(staticGameName) && p.MainWindowHandle != IntPtr.Zero);
                if (process != null) break;
                Thread.Sleep(500);
            }
            new UnrealEngine(new Memory(process)).LoadAddesses(SDK.Addresses.Hardcoded.Payload);
            esp = new Overlay(process);
        }
        public void Start()
        {
            while (!Hotkeys.IsPressed(Keys.Delete))
            {
                esp.Begin();
                if (EngineLoop() > 0) { UEObject.ClearCache(); }
                esp.End();
            }
        }
        Boolean CanTakeDamage = true;
        public class Config
        {
            public Boolean Menu = Hotkeys.ToggledKey(Keys.Insert);
            public Boolean Enemies = Hotkeys.ToggledKey(Keys.F1);
            public Boolean Objectives = Hotkeys.ToggledKey(Keys.F2);
            public Boolean Radar = !Hotkeys.ToggledKey(Keys.F3);
            public Boolean Ammo = !Hotkeys.ToggledKey(Keys.F4);
            public Boolean Health = !Hotkeys.ToggledKey(Keys.F5);
            public Boolean Console = Hotkeys.IsPressed(Keys.F6);
            public Boolean Resources = Hotkeys.IsPressed(Keys.F7);
            public Boolean EndLevel = Hotkeys.IsPressed(Keys.F10);
            public Boolean ThirdPerson = Hotkeys.IsPressed(Keys.F9);
        }
        Int32 EngineLoop()
        {
            if (UnrealEngine.GWorldPtr == 0) return 1;
            var cfg = new Config();
            if (cfg.Menu)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Shalzuth's Helper Tool");
                sb.AppendLine("FPS : " + esp.MeasuredFps.ToString("0.00"));
                sb.AppendLine("Enemies(F1) : " + cfg.Enemies);
                sb.AppendLine("Objectives(F2) : " + cfg.Objectives);
                sb.AppendLine("Radar(F3) : " + cfg.Radar);
                sb.AppendLine("Ammo(F4) : " + cfg.Ammo);
                sb.AppendLine("Health(F5) : " + !CanTakeDamage);// cfg.Health);
                sb.AppendLine("Console(F6) : " + cfg.Console);
                sb.AppendLine("Resources(F7) : " + cfg.Resources);
                sb.AppendLine("EndLevel(F8) : " + cfg.EndLevel);
                sb.AppendLine("3rdPerson(F9) : " + cfg.ThirdPerson);
                esp.DrawText(sb.ToString(), new Vector2(20, 20), Color.OrangeRed);
                esp.DrawText(sb.ToString(), new Vector2(20, 20), Color.OrangeRed);
            }
            var World = new World(UnrealEngine.Memory.ReadProcessMemory<UInt64>(UnrealEngine.GWorldPtr)); if (!World.IsA<World>()) return 1;
            var OwningGameInstance = World.OwningGameInstance; if (!OwningGameInstance.IsA<GameInstance>()) return 1;
            var LocalPlayers = OwningGameInstance.LocalPlayers;
            var PlayerController = LocalPlayers[0].PlayerController.As<FSDPlayerController>(); if (!PlayerController.IsA<PlayerController>()) return 1;
            var Player = PlayerController.Player;
            var AcknowledgedPawn = PlayerController.AcknowledgedPawn.As<PlayerCharacter>();
            if (AcknowledgedPawn == null || !AcknowledgedPawn.IsA<PlayerCharacter>()) return 1;

            if (cfg.ThirdPerson) AcknowledgedPawn.SetCameraMode(ECharacterCameraMode.Follow);
            if (cfg.Ammo)
            {
                var InventoryComponent = AcknowledgedPawn.InventoryComponent;
                InventoryComponent.Flares = 4;
                InventoryComponent.GrenadeItem.Grenades = InventoryComponent.GrenadeItem.MaxGrenades;
                var EquippedItem = InventoryComponent.EquippedItem;
                if (EquippedItem.IsA<Item>())
                {
                    EquippedItem.Overheated = false;
                    if (EquippedItem.IsA(out AmmoDrivenWeapon ammoDrivenWeapon))
                    {
                        ammoDrivenWeapon.HasAutomaticFire = true;
                        ammoDrivenWeapon.CurrentTemperature = 1;
                        ammoDrivenWeapon.ClipCount = ammoDrivenWeapon.ClipSize;
                        if (EquippedItem.IsA(out CryosprayItem cryospray)) cryospray.CurrentPressure = 0;
                    }
                    if (EquippedItem.IsA(out DetPackItem detPackItem)) detPackItem.Capacity.AmmoCount = 3;
                    if (EquippedItem.IsA(out DoubleDrillItem drill))
                    {
                        drill.Fuel = drill.MaxFuel;
                    }
                    if (EquippedItem.IsA(out GrapplingHookGun gun))
                        gun.CoolDownAggregator.CooldownRemaining = 0;
                    if (EquippedItem.IsA(out ArmorRegeneratorItem armorRegenItem))
                    {
                        armorRegenItem.UnchargedCount = 0;
                        armorRegenItem.RechargeProgress = 0;
                        armorRegenItem.CarryCapacity.AmmoCount = 1;
                    }
                }
            }
            if (cfg.Health == CanTakeDamage)
            {
                var StatusEffectsComponent = AcknowledgedPawn.StatusEffectsComponent;
                var OwnerHealth = StatusEffectsComponent.OwnerHealth.As<PlayerHealthComponent>();
                OwnerHealth.SetCanTakeDamage(!CanTakeDamage);
                CanTakeDamage = !CanTakeDamage;
            }
            if (cfg.Console)
            {
                if (!PlayerController.CheatManager.IsA<CheatManager>())
                {
                    var engine = new Engine(UnrealEngine.GEngine);
                    var console = new SDK.Script.EngineSDK.Console(UnrealEngine.Memory.Execute(UnrealEngine.GStaticCtor, engine.ConsoleClass.Value, engine.GameViewport.Address, 0, 0, 0, 0, 0, 0, 0));
                    engine.GameViewport.ViewportConsole = console;

                    var cheats = new CheatManager(UnrealEngine.Memory.Execute(UnrealEngine.GStaticCtor, PlayerController.CheatClass.Value, engine.GameViewport.Address, 0, 0, 0, 0, 0, 0, 0));
                    PlayerController.CheatManager = cheats;
                    PlayerController.EnableCheats();
                }
            }
            if (cfg.Resources)
            {
                var PlayerResources = PlayerController.PlayerState.As<FSDPlayerState>().PlayerResources.Resources;
                for (var i = 1u; i < PlayerResources.Num; i++)
                {
                    var r = PlayerResources[i];
                    r.currentAmount = r.MaxAmount;
                }
            }
            if (cfg.EndLevel)
            {
                var gameState = World.GameState.As<FSDGameState>();
                if (gameState.GameStats.NumberOfPlayersEscapedInPod == 0)
                {
                    gameState.PlayerMadeItToDropPod = true;
                    gameState.objectivesCompleted = true;
                    gameState.GameStats.NumberOfPlayersEscapedInPod = 1;
                    //gameState.GameStats.TotalGoldMined = 10000;
                    gameState.GameStats.TotalEnemiesKilled = 1000; // xp amount
                    gameState.SetCompletionData(true, 3);
                    gameState.SetPlayersHaveReachedDroppod(false);
                    PlayerController.EndLevel();
                }
            }
            var PlayerCameraManager = PlayerController.PlayerCameraManager; if (!PlayerCameraManager.IsA<PlayerCameraManager>()) return 1;
            var CameraCache = PlayerCameraManager.CameraCachePrivate;
            var CameraPOV = CameraCache.POV;
            //var CameraLocation = new Vector3(CameraPOV.Location.X, CameraPOV.Location.Y, CameraPOV.Location.Z);
            var CameraLocation = UnrealEngine.Memory.ReadProcessMemory<Vector3>(CameraPOV.Location.Address); // minor optimization
            //var CameraRotation = new Vector3(CameraPOV.Rotation.Yaw, CameraPOV.Rotation.Pitch, CameraPOV.Rotation.Roll);
            var CameraRotation = UnrealEngine.Memory.ReadProcessMemory<Vector3>(CameraPOV.Rotation.Address); // minor optimization
            var CameraFOV = CameraPOV.FOV;
            CameraFOV = CameraFOV / 0.6875f;
            var PlayerRoot = AcknowledgedPawn.RootComponent;
            var PlayerRelativeLocation = PlayerRoot.RelativeLocation;
            var PlayerLocation = UnrealEngine.Memory.ReadProcessMemory<Vector3>(PlayerRelativeLocation.Address);
            if (cfg.Radar) esp.DrawArrow(PlayerLocation, CameraRotation, PlayerLocation, CameraRotation);

            // https://github.com/EpicGames/UnrealTournament/blob/3bf4b43c329ce041b4e33c9deb2ca66d78518b29/Engine/Source/Runtime/Engine/Classes/Engine/Level.h#L366
            // Actors
            // StreamedLevelOwningWorld
            // Owning World
            var actorListOffset = (UInt64)World.PersistentLevel.GetFieldOffset(World.PersistentLevel.GetFieldAddr("OwningWorld")) - 0x10;
            var Actors = new Array<Actor>(World.PersistentLevel.Address + actorListOffset);
            for (var i = 0u; i < Actors.Num; i++)
            {
                var Actor = Actors[i];
                if (Actor.Address == 0) continue;
                if (Actor.Address == Player.Address) continue;
                if (!Actor.IsA<Actor>()) continue;
                if (false && Actor.IsA(out DeepCSGSection deepCSGSection))
                {
                    var DeepMesh = deepCSGSection.DeepMesh;
                    // dunno how to find gold/morkite/etc nodes yet
                }
                if (Actor.IsA(out PlayerCharacter playerCharacter))
                {
                    if (!playerCharacter.OutlineComponent.IsA<OutlineComponent>()) continue;
                    //if ((playerCharacter.OutlineComponent.CurrentOutline == EOutline.OL_NONE) == cfg.Objectives) playerCharacter.OutlineComponent.ToggleDefaultOutline(cfg.Objectives);
                }
                if (Actor.IsA(out DeepPathfinderCharacter character))
                {
                    if (Actor.bActorIsBeingDestroyed) continue;
                    var RootComponent = Actor.RootComponent; if (RootComponent.Address == 0) continue; if (!RootComponent.IsA<SceneComponent>()) continue;
                    var RelativeLocation = RootComponent.RelativeLocation; if (RelativeLocation.Address == 0) continue;
                    var Location = UnrealEngine.Memory.ReadProcessMemory<Vector3>(RelativeLocation.Address);
                    var RelativeRotation = RootComponent.RelativeRotation;
                    var Rotation = UnrealEngine.Memory.ReadProcessMemory<Vector3>(RelativeRotation.Address);
                    if (!character.StatusEffects.IsA<StatusEffectsComponent>()) continue;
                    if (character.StatusEffects.OwnerHealth.IsA(out EnemyHealthComponent health))
                    {
                        if (Actor.GetFieldAddr("outline") == 0) continue;
                        var outline = new OutlineComponent(Actor["outline"].Address); if (!outline.IsA<OutlineComponent>()) continue;
                        if (health.Damage < health.MaxHealth)
                        {
                            // use outline instead
                            //if (cfg.Enemies) esp.DrawBox(Location, Rotation, CameraLocation, CameraRotation, CameraFOV, Color.Red);
                            if ((outline.CurrentOutline == EOutline.OL_NONE) == cfg.Enemies) outline.ToggleDefaultOutline(cfg.Enemies);
                            if (cfg.Radar) esp.DrawArrow(Location, Rotation, CameraLocation, CameraRotation);
                        }
                        else
                        {
                            if (outline.CurrentOutline != EOutline.OL_NONE) outline.ToggleDefaultOutline(false);
                        }
                    }
                }
                // buggy, restrict to certain actors
                if (Actor.GetFieldAddr("outline") > 0)
                {
                    var outline = new OutlineComponent(Actor["outline"].Address); if (!outline.IsA<OutlineComponent>()) continue;
                    if (((outline.CurrentOutline == EOutline.OL_NONE) == cfg.Objectives)
                        && (outline.DefaultOutline == EOutline.OL_NEUTRAL || outline.DefaultOutline == EOutline.OL_FRIENDLY || outline.DefaultOutline == EOutline.OL_ITEM))
                        outline.ToggleDefaultOutline(cfg.Objectives);
                }
                if (cfg.Objectives)
                {
                    if (Actor.IsA(out Gem gem) || Actor.IsA(out TreasureBox box) || Actor.IsA("BlueprintGeneratedClass /Game/GameElements/Resources/Collectibles/BP_Collectible_Base.BP_Collectible_Base_C"))
                    {
                        if (Actor.bActorIsBeingDestroyed) continue;
                        var RootComponent = Actor.RootComponent; if (RootComponent.Address == 0) continue; if (!RootComponent.IsA<SceneComponent>()) continue;
                        var RelativeLocation = RootComponent.RelativeLocation; if (RelativeLocation.Address == 0) continue;
                        var Location = UnrealEngine.Memory.ReadProcessMemory<Vector3>(RelativeLocation.Address);
                        var RelativeRotation = RootComponent.RelativeRotation;
                        var Rotation = UnrealEngine.Memory.ReadProcessMemory<Vector3>(RelativeRotation.Address);
                        if (Actor.IsA("BlueprintGeneratedClass /Game/GameElements/Resources/Collectibles/BP_Collectible_Base.BP_Collectible_Base_C"))
                            if (!Actor["IsActive"].Flag) continue;
                        if (Actor.GetFieldAddr("outline") == 0)
                        {
                            var loc = esp.WorldToScreen(Location, CameraLocation, CameraRotation, CameraFOV);
                            esp.DrawBox(Location, Rotation, CameraLocation, CameraRotation, CameraFOV, Color.Green);
                            esp.DrawText(Actor.ClassName.Split('_')[1], new Vector2(loc.X, loc.Y), Color.Green);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
