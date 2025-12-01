using Assets.Scripts.Resources;
using Assets.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainButton: MonoBehaviour
    {
        [field: SerializeField] public long MoneyByClick { get; set; }
        [field: SerializeField] public long MoneyByAutoClick { get; set;}

        [field: SerializeField] public long ExperienceByClick { get; set; }
     

        [SerializeField] private float TimeBetweenAutoClicks;

        private Experience _experience;
        private Money _money;

        public event Action<long> Clicked;

        private void Awake()
        {
            _experience = FindObjectOfType<Experience>();
            _money = FindObjectOfType<Money>();
        }

        private void Start()
        {
            StartCoroutine(AutoClick());
        }

        public void Click()
        {
            _money.Add(MoneyByClick);
            _experience.Add(ExperienceByClick);
            if (_money.IsDoubled)
            {
                Clicked?.Invoke(MoneyByClick * 2);
                return;
            }
            Clicked?.Invoke(MoneyByClick);                    
        }

        private IEnumerator AutoClick()
        {
            while (true)
            {
                yield return new WaitForSeconds(TimeBetweenAutoClicks);
                _money.Add(MoneyByAutoClick);
            }
        }
    }
}
