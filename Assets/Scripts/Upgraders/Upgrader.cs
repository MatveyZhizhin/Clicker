using Assets.Scripts.Game;
using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Upgraders
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] protected int _cost;
        [SerializeField] protected int _upgradeValue;

        protected Money _money;
        protected MainButton _mainButton;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
            _mainButton = FindObjectOfType<MainButton>();
        }

        public virtual void Upgrade()
        {
            _money.SpendMoney(_cost);
        }
    }
}
