using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.AnimatorsConstans;

namespace Assets.Scripts.Game
{
    public class LevelChanger : MonoBehaviour, ITextUser
    {
        [field: SerializeField] public int MaxExperience { get; set; }

        private int _currentLevel = 1;

        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public bool IsMaxLevel => _currentLevel > _images.Length;

        [SerializeField] private float _maxExperienceMultiplier;
        [SerializeField] protected int _additionalExperience;

        [SerializeField] private Sprite[] _images;
        [SerializeField] private Image _currentImage;
        [SerializeField] private Animator _levelChangerAnimator;

        public event Action<string> TextChanged;

        private void Start()
        {
            TextChanged?.Invoke("Уровень: " + _currentLevel.ToString());
            if (IsMaxLevel)
            {
                TextChanged?.Invoke("Максимальный уровень");
                _currentImage.sprite = _images[_images.Length - 1];
                return;
            }
            _currentImage.sprite = _images[_currentLevel - 1];
        }

        public void ChangeLevel(ref long experience)
        {
            _currentLevel++;
            if (IsMaxLevel)
            {
                TextChanged?.Invoke("Максимальный уровень");
                return;
            }
            TextChanged?.Invoke("Уровень: " + _currentLevel.ToString());
            experience = 0;
            var newExperience = MaxExperience * _maxExperienceMultiplier + _additionalExperience;
            MaxExperience = Mathf.RoundToInt(newExperience);
            _levelChangerAnimator.SetTrigger(LevelChangerAnimationConstans.LevelChanged);           
        }

        public void ChangeMainButtonSprite()
        {
            _currentImage.sprite = _images[_currentLevel - 1];
        }
    }
}
