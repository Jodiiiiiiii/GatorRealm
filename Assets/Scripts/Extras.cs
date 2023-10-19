using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extras
{
    [System.Serializable]
    public class CharacterData
    {
        // Identification
        public string Name;
        public int Archetype;
        public string Class;

        // Visual Data
        public int SkinColor;
        public int HairType;
        public int HairColor;
        public int FaceType;
        public int ShirtType;
        public int ShirtColor1;
        public int ShirtColor2;
        public int PantsType;
        public int PantsColor;
        public int ShoesType;
        public int ShoesColor;

        // Personality Data
        public float CourageToCaution;
        public float HonestyToDeception;
        public float DiplomacyToAggression;
        public float EmpathyToRuthlessness;
        public float OptimismToPessimism;
        public float MysticismToSkepticism;

        public CharacterData()
        {
            // Identification
            Name = "~ Nameless ~";
            Archetype = 0;
            Class = "";

            // Visual Data
            SkinColor = 0xFFFFFF;
            HairType = 0;
            HairColor = 0xFFFFFF;
            FaceType = 1;
            ShirtType = 0;
            ShirtColor1 = 0xFFFFFF;
            ShirtColor2 = 0xFFFFFF;
            PantsType = 0;
            PantsColor = 0xFFFFFF;
            ShoesType = 0;
            ShoesColor = 0xFFFFFF;
    
            // Personality Data
            CourageToCaution = 0.5f;
            HonestyToDeception = 0.5f;
            DiplomacyToAggression = 0.5f;
            EmpathyToRuthlessness = 0.5f;
            OptimismToPessimism = 0.5f;
            MysticismToSkepticism = 0.5f;
        }
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

        public static int ColorToInt(Color color)
        {
            return (int)(color.r * 255) << 16 | (int)(color.g * 255) << 8 | (int)(color.b * 255);
        }
    }
}