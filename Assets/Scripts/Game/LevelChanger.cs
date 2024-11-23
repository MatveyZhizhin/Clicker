using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class LevelChanger : MonoBehaviour, ITextUser
    {
        [field: SerializeField] public int MaxExperience { get; set; }

        private int _currentLevel = 1;

        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }

        [SerializeField] private float _maxExperienceMultiplier;
        [SerializeField] protected int _additionalExperience;

        [SerializeField] private Image[] _images;
        [SerializeField] private Image _currentImage;

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_currentLevel.ToString());
            if (_currentLevel >= _images.Length)
            {
                Changed?.Invoke("Максимальный уровень");
                return;
            }
            //_currentImage.sprite = _images[_currentLevel].sprite;
        }

        public void ChangeLevel(ref long experience)
        {          
            _currentLevel++;
            if (_currentLevel >= _images.Length)
            {
                Changed?.Invoke("Максимальный уровень");
                return;
            }
            Changed?.Invoke(_currentLevel.ToString());
            experience = 0;
            var newExperience = MaxExperience * _maxExperienceMultiplier + _additionalExperience;
            MaxExperience = Mathf.RoundToInt(newExperience);
            //_currentImage.sprite = _images[_currentLevel - 1].sprite;          
        }
    }
}
