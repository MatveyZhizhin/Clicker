using UnityEngine;

namespace Assets.Scripts.Upgraders
{
    public class ClickUpgrader : Upgrader
    {
        [SerializeField] private bool _isExperienceUpgrader;

        private void Start()
        {
            if (IsUnlocked)
            {
                UnlockButton();
            }
        }

        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            if (_isExperienceUpgrader)
            {
                _mainButton.ExperienceByClick += _upgradeValue;
            }
            else
            {
                _mainButton.MoneyByClick += _upgradeValue;
            }            
        }
    }
}
