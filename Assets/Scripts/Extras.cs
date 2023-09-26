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
        public int HairType = 0;
        public int HairColor = 0xFFFFFF;
        public int FaceType = 0;
        public int FaceColor = 0xFFFFFF;
        public int ShirtType = 0;
        public int ShirtColor = 0xFFFFFF;
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
}