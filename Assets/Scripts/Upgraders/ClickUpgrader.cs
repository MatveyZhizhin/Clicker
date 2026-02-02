using UnityEngine;

namespace Assets.Scripts.Upgraders
{
    public class DamageUpgrader : Upgrader
    {

        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            _mainButton.HealthByClick += _upgradeValue;
        }
    }
}
