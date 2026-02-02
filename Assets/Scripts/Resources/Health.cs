using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Health : Resource, ITextUser
    {
        public event Action<float> HealthChanged;
        public event Action<string> TextChanged;

        private LevelChanger _levelChanger;

        private void Awake()
        {
            _levelChanger = FindObjectOfType<LevelChanger>();
        }

        private void Start()
        {
            HealthChanged?.Invoke(_resourceValue);
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1) + " / " + StringParser.ParseFloatToShortString(_levelChanger.StartHealth, 1));
        }

        public override void Remove(long value)
        {
            if (IsDoubled)
            {
                value *= 2;
            }

            base.Remove(value);
            if (_resourceValue <= 0)
            {
                _levelChanger.ChangeLevel(ref _resourceValue);
            }
            HealthChanged?.Invoke(_resourceValue);

            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 1) + " / " + StringParser.ParseFloatToShortString(_levelChanger.StartHealth, 1));
        }
    }
}
