using DG.Tweening;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorWorkZoneView : MonoBehaviour
    {
        [SerializeField] private GameObject _workZone;
        [SerializeField] private float _scaleDuration = 0.25f;
        [SerializeField] private Vector3 _scaleVector = new Vector3(0f, 0.25f, 0f);
        
        private Tween _workZoneTween;
        public void StartWork()
        {
            _workZoneTween?.Kill();
            _workZoneTween = _workZone.transform.DOPunchScale(_scaleVector, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
        }

        public void StopWork()
        {
            _workZoneTween?.Kill();
            _workZone.transform.localScale = Vector3.one;
        }
    }
}