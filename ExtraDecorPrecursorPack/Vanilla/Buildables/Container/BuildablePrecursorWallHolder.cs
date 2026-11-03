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
    public static class BuildablePrecursorWallHolder
    {
        static string ID = "BuildablePrecursorWallHolder";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Wall Holder (90°)", "Ancient precursor tech built to contain items.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "dbedda33-a855-4b40-972e-5c91ab5846a4");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject[] array = new GameObject[]
                {
                    obj.transform.Find("HoopFish").gameObject,
                    obj.transform.Find("HoopFish (1)").gameObject,
                    obj.transform.Find("SpadeFish").gameObject,
                    obj.transform.Find("___New Group").gameObject,
                    obj.transform.Find("___New Group (1)").gameObject,
                    obj.transform.Find("___New Group (2)").gameObject,
                    obj.transform.Find("___New Group (3)").gameObject,
                    obj.transform.Find("___New Group (4)").gameObject,
                    obj.transform.Find("___New Group (5)").gameObject,
                    obj.transform.Find("___New Group (6)").gameObject,
                    obj.transform.Find("___New Group (7)").gameObject,
                    obj.transform.Find("___New Group (8)").gameObject,
                    obj.transform.Find("___New Group (9)").gameObject,
                    obj.transform.Find("___New Group (10)").gameObject,
                    obj.transform.Find("___New Group (11)").gameObject,
                    obj.transform.Find("___New Group (12)").gameObject,
                    obj.transform.Find("___New Group (13)").gameObject,
                    obj.transform.Find("___New Group (14)").gameObject,
                    obj.transform.Find("___New Group (15)").gameObject,
                    obj.transform.Find("___New Group (16)").gameObject,
                    obj.transform.Find("___New Group (17)").gameObject,
                    obj.transform.Find("___New Group (18)").gameObject,
                    obj.transform.Find("___New Group (19)").gameObject,
                    obj.transform.Find("___New Group (20)").gameObject,
                    obj.transform.Find("___New Group (21)").gameObject,
                    obj.transform.Find("___New Group (22)").gameObject,
                    obj.transform.Find("___New Group (23)").gameObject,
                    obj.transform.Find("___New Group (26)").gameObject,
                    obj.transform.Find("___New Group (27)").gameObject,
                    obj.transform.Find("___New Group (28)").gameObject,
                    obj.transform.Find("___New Group (29)").gameObject
                };
                foreach (GameObject gameObject in array)
                {
                    Object.Destroy(gameObject);
                }
                GameObject gameObject2 = obj.transform.Find("___New Group (24)").gameObject;
                GameObject gameObject3 = obj.transform.Find("___New Group (25)").gameObject;
                GameObject gameObject4 = new GameObject();
                gameObject4.name = "parent";
                gameObject4.transform.parent = obj.transform;
                Object.Instantiate<GameObject>(gameObject4);
                gameObject2.transform.parent = gameObject4.transform;
                gameObject3.transform.parent = gameObject4.transform;
                gameObject2.transform.localPosition = new Vector3(-0.15f, 0f, 0.15f);
                gameObject2.transform.localEulerAngles = Vector3.zero;
                gameObject3.transform.localPosition = new Vector3(0.15f, 0f, 0.15f);
                gameObject3.transform.localEulerAngles = Vector3.zero;
                GameObject gameObject5 = Object.Instantiate<GameObject>(gameObject2);
                gameObject5.transform.parent = gameObject4.transform;
                gameObject5.transform.localPosition = new Vector3(0f, 0f, 0.15f);
                Object.Destroy(gameObject5.transform.Find("precursor_block_solid_08_02_04 (1)").gameObject);
                Object.Destroy(gameObject5.transform.Find("precursor_column_maze_deco (1)").gameObject.transform.Find("precursor_column_maze_deco").gameObject);
                gameObject5.transform.localScale = new Vector3(1f, 1f, 1f);
                BoxCollider component = gameObject5.transform.Find("precursor_column_maze_deco (1)").gameObject.transform.Find("Cube").gameObject.GetComponent<BoxCollider>();
                component.size = new Vector3(0.75f, 0.75f, 0.75f);
                component.center = Vector3.zero;
                PrefabUtils.AddStorageContainer(gameObject5, "Storage Container", "BuildableWallHolderSC", 10, 20, true);
                StorageContainer component2 = gameObject5.GetComponent<StorageContainer>();
                ItemDisplay itemDisplay = gameObject5.AddComponent<ItemDisplay>();
                itemDisplay.pos = new Vector3(0f, 0f, -0.05f);
                itemDisplay.rot = new Vector3(270f, 90f, 0f);

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