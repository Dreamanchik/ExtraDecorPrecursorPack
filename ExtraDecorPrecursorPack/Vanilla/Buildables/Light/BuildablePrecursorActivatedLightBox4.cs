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

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Light
{
    public static class BuildablePrecursorActivatedLightBox4
    {
        static string ID = "BuildablePrecursorActivatedLightBox4";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Small Activated Floor Light", "Ancient precursor decorative piece. Emmits light when an entity nearby.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "5cc19d2a-24b1-4a9f-b382-1c218346721c");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Ceiling | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("meshes").gameObject;
                gameObject.transform.localPosition = new Vector3(1f, 0f, 0f);
                BoxCollider component = obj.GetComponent<BoxCollider>();
                component.center = new Vector3(0f, 1.75f, 0f);
                GameObject gameObject2 = gameObject.transform.Find("precursor_block_deco_12_04_06").gameObject;
                GameObject gameObject3 = gameObject.transform.Find("precursor_block_deco_12_04_06 (2)").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = gameObject.transform.Find("precursor_block_deco_12_04_06 (3)").gameObject;
                Object.Destroy(gameObject4);
                MeshFilter component2 = gameObject2.GetComponent<MeshFilter>();
                Bounds bounds = component2.sharedMesh.bounds;
                BoxCollider boxCollider = gameObject2.AddComponent<BoxCollider>();
                boxCollider.center = Vector3.zero;
                boxCollider.size = new Vector3(3f, 1.5f, 0.1f);

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