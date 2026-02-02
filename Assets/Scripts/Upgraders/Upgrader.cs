using Assets.Scripts.Game;
using Assets.Scripts.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Upgraders
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] protected long _cost;
        [SerializeField] protected long _upgradeValue;

        [field: SerializeField] public bool IsUnlocked { get; set; }

        [SerializeField] private Image _lockedButtonImage;
        [SerializeField] private AudioSource _purchaseSound;

        public long Cost => _cost;

        protected Money _money;
        protected MainButton _mainButton;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
            _mainButton = FindObjectOfType<MainButton>();
        }

        private void Start()
        {
            if (IsUnlocked)
            {
                UnlockButton();
            }
        }

        public virtual void Upgrade()
        {
            _money.Remove(_cost);
            _purchaseSound.Play();
        }

        public void UnlockButton()
        {
            this.GetComponent<Button>().enabled = true;
            _lockedButtonImage.gameObject.SetActive(false);
            IsUnlocked = true;
        }
    }
}
