using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Reward : Resource, ITextUser
    {
        public event Action<string> TextChanged;

        private void Start()
        {
            TextChanged?.Invoke("Награда: " + StringParser.ParseFloatToShortString(_resourceValue, 2));
        }

        public override void Add(long value, bool isPurchase)
        {
            _resourceValue = value;
            TextChanged?.Invoke("Награда: " + StringParser.ParseFloatToShortString(_resourceValue, 2));
        }
    }
}