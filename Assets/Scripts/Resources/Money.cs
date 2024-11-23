using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Money : Resource, ITextUser
    {
        public event Action<string> Changed;

        public bool HasMoney(int value) => _resourceValue >= value;

        private void Start()
        {
            Changed?.Invoke(_resourceValue.ToString());
        }

        public override void Add(long value)
        {
            base.Add(value);
            Changed?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1));
        }

        public void SpendMoney(long value)
        {
            _resourceValue -= value;
            Changed?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1));
        }
    }
}
