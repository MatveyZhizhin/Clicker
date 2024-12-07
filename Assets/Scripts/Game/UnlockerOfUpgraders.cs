using Assets.Scripts.Resources;
using Assets.Scripts.Upgraders;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class UnlockerOfUpgraders : MonoBehaviour
    {
        [SerializeField] private Upgrader[] _upgraders;

        private Money _money;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
        }

        private void CheckBalance(long money)
        {
            for (int i = 0; i < _upgraders.Length - 1; i++)
            {
                if (money >= _upgraders[i].Cost)
                {
                    if (_upgraders[i + 1].IsUnlocked)
                        continue;

                    _upgraders[i + 1].UnlockButton();
                }
            }
        }

        private void OnEnable()
        {
            _money.MoneyChanged += CheckBalance;
        }

        private void OnDisable()
        {
            _money.MoneyChanged -= CheckBalance;
        }
    }
}
