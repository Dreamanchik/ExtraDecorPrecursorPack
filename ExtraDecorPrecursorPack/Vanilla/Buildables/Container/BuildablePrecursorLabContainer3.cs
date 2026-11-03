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
    public static class BuildablePrecursorLabContainer3
    {
        static string ID = "BuildablePrecursorLabContainer3";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Lab Container 3", "Ancient precursor tech built to contain various objects such as artefacts.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "44974fcd-c47a-41aa-a279-43eaf234bfa6");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Precursor_lab_container_02").gameObject;
                GameObject gameObject2 = obj.transform.Find("precursor_block_corner_04_02_04_v3").gameObject;
                gameObject2.transform.parent = gameObject.transform;
                GameObject gameObject3 = obj.transform.Find("precursor_block_corner_04_02_04_v3").gameObject;
                gameObject3.transform.parent = gameObject.transform;
                GameObject gameObject4 = obj.transform.Find("precursor_block_corner_04_02_04_v3 (1)").gameObject;
                gameObject4.transform.parent = gameObject.transform;
                GameObject gameObject5 = obj.transform.Find("Tubes").gameObject;
                gameObject5.transform.parent = gameObject.transform;
                gameObject.transform.localEulerAngles = new Vector3(270f, 90f, 0f);
                GameObject gameObject6 = obj.transform.Find("Cube").gameObject;
                gameObject6.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                gameObject6.transform.localScale = new Vector3(1f, 1f, 0.3f);
                GameObject gameObject7 = Object.Instantiate<GameObject>(gameObject6, obj.transform);
                gameObject7.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
                GameObject gameObject8 = Object.Instantiate<GameObject>(gameObject6, obj.transform);
                gameObject8.transform.localPosition = new Vector3(1.5f, 0f, 0f);
                PrefabUtils.AddStorageContainer(gameObject6, "Storage Container", "BuildableLabContainer2MSC", 10, 20, true);
                PrefabUtils.AddStorageContainer(gameObject7, "Storage Container", "BuildableLabContainer2LSC", 10, 20, true);
                PrefabUtils.AddStorageContainer(gameObject8, "Storage Container", "BuildableLabContainer2RSC", 10, 20, true);
                ItemDisplay itemDisplay = gameObject6.AddComponent<ItemDisplay>();
                itemDisplay.pos = new Vector3(0f, 1.25f, 0f);
                itemDisplay.size = new Vector3(1f, 1f, 3.4f);
                ItemDisplay itemDisplay2 = gameObject7.AddComponent<ItemDisplay>();
                itemDisplay2.pos = new Vector3(0f, 1.25f, 0f);
                itemDisplay2.size = new Vector3(1f, 1f, 3.4f);
                ItemDisplay itemDisplay3 = gameObject8.AddComponent<ItemDisplay>();
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