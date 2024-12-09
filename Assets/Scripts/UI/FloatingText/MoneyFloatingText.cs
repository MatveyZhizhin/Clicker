using Assets.Scripts.Game;
using Assets.Scripts.Resources;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.FloatingText
{
    public class MoneyFloatingText : FloatingText
    {
        private Money _money;

        [SerializeField] private Transform _spawnPoint;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
        }

        protected override void SpawnFloatingText(long value)
        {
            var newText = Instantiate(_text, _spawnPoint.position, _text.transform.rotation);
            newText.GetComponentInChildren<TextMeshProUGUI>().SetText(_prefix + StringParser.ParseFloatToShortString(value, 1));
            Destroy(newText, _lifeTime);
        }

        private void OnEnable()
        {
            _money.MoneyDecreased += SpawnFloatingText;
        }

        private void OnDisable()
        {
            _money.MoneyDecreased -= SpawnFloatingText;
        }
    }
}
