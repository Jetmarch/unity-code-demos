using System;
using UnityEngine;
using VContainer;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorView : MonoBehaviour
    {
        [SerializeField] private ConveyorTransportZoneView _inputZoneView;
        [SerializeField] private ConveyorTransportZoneView _outputZoneView;
        [SerializeField] private ConveyorWorkZoneView _workZoneView;

        private Conveyor _conveyor;
        
        [Inject]
        private void Configure(Conveyor conveyor)
        {
            _conveyor = conveyor;
            SubscribeOnEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            _conveyor.OnAddResourceToInput += ConveyorOnAddResourceToInput;
            _conveyor.OnAddResourceToOutput += ConveyorOnAddResourceToOutput;
            _conveyor.OnRemoveResourceFromInput += ConveyorOnRemoveResourceFromInput;
            _conveyor.OnRemoveResourceFromOutput += ConveyorOnRemoveResourceFromOutput;
            _conveyor.OnStartConvert += ConveyorOnStartConvert;
            _conveyor.OnFinishConvert += ConveyorOnFinishConvert;
        }

        private void UnsubscribeOnEvents()
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
            _workZoneView.StartWork();
           
        }
        
        private void ConveyorOnFinishConvert()
        {
            _workZoneView.StopWork();
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
