using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Money : Resource, ITextUser
    {
        public event Action<string> TextChanged;
        public event Action<long> MoneyChanged;
        public event Action<long> MoneyDecreased;

        public bool HasMoney(long value) => _resourceValue >= value;

        private void Start()
        {
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 2));
        }

        public override void Add(long value, bool isPurchase = false)
        {
            base.Add(value, isPurchase);
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 2));
            MoneyChanged?.Invoke(_resourceValue);
        }

        public override void Remove(long value)
        {
            base.Remove(value);
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 2));
            MoneyChanged?.Invoke(_resourceValue);
            MoneyDecreased?.Invoke(value);
        }
    }
}
