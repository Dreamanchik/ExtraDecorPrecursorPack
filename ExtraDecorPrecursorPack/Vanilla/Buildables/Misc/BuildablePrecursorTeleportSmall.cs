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
    public static class BuildablePrecursorTeleportSmall
    {
        static string ID = "BuildablePrecursorTeleportSmall";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Teleport Small", "Ancient precursor miniature teleport. Active, but malfunctional.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "1a3be11a-6bf4-425a-ac96-850d9268b016");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Meshes").gameObject;
                GameObject gameObject2 = obj.transform.Find("Cinematic").gameObject;
                Object.Destroy(gameObject2);
                GameObject gameObject3 = obj.transform.Find("WarpCollider").gameObject;
                Object.Destroy(gameObject3);
                GameObject gameObject4 = obj.transform.Find("WarpToPoint").gameObject;
                Object.Destroy(gameObject4);
                GameObject gameObject5 = obj.transform.Find("SeaEmperorBabiesSpawner(Placeholder)").gameObject;
                Object.Destroy(gameObject5);
                GameObject gameObject6 = obj.transform.Find("DenyBuilding").gameObject;
                Object.Destroy(gameObject6);
                ConstructionObstacle component = obj.GetComponent<ConstructionObstacle>();
                Object.Destroy(component);
                PrecursorTeleporter component2 = obj.GetComponent<PrecursorTeleporter>();
                component2.alwaysOn = true;
                component2.isOpen = true;
                component2.StartCoroutine("Start");
                GameObject gameObject7 = obj.transform.Find("Colliders").gameObject;
                gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                gameObject7.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                GameObject gameObject8 = obj.transform.Find("FXspawnPoint").gameObject;
                gameObject8.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                gameObject8.transform.localPosition = new Vector3(0f, 1.2f, 0f);

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