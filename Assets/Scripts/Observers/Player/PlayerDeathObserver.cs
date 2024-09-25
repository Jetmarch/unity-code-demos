using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _hitPointsComponent.OnDeath += CharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.OnDeath -= CharacterDeath;
        }

        private void CharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}