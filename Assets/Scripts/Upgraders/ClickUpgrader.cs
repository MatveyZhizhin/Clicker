
namespace Assets.Scripts.Upgraders
{
    public class ClickUpgrader : Upgrader
    {
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
            _mainButton.MoneyByClick += _upgradeValue;
        }
    }
}
