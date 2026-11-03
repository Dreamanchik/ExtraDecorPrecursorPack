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
    public static class BuildablePrecursorWallDeco2
    {
        static string ID = "BuildablePrecursorWallDeco2";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Star Wall Deco", "Ancient precursor tech with an unknown functionality.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "a0a9237e-dee3-4efa-81ff-fea3893a6eb7");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("precursor_cables_end_01").gameObject;
                gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject.transform.localPosition = new Vector3(0f, 0f, 0.2f);
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject gameObject2 = obj.transform.Find("precursor_cables_end_01_collisions").gameObject;
                gameObject2.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject2.transform.localPosition = new Vector3(0f, 0f, 0.2f);
                gameObject2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

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