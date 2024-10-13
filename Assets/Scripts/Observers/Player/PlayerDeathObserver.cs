using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerDeathObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        [SerializeField] private GameManager _gameManager;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStart()
        {
            _hitPointsComponent.OnDeath += CharacterDeath;
        }

        public void OnFinish()
        {
            _hitPointsComponent.OnDeath -= CharacterDeath;
        }

        private void CharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}