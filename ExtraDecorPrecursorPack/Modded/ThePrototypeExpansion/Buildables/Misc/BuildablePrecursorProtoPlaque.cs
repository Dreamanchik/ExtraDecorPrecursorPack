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

namespace ExtraDecorPrecursorPack.Modded.Buildables.Misc
{
    public static class BuildablePrecursorProtoPlaque
    {
        static string ID = "BuildablePrecursorProtoPlaque";
        public static string iconPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Assets",
            "Vanilla",
            "Buildables",
            ID);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(ID, "Precursor Plaque", "Precursor decorative plaque with a logo.");

        public static void Register()
        {
            float PlaceDistance = 10f;
            float MinPlaceDistance = 0f;
            float MaxPlaceDistance = 20f;

            var prefab = new CustomPrefab(Info);

            var clone = new CloneTemplate(Info, "ProtoPlaque");
            clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.Rotatable | ConstructableFlags.Outside | ConstructableFlags.AllowedOnConstructable;

                GameObject gameObject = obj.transform.Find("Model").gameObject;
                gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
                gameObject.transform.localEulerAngles = new Vector3(270f, 180f, 0f);
                GameObject gameObject2 = obj.transform.Find("Collider").gameObject;
                gameObject2.transform.localPosition = new Vector3(0f, 0f, 0.5f);
                gameObject2.transform.localEulerAngles = new Vector3(270f, 180f, 0f);

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