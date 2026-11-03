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

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Terminal
{
    public static class BuildablePrecursorEggIncubatorSmall
    {
        static string ID = "BuildablePrecursorEggIncubator";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Egg Incubator (Small)", "Ancient precursor Egg Incubator.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "2350240a-f039-440b-be51-53b79bc2deea");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("model").gameObject;
                gameObject.transform.parent.gameObject.transform.localPosition = new Vector3(0f, -1f, 0f);
                gameObject.transform.parent.gameObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                gameObject.transform.localPosition = new Vector3(0f, -7.7f, 0f);
                GameObject gameObject2 = obj.transform.Find("Eggs").gameObject;
                gameObject2.transform.localPosition = new Vector3(-2.18f, 0.3f, -0.78f);
                GameObject gameObject3 = obj.transform.Find("Precursor_computer_terminal").gameObject;
                gameObject3.transform.localPosition = new Vector3(-0.81f, 1.801f, 0.029f);
                GameObject gameObject4 = obj.transform.Find("CrystalTerminal").gameObject;
                gameObject4.transform.localPosition = new Vector3(-10f, 0.7f, 0f);
                GameObject gameObject5 = obj.transform.Find("Incubator").gameObject;
                Object.Destroy(gameObject5);
                GameObject gameObject6 = obj.transform.Find("UI").gameObject;
                Object.Destroy(gameObject6);

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