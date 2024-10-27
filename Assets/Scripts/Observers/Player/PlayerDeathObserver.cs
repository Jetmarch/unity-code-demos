using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerDeathObserver : IGameStartListener, IGameFinishListener
    {
        private readonly HitPointsComponent _hitPointsComponent;

        private readonly GameManager _gameManager;

        public PlayerDeathObserver(HitPointsComponent hitPointsComponent, GameManager gameManager)
        {
            _hitPointsComponent = hitPointsComponent;
            _gameManager = gameManager;
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