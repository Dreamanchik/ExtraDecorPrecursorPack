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

namespace ExtraDecorPrecursorPack.Vanilla.Buildables.Light
{
    public static class BuildablePrecursorActivatedPillar3
    {
        static string ID = "BuildablePrecursorActivatedPillar3";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Small Activated Pillar", "Ancient precursor decorative piece. Emmits light when an entity nearby.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "04ad6244-1766-4622-bb8a-7fa29845bc68");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Ceiling | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Pillar").gameObject;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                gameObject.transform.localEulerAngles = Vector3.zero;
                GameObject gameObject2 = obj.transform.Find("Pillar (1)").gameObject;
                Object.Destroy(gameObject2);
                GameObject gameObject3 = obj.transform.Find("Pillar (2)").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = obj.transform.Find("Pillar (3)").gameObject;
                Object.Destroy(gameObject4);
                PrecursorActivatedPillar component = gameObject.transform.Find("Precursor_prison_exterior_box_01_animated_blue(Clone)").gameObject.transform.GetComponent<PrecursorActivatedPillar>();
                component.lightIntensity = 0.5f;
                PrecursorActivatedPillar component2 = gameObject.transform.Find("Precursor_prison_exterior_box_01_animated_blue(Clone) (1)").gameObject.transform.GetComponent<PrecursorActivatedPillar>();
                component2.lightIntensity = 0.5f;

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