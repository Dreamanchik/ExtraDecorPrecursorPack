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
    public static class BuildablePrecursorWallTilesFrescoWide
    {
        static string ID = "BuildablePrecursorWallTilesCubesWide";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Wall Tiles Fresco (wide)", "Usable wall tiles with patterns extracted from precursor structures");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "5ca9d34d-3b1e-46b7-9660-ab3156db7d28");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("precursor_gun_Entry_room").gameObject;
                GameObject gameObject2 = gameObject.transform.Find("Precursor_Gun_Entry_wall_09").gameObject;
                gameObject2.transform.parent = obj.transform;
                Object.Destroy(gameObject);
                Object.Destroy(obj.transform.Find("precursor_gun_Entry_shell").gameObject);
                Object.Destroy(obj.transform.Find("precursor_gun_Entry_room_collisions").gameObject);
                Object.Destroy(obj.transform.Find("CullVolumeManager").gameObject);
                Object.Destroy(obj.transform.Find("Occluder_precursor_gun_Entry_shell").gameObject);
                GameObject gameObject3 = new GameObject();
                gameObject3.name = "group";
                gameObject3.transform.parent = obj.transform;
                Object.Instantiate<GameObject>(gameObject3);
                gameObject3.SetActive(true);
                gameObject2.transform.parent = gameObject3.transform;
                gameObject2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                gameObject2.transform.localPosition = new Vector3(0.48f, 1.45f, 0f);
                gameObject3.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject3.transform.localPosition = new Vector3(0f, 0f, 0.2f);
                GameObject gameObject4 = gameObject2.transform.Find("Precursor_Gun_Entry_wall_09").gameObject;
                gameObject4.transform.localPosition = new Vector3(0.45f, 0f, 0f);
                GameObject gameObject5 = gameObject2.transform.Find("Precursor_Gun_Entry_wall_09_LOD1").gameObject;
                gameObject5.transform.localPosition = new Vector3(0.45f, 0f, 0f);
                BoxCollider boxCollider = gameObject3.AddComponent<BoxCollider>();
                boxCollider.center = new Vector3(0.2f, 1.43f, 0f);
                boxCollider.size = new Vector3(0.3f, 3f, 2.5f);
                SkyApplier component = obj.GetComponent<SkyApplier>();
                component.anchorSky = Skies.BaseInterior;

                Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject3);
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