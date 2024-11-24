using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Upgraders
{
    public class AutoClickUpgrader : Upgrader, ITextUser
    {
        public event Action<string> Changed;

        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            _mainButton.MoneyByAutoClick += _upgradeValue;
            Changed?.Invoke(_mainButton.MoneyByAutoClick.ToString());
        }
    }
}