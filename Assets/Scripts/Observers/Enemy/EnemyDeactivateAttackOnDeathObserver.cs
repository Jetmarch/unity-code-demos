using UnityEngine;

namespace ShootEmUp
{
    public class EnemyDeactivateAttackOnDeathObserver : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent _attackAgent;
        [SerializeField] private HitPointsComponent _hpComponent;

        private void OnEnable()
        {
            _hpComponent.HpEmpty += OnHpEmpty;
        }

        private void OnDisable()
        {
            _hpComponent.HpEmpty -= OnHpEmpty;
        }

        private void OnHpEmpty(GameObject _)
        {
            _attackAgent.Deactivate();
        }

    }
}