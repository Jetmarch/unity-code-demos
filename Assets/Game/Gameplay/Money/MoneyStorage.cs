using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Money
{
    [Serializable]
    public class MoneyStorage
    {
        public event Action OnAmountChanged;
        public int Amount => _amount;
        
        [ShowInInspector, ReadOnly] 
        private int _amount;

        [ShowInInspector] 
        private int _maxAmount = int.MaxValue;
        
        [Button]
        public void SetAmount(int amount)
        {
            _amount = Mathf.Clamp(amount, 0, _maxAmount);
            OnAmountChanged?.Invoke();
        }

        [Button]
        public void Get(int amount)
        {
            _amount = Mathf.Clamp(_amount - amount, 0, _maxAmount);
        }

        [Button]
        public void Add(int amount)
        {
            try
            {
                checked
                {
                    _amount = Mathf.Clamp(_amount + amount, 0, _maxAmount);
                }
            }
            catch (OverflowException)
            {
                Debug.LogWarning("Trying to add more money than int32 max amount");
            }
        }
    }
}
