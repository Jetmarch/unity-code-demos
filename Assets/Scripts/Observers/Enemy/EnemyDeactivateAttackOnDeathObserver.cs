using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyDeactivateAttackOnDeathObserver : MonoBehaviour//, IGameStartListener, IGameFinishListener
    {
        //[SerializeField] private EnemyAttackAgent _attackAgent;

        //[SerializeField] private HitPointsComponent _hpComponent;

        //private void Start()
        //{
        //    IGameListener.Register(this);
        //}

        //public void OnStart()
        //{
        //    _hpComponent.OnDeath += OnHpEmpty;
        //}

        //public void OnFinish()
        //{
        //    _hpComponent.OnDeath -= OnHpEmpty;
        //}

        //private void OnHpEmpty(GameObject _)
        //{
        //    _attackAgent.Deactivate();
        //}
    }
}