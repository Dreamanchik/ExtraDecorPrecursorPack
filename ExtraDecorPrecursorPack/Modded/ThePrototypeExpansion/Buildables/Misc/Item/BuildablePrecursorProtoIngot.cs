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

namespace ExtraDecorPrecursorPack.Modded.Buildables.Misc.Item
{
    public static class BuildablePrecursorProtoIngot
    {
        static string ID = "BuildablePrecursorProtoIngot";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Ingot", "Ancient precursor resource of unknown use.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "IonPrism");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Model").gameObject;
                Object.Destroy(obj.GetComponent<Pickupable>());
                Rigidbody component = obj.GetComponent<Rigidbody>();
                component.useGravity = false;
                component.isKinematic = true;
                gameObject.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                GameObject gameObject2 = obj.transform.Find("Collider").gameObject;
                gameObject2.transform.localPosition = new Vector3(0f, 0.5f, 0f);

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