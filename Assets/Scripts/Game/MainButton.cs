using Assets.Scripts.Resources;
using Assets.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainButton: MonoBehaviour, ITextUser
    {
        [field: SerializeField] public long MoneyByAutoClick { get; set;}

        [field: SerializeField] public long HealthByClick { get; set; }
     

        [SerializeField] private float TimeBetweenAutoClicks;

        private Health _health;
        private Money _money;

        public event Action<long> Clicked;
        public event Action<string> TextChanged;

        private void Awake()
        {
            _health = FindObjectOfType<Health>();
            _money = FindObjectOfType<Money>();
        }

        private void Start()
        {
            StartCoroutine(AutoClick());
            TextChanged.Invoke(StringParser.ParseFloatToShortString(MoneyByAutoClick, 1));
        }

        public void Click()
        {
            _health.Remove(HealthByClick);
            if (_health.IsDoubled)
            {
                Clicked?.Invoke(HealthByClick * 2);
                return;
            }

            Clicked?.Invoke(HealthByClick);
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
