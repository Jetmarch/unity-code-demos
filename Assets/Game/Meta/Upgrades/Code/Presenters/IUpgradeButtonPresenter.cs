using System;

namespace Game.Meta.Upgrades.Presenters
{
    public interface IUpgradeButtonPresenter
    {
        string Price { get; }
        bool CanLevelUp { get; }
        bool CanBuy { get; }
        void LevelUp();
        event Action OnMoneyChanged;
    }
}