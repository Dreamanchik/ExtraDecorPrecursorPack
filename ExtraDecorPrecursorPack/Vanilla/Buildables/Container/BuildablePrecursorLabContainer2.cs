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
    public static class BuildablePrecursorLabContainer2
    {
        static string ID = "BuildablePrecursorLabContainer2";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Lab Container 2", "Ancient precursor tech built to contain various objects such as artefacts.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "1b85a183-2084-42a6-8d85-7e58dd6864bd");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Precursor_lab_container_02").gameObject;
                gameObject.transform.localEulerAngles = new Vector3(270f, 90f, 0f);
                GameObject gameObject2 = obj.transform.Find("Cube").gameObject;
                gameObject2.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject2.transform.localScale = new Vector3(1f, 1f, 0.3f);
                GameObject gameObject3 = Object.Instantiate<GameObject>(gameObject2, obj.transform);
                gameObject3.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
                GameObject gameObject4 = Object.Instantiate<GameObject>(gameObject2, obj.transform);
                gameObject4.transform.localPosition = new Vector3(1.5f, 0f, 0f);
                PrefabUtils.AddStorageContainer(gameObject2, "Storage Container", "BuildableLabContainer2MSC", 10, 20, true);
                PrefabUtils.AddStorageContainer(gameObject3, "Storage Container", "BuildableLabContainer2LSC", 10, 20, true);
                PrefabUtils.AddStorageContainer(gameObject4, "Storage Container", "BuildableLabContainer2RSC", 10, 20, true);
                ItemDisplay itemDisplay = gameObject2.AddComponent<ItemDisplay>();
                itemDisplay.pos = new Vector3(0f, 1.25f, 0f);
                itemDisplay.size = new Vector3(1f, 1f, 3.4f);
                ItemDisplay itemDisplay2 = gameObject3.AddComponent<ItemDisplay>();
                itemDisplay2.pos = new Vector3(0f, 1.25f, 0f);
                itemDisplay2.size = new Vector3(1f, 1f, 3.4f);
                ItemDisplay itemDisplay3 = gameObject4.AddComponent<ItemDisplay>();
                itemDisplay3.pos = new Vector3(0f, 1.25f, 0f);
                itemDisplay3.size = new Vector3(1f, 1f, 3.4f);

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