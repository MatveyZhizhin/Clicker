using Assets.Scripts.Game;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Resources
{
    public class Experience : Resource, ITextUser
    {
        public event Action<float> ExperienceChanged;
        public event Action<string> TextChanged;

        private LevelChanger _levelChanger;

        private void Awake()
        {
            _levelChanger = FindObjectOfType<LevelChanger>();
        }

        private void Start()
        {
            ExperienceChanged?.Invoke(_resourceValue);
            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 2) + " / " + StringParser.ParseFloatToShortString(_levelChanger.MaxExperience, 2));
            if (_levelChanger.IsMaxLevel)
                TextChanged?.Invoke("");
        }

        public override void Add(long value, bool isPurchase = false)
        {
            base.Add(value, isPurchase);
            if (_resourceValue >= _levelChanger.MaxExperience)
            {
                _levelChanger.ChangeLevel(ref _resourceValue);               
            }
            ExperienceChanged?.Invoke(_resourceValue);

            if (_levelChanger.IsMaxLevel)
            {
                TextChanged?.Invoke("");
                return;
            }

            TextChanged?.Invoke(StringParser.ParseFloatToShortString(_resourceValue, 2) + " / " + StringParser.ParseFloatToShortString(_levelChanger.MaxExperience, 2));           
        }
    }
}
