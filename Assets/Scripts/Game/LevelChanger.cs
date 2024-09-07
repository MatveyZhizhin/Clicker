using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class LevelChanger : MonoBehaviour, ITextUser
    {
        [field: SerializeField] public int MaxExperience { get; set; }

        [SerializeField] private int _currentLevel = 1;
        [SerializeField] private float _maxExperienceMultiplier;
        [SerializeField] protected int _additionalExperience;

        [SerializeField] private Image[] _swords;
        [SerializeField] private Image _currentSword;

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_currentLevel.ToString());
        }

        public void ChangeLevel(ref int experience)
        {
            _currentLevel++;
            Changed?.Invoke(_currentLevel.ToString());
            experience = 0;
            var newExperience = MaxExperience * _maxExperienceMultiplier + _additionalExperience;
            MaxExperience = Mathf.RoundToInt(newExperience);
            //_currentSword.sprite = _swords[_currentLevel - 1].sprite;
        }
    }
}
