using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorController : MonoBehaviour
    {
        [SerializeField] private ConveyorTransportZone _input;
        [SerializeField] private ConveyorTransportZone _output;
        [SerializeField] private ConveyorAttributes _attributes; 
        
    }
}
