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
        protected Sword _sword;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
            _sword = FindObjectOfType<Sword>();
        }

        public virtual void Upgrade()
        {
            _money.SpendMoney(_cost);
        }
    }
}
