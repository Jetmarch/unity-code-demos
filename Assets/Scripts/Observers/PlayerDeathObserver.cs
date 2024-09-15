using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField]
        private HitPointsComponent _characterController;

        [SerializeField]
        private GameManager _gameManager;

        private void OnEnable()
        {
            _characterController.hpEmpty += CharacterDeath;
        }

        private void OnDisable()
        {
            _characterController.hpEmpty -= CharacterDeath;
        }

        private void CharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}