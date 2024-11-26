using GameEngine;
using UnityEngine;

//TODO: Удалить этот класс!
//Развернуть архитектуру на Zenject/VContainer/Custom
public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField] private UnitManager _unitManager;

    [SerializeField] private ResourceService _resourceService;
    
    private void Start()
    {
        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
        _resourceService.SetResources(FindObjectsOfType<Resource>());
    }
}