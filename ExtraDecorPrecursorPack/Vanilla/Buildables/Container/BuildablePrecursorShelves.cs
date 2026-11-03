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
    public static class BuildablePrecursorShelves
    {
        static string ID = "BuildablePrecursorShelves";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Shelves", "Ancient precursor tech built to contain various objects such as artefacts.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "11e731e7-bc82-4f94-90be-5db7b58b449b");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Precursor_Prison_EggLab").gameObject;
                gameObject.SetActive(true);
                GameObject gameObject2 = obj.transform.Find("CullVolumeManager").gameObject;
                Object.Destroy(gameObject2);
                GameObject gameObject3 = obj.transform.Find("Occluder_Precursor_Prison_Antechamber_EggLab_shell").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = obj.transform.Find("Precursor_Prison_Antechamber_EggLab_shell").gameObject;
                Object.Destroy(gameObject4);
                GameObject gameObject5 = obj.transform.Find("Precursor_Prison_EggLab_collisions").gameObject;
                GameObject gameObject6 = gameObject5.transform.Find("Cube (90)").gameObject;
                gameObject6.transform.parent = obj.transform;
                gameObject6.transform.localPosition = Vector3.zero;
                gameObject6.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Object.Destroy(gameObject5);
                GameObject gameObject7 = new GameObject();
                gameObject7.name = "col";
                gameObject7.transform.parent = obj.transform;
                gameObject6.transform.parent = gameObject7.transform;
                gameObject7.transform.localPosition = new Vector3(0f, 0.75f, 0.2f);
                gameObject6.transform.localEulerAngles = Vector3.zero;
                gameObject6.name = "colDownFront";
                BoxCollider component = gameObject6.GetComponent<BoxCollider>();
                component.center = new Vector3(0f, 0f, 2f);
                component.size = new Vector3(2f, 3f, 2f);
                PrefabUtils.AddStorageContainer(gameObject6, "Storage Container", "PrecursorShelvesDownFrontSC", 10, 20, true);
                ItemDisplay itemDisplay = gameObject6.AddComponent<ItemDisplay>();
                itemDisplay.pos = new Vector3(0f, -0.4f, 2.2f);
                itemDisplay.size = new Vector3(1.5f, 1.5f, 1.5f);
                GameObject gameObject8 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject8.name = "colDownFrontLeft";
                gameObject8.transform.localEulerAngles = new Vector3(0f, 45f, 0f);
                GameObject gameObject9 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject9.name = "colDownLeft";
                gameObject9.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                GameObject gameObject10 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject10.name = "colDownBackLeft";
                gameObject10.transform.localEulerAngles = new Vector3(0f, 135f, 0f);
                GameObject gameObject11 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject11.name = "colDownBack";
                gameObject11.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                GameObject gameObject12 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject12.name = "colDownBackRight";
                gameObject12.transform.localEulerAngles = new Vector3(0f, 225f, 0f);
                GameObject gameObject13 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject13.name = "colDownRight";
                gameObject13.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
                GameObject gameObject14 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject14.name = "colDownFrontRight";
                gameObject14.transform.localEulerAngles = new Vector3(0f, 315f, 0f);
                GameObject gameObject15 = Object.Instantiate<GameObject>(gameObject6, gameObject7.transform);
                gameObject15.name = "colUpFront";
                gameObject15.transform.localPosition = new Vector3(0f, 1.25f, 0f);
                GameObject gameObject16 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject16.name = "colUpFrontLeft";
                gameObject16.transform.localEulerAngles = new Vector3(0f, 45f, 0f);
                GameObject gameObject17 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject17.name = "colUpLeft";
                gameObject17.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                GameObject gameObject18 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject18.name = "colUpBackLeft";
                gameObject18.transform.localEulerAngles = new Vector3(0f, 135f, 0f);
                GameObject gameObject19 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject19.name = "colUpBack";
                gameObject19.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                GameObject gameObject20 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject20.name = "colUpBackRight";
                gameObject20.transform.localEulerAngles = new Vector3(0f, 225f, 0f);
                GameObject gameObject21 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject21.name = "colUpRight";
                gameObject21.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
                GameObject gameObject22 = Object.Instantiate<GameObject>(gameObject15, gameObject7.transform);
                gameObject22.name = "colUpFrontLeft";
                gameObject22.transform.localEulerAngles = new Vector3(0f, 315f, 0f);
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                gameObject.transform.localPosition = Vector3.zero;
                GameObject gameObject23 = gameObject.transform.Find("Precursor_Prison_Antechamber_EggLab_wall_22").gameObject;
                GameObject gameObject24 = gameObject.transform.Find("Precursor_Prison_Antechamber_EggLab_wall_22 (1)").gameObject;
                GameObject gameObject25 = gameObject.transform.Find("Precursor_Prison_Antechamber_EggLab_wall_22 (2)").gameObject;
                GameObject gameObject26 = gameObject.transform.Find("Precursor_Prison_Antechamber_EggLab_wall_22 (3)").gameObject;
                gameObject23.transform.parent = obj.transform;
                gameObject24.transform.parent = obj.transform;
                gameObject25.transform.parent = obj.transform;
                gameObject26.transform.parent = obj.transform;
                gameObject5.transform.parent = obj.transform;
                Object.Destroy(gameObject);
                GameObject gameObject27 = new GameObject();
                gameObject27.name = "parent";
                gameObject27.transform.localEulerAngles = new Vector3(270f, 0f, 0f);
                gameObject27.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                gameObject27.transform.parent = obj.transform;
                gameObject23.transform.parent = gameObject27.transform;
                gameObject24.transform.parent = gameObject27.transform;
                gameObject25.transform.parent = gameObject27.transform;
                gameObject26.transform.parent = gameObject27.transform;
                gameObject23.transform.localPosition = new Vector3(1.47f, -1.085f, 2.8f);
                gameObject24.transform.localPosition = new Vector3(-0.71f, -1.85f, 2.8f);
                gameObject25.transform.localPosition = new Vector3(0.71f, 1.095f, 2.8f);
                gameObject26.transform.localPosition = new Vector3(-1.47f, 0.33f, 2.8f);
                SkyApplier component2 = obj.GetComponent<SkyApplier>();
                component2.customSkyPrefab = null;
                component2.anchorSky = Skies.BaseInterior;

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