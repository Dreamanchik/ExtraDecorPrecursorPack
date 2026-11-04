using ExtraDecorPrecursorPack.Mono;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Structure
{
    public static class BuildablePrecursorWallTilesCubesWide
    {
        static string ID = "BuildablePrecursorWallTilesCubesWide";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Wall Tiles Cubes (wide)", "Usable wall tiles with patterns extracted from precursor structures");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "105f340b-65ac-43c7-b2f0-612d2cf3e400");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Precursor_LavaBase_Hallway_instances").gameObject.transform.Find("Precursor_LavaBase_ThermalRoomEntry_Instances").gameObject.transform.Find("Precursor_LavaBase_Hallway_wall_01").gameObject;
                gameObject.transform.parent = gameObject.transform.parent.parent.parent;
                gameObject.transform.localPosition = new Vector3(-0.5f, 1.43f, 0f);
                gameObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                GameObject gameObject2 = obj.transform.Find("Precursor_LavaBase_Hallway_instances").gameObject.transform.Find("Precursor_LavaBase_ThermalRoomEntry_Instances").gameObject.transform.Find("Precursor_LavaBase_Hallway_wall_01 (3)").gameObject;
                gameObject2.transform.parent = gameObject2.transform.parent.parent.parent;
                gameObject2.transform.localPosition = new Vector3(-0.5f, 1.43f, 0f);
                gameObject2.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
                gameObject.SetActive(true);
                gameObject2.SetActive(true);
                GameObject[] array = new GameObject[]
                {
                    gameObject.transform.parent.gameObject.transform.Find("Precursor_LavaBase_Hallway_instances").gameObject,
                    gameObject.transform.parent.gameObject.transform.Find("CullVolumeManager").gameObject
                };
                foreach (GameObject gameObject3 in array)
                {
                    Object.DestroyImmediate(gameObject3);
                }
                MeshFilter component = gameObject.transform.Find("Precursor_LavaBase_Hallway_wall_01").GetComponent<MeshFilter>();
                Bounds bounds = component.sharedMesh.bounds;
                BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
                boxCollider.center = new Vector3(1.5f, 0f, 0f);
                boxCollider.size = new Vector3(7f, 0.98f, 8.78f);
                SkyApplier component2 = gameObject.transform.parent.gameObject.GetComponent<SkyApplier>();
                component2.anchorSky = Skies.BaseInterior;

                Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject);
                constructable.placeDefaultDistance = PlaceDistance;
                constructable.placeMinDistance = MinPlaceDistance;
                constructable.placeMaxDistance = MaxPlaceDistance;
                constructable.rotationEnabled = true;
            };
            prefab.SetGameObject(clone);
            prefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
            ));
            prefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);
            prefab.Register();
        }
    }
}