using Assets.Scripts.Game;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.FloatingText
{
    public class MainButtonFloatingText : FloatingText
    {
        private MainButton _mainButton;

        private void Awake()
        {
            _mainButton = FindObjectOfType<MainButton>();
        }

        protected override void SpawnFloatingText(long value)
        {
            var newText = Instantiate(_text, Camera.main.ScreenToWorldPoint(Input.mousePosition), _text.transform.rotation);
            newText.GetComponentInChildren<TextMeshProUGUI>().SetText(_prefix + StringParser.ParseFloatToShortString(value, 1));
            Destroy(newText, _lifeTime);
        }

        private void OnEnable()
        {
            _mainButton.Clicked += SpawnFloatingText;
        }

        private void OnDisable()
        {
            _mainButton.Clicked -= SpawnFloatingText;
        }
    }
}
