using BepInEx;
using BepInEx.Logging;
using ExtraDecorPrecursorPack.Modded.Buildables.Container;
using ExtraDecorPrecursorPack.Modded.Buildables.Misc;
using ExtraDecorPrecursorPack.Modded.Buildables.Misc.Item;
using ExtraDecorPrecursorPack.Vanilla.Buildables.Container;
using ExtraDecorPrecursorPack.Vanilla.Buildables.Light;
using ExtraDecorPrecursorPack.Vanilla.Buildables.Misc;
using ExtraDecorPrecursorPack.Vanilla.Buildables.Structure;
using ExtraDecorPrecursorPack.Vanilla.Buildables.Terminal;
using HarmonyLib;
using System.Reflection;

namespace ExtraDecorPrecursorPack
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {
            BuildablePrecursorLabContainer1.Register();
            BuildablePrecursorLabContainer2.Register();
            BuildablePrecursorLabContainer3.Register();
            //BuildablePrecursorLabContainer3WithBaby.Register();
            BuildablePrecursorSpecimenCases.Register();
            BuildablePrecursorShelves.Register();
            BuildablePrecursorTabletHolder.Register();
            BuildablePrecursorWallHolder.Register();
            BuildablePrecursorWallHolderRotated.Register();
            BuildablePrecursorActivatedLightBox1.Register();
            BuildablePrecursorActivatedLightBox2.Register();
            BuildablePrecursorActivatedLightBox3.Register();
            BuildablePrecursorActivatedLightBox4.Register();
            BuildablePrecursorActivatedPillar1.Register();
            BuildablePrecursorActivatedPillar2.Register();
            BuildablePrecursorActivatedPillar3.Register();
            BuildablePrecursorActivatedPillar4.Register();
            BuildablePrecursorBrokenKeyPurple.Register();
            BuildablePrecursorColumn1.Register();
            BuildablePrecursorColumn2.Register();
            //BuildablePrecursorDecoOctopus.Register();
            BuildablePrecursorDecoProp1.Register();
            BuildablePrecursorDecoProp2.Register();
            BuildablePrecursorDecoProp3.Register();
            BuildablePrecursorDecoProp4.Register();
            BuildablePrecursorInfoFrame.Register();
            BuildablePrecursorInfoFrameSmall.Register();
            BuildablePrecursorIonCrystalPedestal1.Register();
            BuildablePrecursorIonCrystalPedestal2.Register();
            BuildablePrecursorIonCrystalPedestal3.Register();
            BuildablePrecursorIonCrystalPedestal4.Register();
            BuildablePrecursorIonCrystalPedestal5.Register();
            BuildablePrecursorLabSurgicalMachine.Register();
            BuildablePrecursorLightBox.Register();
            BuildablePrecursorMicroscope.Register();
            BuildablePrecursorPipeSpiral.Register();
            BuildablePrecursorPipeTank.Register();
            BuildablePrecursorReactor.Register();
            BuildablePrecursorTable.Register();
            BuildablePrecursorTeleportSmall.Register();
            BuildablePrecursorTeleportSmallDeactivated.Register();
            BuildablePrecursorTeleport.Register();
            BuildablePrecursorTeleportDeactivated.Register();
            //BuildablePrecursorVent.Register();
            BuildablePrecursorWallDeco1.Register();
            BuildablePrecursorWallDeco2.Register();
            BuildablePrecursorWallDeco3.Register();
            BuildablePrecursorWarper.Register();
            BuildablePrecursorStructureColumn.Register();
            BuildablePrecursorDoorWay.Register();
            BuildablePrecursorDoorWaySmall.Register();
            BuildablePrecursorSurfaceFlat.Register();
            BuildablePrecursorSurfaceFlatSmall.Register();
            BuildablePrecursorSurfaceFrame.Register();
            BuildablePrecursorSurfaceFrameSmall.Register();
            BuildablePrecursorSurfaceLights.Register();
            BuildablePrecursorSurfaceLightsSmall.Register();
            BuildablePrecursorSurfaceGreenLight.Register();
            BuildablePrecursorSurfaceGreenLightSmall.Register();
            BuildablePrecursorSurfaceMaze.Register();
            BuildablePrecursorSurfaceMazeSmall.Register();
            BuildablePrecursorSurfaceSquare.Register();
            BuildablePrecursorSurfaceSquareSmall.Register();
            BuildablePrecursorWallFlat.Register();
            BuildablePrecursorWallFlatSmall.Register();
            BuildablePrecursorWallFrame.Register();
            BuildablePrecursorWallFrameSmall.Register();
            BuildablePrecursorWallLights.Register();
            BuildablePrecursorWallLightsSmall.Register();
            BuildablePrecursorWallGreenLight.Register();
            BuildablePrecursorWallGreenLightSmall.Register();
            BuildablePrecursorWallMaze.Register();
            BuildablePrecursorWallMazeSmall.Register();
            BuildablePrecursorWallSquare.Register();
            BuildablePrecursorWallSquareSmall.Register();
            BuildablePrecursorWallTilesCubesWide.Register();
            BuildablePrecursorWallTilesColumnsWide.Register();
            BuildablePrecursorWallTilesFrescoWide.Register();
            BuildablePrecursorGunCore.Register();
            BuildablePrecursorGunCoreSmall.Register();
            BuildablePrecursorKeyTerminalPurple.Register();
            BuildablePrecursorKeyTerminalOrange.Register();
            BuildablePrecursorKeyTerminalBlue.Register();
            BuildablePrecursorComputerTerminalA.Register();
            BuildablePrecursorComputerTerminalB.Register();
            BuildablePrecursorComputerTerminalC.Register();
            BuildablePrecursorEggIncubator.Register();
            BuildablePrecursorEggIncubatorSmall.Register();
            BuildablePrecursorIonCrystalTerminal.Register();
            BuildablePrecursorProtoRadio.Register();
            BuildablePrecursorProtoBattery.Register();
            BuildablePrecursorProtoTerminal.Register();
            BuildablePrecursorProtoTerminalDeactivated.Register();
            BuildablePrecursorProtoEggIncubator.Register();
            //BuildablePrecursorProtoFabricator.Register();
            BuildablePrecursorProtoPlaque.Register();
            BuildablePrecursorSmashedLabContainer.Register();
            BuildablePrecursorDeployableLight.Register();
            BuildablePrecursorDeployableLightFragment1.Register();
            BuildablePrecursorDeployableLightFragment2.Register();
            BuildablePrecursorDeployableLightDisplay.Register();
            BuildablePrecursorPhaseGateStabilizerDisplay.Register();
            BuildablePrecursorPhaseGateTransmitterDisplay.Register();
            BuildablePrecursorIonPrismDisplay.Register();
            BuildablePrecursorAlienBuildingBlock.Register();
            BuildablePrecursorIonPrism.Register();
            BuildablePrecursorProtoIngot.Register();
            BuildablePrecursorWarperRemnant.Register();
            BuildablePrecursorProtoSuitUpgrade.Register();
            BuildablePrecursorPhaseGateStabilizer.Register();
            BuildablePrecursorPhaseGateStructure.Register();
            BuildablePrecursorPhaseGateTransmitter.Register();
            BuildablePrecursorDefenseFacilityKey.Register();
            BuildablePrecursorEngineFacilityKey.Register();
            BuildablePrecursorHullFacilityKey.Register();
            BuildablePrecursorInterceptorFacilityKey.Register();
            BuildablePrecursorTransmissionDevice.Register();
            //BuildablePrecursorProtoLever.Register();
        }
    }
}