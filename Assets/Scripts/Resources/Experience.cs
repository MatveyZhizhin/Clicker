using Assets.Scripts.Game;
using System;

namespace Assets.Scripts.Resources
{
    public class Experience : Resource
    {
        public event Action<float> ExperienceChanged;

        private LevelChanger _levelChanger;

        private void Awake()
        {
            _levelChanger = FindObjectOfType<LevelChanger>();
        }

        private void Start()
        {
            ExperienceChanged?.Invoke(_resourceValue);
        }

        public override void Add(long value)
        {
            base.Add(value);
            if (_resourceValue >= _levelChanger.MaxExperience)
                _levelChanger.ChangeLevel(ref _resourceValue);
            ExperienceChanged?.Invoke(_resourceValue);
        }
    }
}
