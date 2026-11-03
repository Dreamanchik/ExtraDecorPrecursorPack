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
    public static class BuildablePrecursorActivatedPillar4
    {
        static string ID = "BuildablePrecursorActivatedPillar4";
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

                GameObject gameObject = obj.transform.Find("Geometry").gameObject;
                GameObject gameObject2 = gameObject.transform.Find("precursor_doorway_05 (2)").gameObject;
                Object.Destroy(gameObject2);
                GameObject gameObject3 = gameObject.transform.Find("precursor_doorway_01 (6)").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = gameObject.transform.Find("precursor_block_L_stripe_04_04_08_v2 (1)").gameObject;
                Object.Destroy(gameObject4);
                GameObject gameObject5 = gameObject.transform.Find("precursor_block_L_stripe_04_04_08_v2 (2)").gameObject;
                Object.Destroy(gameObject5);
                GameObject gameObject6 = gameObject.transform.Find("precursor_block_solid_04_08_04 (1)").gameObject;
                Object.Destroy(gameObject6);
                GameObject gameObject7 = obj.transform.Find("Precursor_prison_exterior_box_01_animated_blue(Placeholder)").gameObject;
                gameObject7.transform.parent = gameObject.transform;
                GameObject gameObject8 = obj.transform.Find("Collision").gameObject;
                gameObject8.transform.parent = gameObject.transform;
                GameObject gameObject9 = obj.transform.Find("Collision (1)").gameObject;
                gameObject9.transform.parent = gameObject.transform;
                GameObject gameObject10 = obj.transform.Find("Collision (2)").gameObject;
                gameObject10.transform.parent = gameObject.transform;
                GameObject gameObject11 = obj.transform.Find("Collision (3)").gameObject;
                gameObject11.transform.parent = gameObject.transform;
                gameObject.transform.localPosition = new Vector3(-12.7f, -4.2f, 6.8f);
                SkyApplier component = gameObject.GetComponent<SkyApplier>();
                component.anchorSky = Skies.BaseInterior;

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