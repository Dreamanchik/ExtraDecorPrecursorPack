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

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Misc
{
    public static class BuildablePrecursorTabletHolder
    {
        static string ID = "BuildablePrecursorTabletHolder";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Tablet Holder", "Ancient precursor tech built to contain tablets.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "814beddb-62cf-4c55-a86d-5da0684932a8");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("precursor_column_maze_08_12_08_v3").gameObject;
                gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                GameObject gameObject2 = obj.transform.Find("Cube").gameObject;
                gameObject2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                GameObject gameObject3 = obj.transform.Find("Cube (1)").gameObject;
                gameObject3.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                PrefabUtils.AddStorageContainer(gameObject3, "Storage Container", "BuildableTabletHolderSC", 10, 20, true);
                StorageContainer component = gameObject3.GetComponent<StorageContainer>();
                ItemDisplay itemDisplay = gameObject3.AddComponent<ItemDisplay>();
                itemDisplay.pos = new Vector3(0f, 2.35f, -1f);
                itemDisplay.size = new Vector3(2f, 2f, 2f);

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