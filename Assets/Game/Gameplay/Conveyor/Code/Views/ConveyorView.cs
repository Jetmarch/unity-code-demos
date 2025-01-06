using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorView : MonoBehaviour
    {
        [SerializeField] private GameObject _inputZone;
        [SerializeField] private GameObject _workZone;
        [SerializeField] private GameObject _outputZone;

        [SerializeField] private float _scaleDuration = 0.25f;
        [SerializeField] private Vector3 _scaleVector = new Vector3(0f, 0.25f, 0f);
        
        [SerializeField] private ConveyorTransportZoneView _inputZoneView;
        [SerializeField] private ConveyorTransportZoneView _outputZoneView;

        private Tween _workZoneTween;
        private Conveyor _conveyor;
        
        [Inject]
        private void Configure(Conveyor conveyor)
        {
            _conveyor = conveyor;
        }

        private void OnEnable()
        {
            _conveyor.OnAddResourceToInput += ConveyorOnAddResourceToInput;
            _conveyor.OnAddResourceToOutput += ConveyorOnAddResourceToOutput;
            _conveyor.OnRemoveResourceFromInput += ConveyorOnRemoveResourceFromInput;
            _conveyor.OnRemoveResourceFromOutput += ConveyorOnRemoveResourceFromOutput;
            _conveyor.OnStartConvert += ConveyorOnStartConvert;
            _conveyor.OnFinishConvert += ConveyorOnFinishConvert;
        }

        private void OnDisable()
        {
            _conveyor.OnAddResourceToInput -= ConveyorOnAddResourceToInput;
            _conveyor.OnAddResourceToOutput -= ConveyorOnAddResourceToOutput;
            _conveyor.OnRemoveResourceFromInput -= ConveyorOnRemoveResourceFromInput;
            _conveyor.OnRemoveResourceFromOutput -= ConveyorOnRemoveResourceFromOutput;
            _conveyor.OnStartConvert -= ConveyorOnStartConvert;
            _conveyor.OnFinishConvert -= ConveyorOnFinishConvert;
        }

        private void ConveyorOnStartConvert()
        {
            _workZoneTween?.Kill();
            _workZoneTween = _workZone.transform.DOPunchScale(_scaleVector, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
        }
        
        private void ConveyorOnFinishConvert()
        {
            _workZoneTween?.Kill();
            _workZone.transform.localScale = Vector3.one;
        }
        
        private void ConveyorOnAddResourceToInput()
        {
            _inputZoneView.AddResource();
        }
        
        private void ConveyorOnAddResourceToOutput()
        {
            _outputZoneView.AddResource();
        }
        
        private void ConveyorOnRemoveResourceFromInput()
        {
            _inputZoneView.RemoveResource();
        }
        
        private void ConveyorOnRemoveResourceFromOutput()
        {
            _outputZoneView.RemoveResource();
        }
    }
}
