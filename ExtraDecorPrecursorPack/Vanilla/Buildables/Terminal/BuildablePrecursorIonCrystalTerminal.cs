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
    public static class BuildablePrecursorIonCrystalTerminal
    {
        static string ID = "BuildablePrecursorIonCrystalTerminal";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Ion Cube Terminal", "Ancient precursor Ion Cube storage device.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "3d625dbb-d15a-4351-bca0-0a0526f01e6e");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("CrystalTerminal").gameObject;
                gameObject.transform.localPosition = Vector3.zero;
                GameObject gameObject2 = obj.transform.Find("Incubator").gameObject;
                Object.Destroy(gameObject2);
                GameObject gameObject3 = obj.transform.Find("UI").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = obj.transform.Find("model").gameObject;
                Object.Destroy(gameObject4);
                GameObject gameObject5 = obj.transform.Find("Eggs").gameObject;
                Object.Destroy(gameObject5);
                GameObject gameObject6 = obj.transform.Find("Precursor_computer_terminal").gameObject;
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