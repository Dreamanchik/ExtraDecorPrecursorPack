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
    public static class BuildablePrecursorWallTilesColumnsWide
    {
        static string ID = "BuildablePrecursorWallTilesColumnsWide";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Wall Tiles Columns (wide)", "Usable wall tiles with patterns extracted from precursor structures");

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
                GameObject gameObject2 = gameObject.transform.Find("Precursor_Gun_Entry_wall_05").gameObject;
                GameObject gameObject3 = gameObject.transform.Find("Precursor_Gun_Entry_wall_05 (5)").gameObject;
                gameObject2.transform.parent = obj.transform;
                gameObject3.transform.parent = obj.transform;
                Object.Destroy(gameObject);
                Object.Destroy(obj.transform.Find("precursor_gun_Entry_shell").gameObject);
                Object.Destroy(obj.transform.Find("precursor_gun_Entry_room_collisions").gameObject);
                Object.Destroy(obj.transform.Find("CullVolumeManager").gameObject);
                Object.Destroy(obj.transform.Find("Occluder_precursor_gun_Entry_shell").gameObject);
                GameObject gameObject4 = new GameObject();
                gameObject4.name = "group";
                gameObject4.transform.parent = obj.transform;
                Object.Instantiate<GameObject>(gameObject4);
                gameObject4.SetActive(true);
                gameObject2.transform.parent = gameObject4.transform;
                gameObject3.transform.parent = gameObject4.transform;
                gameObject2.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                gameObject2.transform.localPosition = new Vector3(0f, 1.45f, 0f);
                gameObject3.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                gameObject3.transform.localPosition = new Vector3(0.42f, 1.45f, 2f);
                gameObject3.transform.localEulerAngles = new Vector3(270f, 0f, 0f);
                gameObject4.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject4.transform.localPosition = new Vector3(-1f, 0f, 0f);
                BoxCollider boxCollider = gameObject4.AddComponent<BoxCollider>();
                boxCollider.center = new Vector3(0.2f, 1.43f, 1f);
                boxCollider.size = new Vector3(0.7f, 3f, 4f);
                SkyApplier component = obj.GetComponent<SkyApplier>();
                component.anchorSky = Skies.BaseInterior;

                Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject4);
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