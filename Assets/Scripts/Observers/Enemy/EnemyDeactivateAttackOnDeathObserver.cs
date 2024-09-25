using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyDeactivateAttackOnDeathObserver : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent _attackAgent;

        [SerializeField] private HitPointsComponent _hpComponent;

        private void OnEnable()
        {
            _hpComponent.OnDeath += OnHpEmpty;
        }

        private void OnDisable()
        {
            _hpComponent.OnDeath -= OnHpEmpty;
        }

        private void OnHpEmpty(GameObject _)
        {
            _attackAgent.Deactivate();
        }

    }
}