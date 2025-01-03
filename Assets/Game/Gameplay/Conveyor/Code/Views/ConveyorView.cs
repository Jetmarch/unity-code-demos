using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace Game.Gameplay.Conveyor
{
    public class ConveyorView : MonoBehaviour
    {
        [SerializeField] private GameObject _inputZone;
        [SerializeField] private GameObject _workZone;
        [SerializeField] private GameObject _outputZone;

        [SerializeField] private float _scaleDuration = 0.25f;
        [SerializeField] private Vector3 _scaleVector = new Vector3(0f, 0.25f, 0f);

        private Tween _workZoneTween;
        private Conveyor _conveyor;
        
        [Inject]
        private void Configure(Conveyor conveyor)
        {
            _conveyor = conveyor;
        }

        private void Start()
        {
            DOTween.Init();
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
            Debug.Log("START CONVERT");

            _workZoneTween?.Kill();
            _workZoneTween = _workZone.transform.DOPunchScale(_scaleVector, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
        }
        
        private void ConveyorOnFinishConvert()
        {
            Debug.Log("FINISH CONVERT");
            _workZoneTween?.Kill();
        }
        
        private void ConveyorOnAddResourceToInput()
        {
            Debug.Log("Add resource to INPUT");
            _inputZone.transform.DOScale(_inputZone.transform.localScale + _scaleVector, _scaleDuration);
        }
        
        private void ConveyorOnAddResourceToOutput()
        {
            Debug.Log("Add resource to OUTPUT");
            _outputZone.transform.DOScale(_outputZone.transform.localScale + _scaleVector, _scaleDuration);
        }
        
        private void ConveyorOnRemoveResourceFromInput()
        {
            Debug.Log("Remove resource from INPUT");
            _inputZone.transform.DOScale(_inputZone.transform.localScale - _scaleVector, _scaleDuration);
        }
        
        private void ConveyorOnRemoveResourceFromOutput()
        {
            Debug.Log("Remove resource from OUTPUT");
            _outputZone.transform.DOScale(_outputZone.transform.localScale - _scaleVector, _scaleDuration);
        }
    }
}
