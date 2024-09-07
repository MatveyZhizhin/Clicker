
namespace Assets.Scripts.Upgraders
{
    public class AutoClickUpgrader : Upgrader
    {
        public override void Upgrade()
        {
            if (!_money.HasMoney(_cost))
                return;
            base.Upgrade();
            _sword.MoneyByAutoClick += _upgradeValue;
        }
    }
}