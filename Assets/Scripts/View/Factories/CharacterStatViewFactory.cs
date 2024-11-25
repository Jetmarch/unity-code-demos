using System;
using OtusUnityHomework.Installers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OtusUnityHomework.View
{
    public sealed class CharacterStatViewFactory
    {
        private readonly GameObject _playerStatPrefab;
        private readonly GameObject _playerStatsContainer;
        public CharacterStatViewFactory(CharacterStatViewFactoryParams factoryParams)
        {
            _playerStatPrefab = factoryParams.CharacterStatPrefab;
            _playerStatsContainer = factoryParams.CharacterStatsContainer;
        }
        
        public CharacterStatView Create()
        {
            var newStatView = Object.Instantiate(_playerStatPrefab, _playerStatsContainer.transform).GetComponent<CharacterStatView>();
            if (newStatView == null)
            {
                throw new ApplicationException("PlayerStatView prefab does not contain PlayerStatView component");
            }
            
            return newStatView;
        }
    }
}