using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Money : Resource, ITextUser
    {
        public event Action<string> TextChanged;
        public event Action<long> MoneyChanged;

        public bool HasMoney(int value) => _resourceValue >= value;

        private void Start()
        {
            TextChanged?.Invoke(_resourceValue.ToString());
        }

        public override void Add(long value)
        {
            base.Add(value);
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1));
            MoneyChanged?.Invoke(_resourceValue);
        }

        public void SpendMoney(long value)
        {
            _resourceValue -= value;
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1));
            MoneyChanged?.Invoke(_resourceValue);
        }
    }
}
