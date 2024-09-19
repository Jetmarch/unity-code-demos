using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent _characterController;

        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _characterController.HpEmpty += CharacterDeath;
        }

        private void OnDisable()
        {
            _characterController.HpEmpty -= CharacterDeath;
        }

        private void CharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}