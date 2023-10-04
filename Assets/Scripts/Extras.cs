using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extras
{
    [System.Serializable]
    public class CharacterData
    {
        // Identification
        public string Name = "~ Nameless ~";
        public string Class = "~ Generalist Archetype ~";

        // Visual Data
        public int SkinColor = 0xFFFFFF;
        public int HairType = 0;
        public int HairColor = 0xFFFFFF;
        public int FaceType = 1;
        public int ShirtType = 0;
        public int ShirtColor1 = 0xFFFFFF;
        public int ShirtColor2 = 0xFFFFFF;
        public int PantsType = 0;
        public int PantsColor = 0xFFFFFF;
        public int ShoesType = 0;
        public int ShoesColor = 0xFFFFFF;

        // Personality Data
        public float CourageToCaution = 0.5f;
        public float HonestyToDeception = 0.5f;
        public float DiplomacyToAggression = 0.5f;
        public float EmpathyToRuthlessness = 0.5f;
        public float OptimismToPessimism = 0.5f;
    }

    public static class HelperFunctions
    {
        /// <summary>
        /// converts integer to Color instance using bit shifting and bit masking
        /// </summary>
        public static Color IntToColor(int colorInt)
        {
            return new Color(Mathf.InverseLerp(0, 255, colorInt >> 16 & 0x0000FF),
                Mathf.InverseLerp(0, 255, colorInt >> 8 & 0x0000FF),
                Mathf.InverseLerp(0, 255, colorInt & 0x0000FF), 1);
        }
    }
}