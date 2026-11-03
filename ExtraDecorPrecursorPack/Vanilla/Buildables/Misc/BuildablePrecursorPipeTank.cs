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

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Container
{
    public static class BuildablePrecursorPipeSpiral
    {
        static string ID = "BuildablePrecursorPipeSpiral";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Spiral Pipe", "Ancient precursor tech with a function to store and filter water.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "2d61d0b9-0fa7-407e-91ce-468dacce541d");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Precursor_Pipes_Tank_01").gameObject;
                gameObject.transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
                gameObject.transform.localPosition = Vector3.zero;
                GameObject gameObject2 = obj.transform.Find("FX").gameObject;
                gameObject2.transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
                gameObject2.transform.localPosition = new Vector3(0f, 1f, 0f);
                GameObject gameObject3 = obj.transform.Find("CullVolumeManager").gameObject;
                Object.DestroyImmediate(gameObject3);
                MeshFilter component = gameObject.GetComponent<MeshFilter>();
                Bounds bounds = component.sharedMesh.bounds;
                BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
                boxCollider.center = bounds.center;
                boxCollider.size = bounds.size;

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