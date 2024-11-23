using Assets.Scripts.Resources;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainButton: MonoBehaviour
    {
        [field: SerializeField] public int ResourceByClick { get; set; }
        [field: SerializeField] public int MoneyByAutoClick { get; set; }

        [SerializeField] private float TimeBetweenAutoClicks;

        private Experience _experience;
        private Money _money;
        private SaveService _saveService;

        private void Awake()
        {
            _experience = FindObjectOfType<Experience>();
            _money = FindObjectOfType<Money>();
            _saveService = FindObjectOfType<SaveService>();
        }

        private void Start()
        {
            StartCoroutine(AutoClick());
        }

        public void Click()
        {
            _money.Add(ResourceByClick);
            _experience.Add(ResourceByClick);
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
