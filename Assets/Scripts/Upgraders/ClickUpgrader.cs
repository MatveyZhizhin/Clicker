
namespace Assets.Scripts.Upgraders
{
    public class ClickUpgrader : Upgrader
    {
        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            _sword.ResourceByClick += _upgradeValue;
        }
    }
}
