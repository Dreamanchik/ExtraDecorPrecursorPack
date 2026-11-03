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
    public static class BuildablePrecursorPipeTank
    {
        static string ID = "BuildablePrecursorPipeTank";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Pipe Tank", "Ancient precursor tech with a function to store and filter water.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "0b1cf8d8-65da-4b9d-bf86-bfb96ac35ae0");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("CullVolumeManager").gameObject;
                Object.DestroyImmediate(gameObject);
                GameObject gameObject2 = obj.transform.Find("precursor_pipe_Spiral").gameObject;
                GameObject[] array = new GameObject[]
                {
                    obj.transform.Find("precursor_pipe_PipeEnds").gameObject,
                    obj.transform.Find("Collision").gameObject,
                    obj.transform.Find("Collision2").gameObject,
                    obj.transform.Find("Collision2 (1)").gameObject,
                    obj.transform.Find("Collision2 (2)").gameObject,
                    obj.transform.Find("Collision2 (3)").gameObject,
                    obj.transform.Find("Collision2 (4)").gameObject,
                    obj.transform.Find("FX").gameObject
                };
                foreach (GameObject gameObject3 in array)
                {
                    gameObject3.transform.parent = gameObject2.transform;
                }
                gameObject2.transform.localScale = new Vector3(0.115f, 0.115f, 0.115f);
                gameObject2.transform.localPosition = new Vector3(0f, 0.3f, 0f);

                Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject2);
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