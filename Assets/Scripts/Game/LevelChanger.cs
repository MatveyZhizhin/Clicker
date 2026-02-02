using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.AnimatorsConstans;
using Assets.Scripts.Resources;

namespace Assets.Scripts.Game
{
    public class LevelChanger : MonoBehaviour, ITextUser
    {
        [field: SerializeField] public long StartHealth { get; set; }
        [field: SerializeField] public long StartReward { get; set; }

        private int _currentLevel = 1;
        private int _currentIndex = 0;
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public bool IsMaxLevel => _currentIndex > _images.Length - 1;
        public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }

        [SerializeField] private float _maxHealthMultiplier;
        [SerializeField] private int _additionalHealth;
        [SerializeField] private float _rewardMultiplier;
        [SerializeField] private int _additionalReward;


        [SerializeField] private Sprite[] _images;
        [SerializeField] private Image _currentImage;
        [SerializeField] private Animator _levelChangerAnimator;

        public event Action<string> TextChanged;

        private Reward _reward;
        private Money _money;

        private void Awake()
        {
            _reward = FindObjectOfType<Reward>();
            _money = FindObjectOfType<Money>();
        }

        private void Start()
        {
            TextChanged?.Invoke("Уровень: " + _currentLevel.ToString());
            _currentImage.sprite = _images[_currentIndex];
            _reward.Add(StartReward, false);
        }

        public void ChangeLevel(ref long health)
        {
            _currentLevel++;
            _currentIndex++;
            _money.Add(_reward.ResourcesValue);

            if (IsMaxLevel)
            {
                _currentIndex = 0;
            }
            TextChanged?.Invoke("Уровень: " + _currentLevel.ToString());
            var newHealth = StartHealth * _maxHealthMultiplier + _additionalHealth;
            var newReward = StartReward * _rewardMultiplier + _additionalReward;
            StartHealth = (long)newHealth; 
            StartReward = (long)newReward;
            _reward.Add(StartReward, false);
            health = StartHealth;
            _levelChangerAnimator.SetTrigger(LevelChangerAnimationConstans.LevelChanged);           
        }

        public void ChangeMainButtonSprite()
        {
            _currentImage.sprite = _images[_currentIndex];
        }
    }
}
