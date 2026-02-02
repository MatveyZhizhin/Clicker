using Assets.Scripts.UI;
using System;
using Assets.Scripts.Game;

namespace Assets.Scripts.Upgraders
{
    public class AutoClickUpgrader : Upgrader, ITextUser
    {
        public event Action<string> TextChanged;


        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            _mainButton.MoneyByAutoClick += _upgradeValue;
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_mainButton.MoneyByAutoClick, 1));
        }
    }
}