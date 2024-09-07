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

        public override void Add(int value)
        {
            base.Add(value);
            Changed?.Invoke(_resourceValue.ToString());
        }

        public void SpendMoney(int value)
        {
            _resourceValue -= value;
            Changed?.Invoke(_resourceValue.ToString());
        }
    }
}
