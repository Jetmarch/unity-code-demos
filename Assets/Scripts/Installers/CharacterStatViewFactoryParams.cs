using System;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace OtusUnityHomework.Installers
{
    [Serializable]
    public struct CharacterStatViewFactoryParams
    {
        public GameObject CharacterStatPrefab;
        public GameObject CharacterStatsContainer;
    }
}