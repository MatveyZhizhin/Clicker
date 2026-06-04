using YG;
using UnityEngine;
using Assets.Scripts.Resources;

namespace Purchases
{
    public class MoneyPurchaseProvider : MonoBehaviour
    {
        private Money _balance;

        private void Awake()
        {
            _balance = FindObjectOfType<Money>();    
        }

        protected void Purchase(string id)
        {     
            if (int.Parse(id) < 100) return;

            _balance.Add(int.Parse(id));
        }

        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += Purchase;
        }
        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= Purchase;
        }
    }
}
