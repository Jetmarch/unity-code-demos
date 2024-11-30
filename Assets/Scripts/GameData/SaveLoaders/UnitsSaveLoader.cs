using System.Collections.Generic;
using GameEngine;
using UnityEngine;
// ReSharper disable ClassNeverInstantiated.Global

namespace HomeworkSaveLoad.SaveSystem.SaveLoaders
{
    public sealed class UnitData
    {
        public string Name;
        public string Type;
        public int HitPoints;
        public Vector3 Position;
        public Vector3 Rotation;
    }
    
    public sealed class UnitsSaveLoader : SaveLoader<IEnumerable<UnitData>, UnitManager>
    {
        private const string UnitPrefabPath = "Prefabs/UnitObjects/"; 
        
        protected override void SetupData(UnitManager service, IEnumerable<UnitData> data)
        {
            var units = service.GetAllUnits();

            foreach (var unitData in data)
            {
                bool isCreated = false;
                foreach (var unit in units)
                {
                    if (unit.name == unitData.Name)
                    {
                        SetupUnit(unit, unitData);
                        isCreated = true;
                    }
                }

                if (!isCreated)
                {
                    var prefab = Resources.Load<Unit>(UnitPrefabPath + unitData.Type);
                    var createdUnit = service.SpawnUnit(prefab, unitData.Position, Quaternion.Euler(unitData.Rotation));
                    SetupUnit(createdUnit, unitData);
                }
            }
        }

        private void SetupUnit(Unit unit, UnitData data)
        {
            unit.name = data.Name;
            unit.HitPoints = data.HitPoints;
            unit.transform.position = data.Position;
            unit.transform.rotation = Quaternion.Euler(data.Rotation);
        }

        protected override IEnumerable<UnitData> ConvertToData(UnitManager service)
        {
            return CreateUnitsData(service);
        }

        private IEnumerable<UnitData> CreateUnitsData(UnitManager service)
        {
            var units = service.GetAllUnits();
            var unitsData = new List<UnitData>();
            foreach (var unit in units)
            {
                var unitData = new UnitData()
                {
                    Name = unit.name,
                    Type = unit.Type,
                    HitPoints = unit.HitPoints,
                    Position = unit.Position,
                    Rotation = unit.Rotation
                };
                
                unitsData.Add(unitData);
            }
            
            return unitsData;
        }
    }
}