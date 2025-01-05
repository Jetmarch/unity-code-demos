using System.Collections.Generic;

namespace Game.Meta.Upgrades.Presenters
{
    public interface IUpgradeListPresenter
    {
        List<IUpgradePresenter> GetUpgradePresenters();
    }
}