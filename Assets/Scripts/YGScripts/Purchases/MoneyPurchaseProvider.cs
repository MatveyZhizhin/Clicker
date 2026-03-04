using Assets.Scripts.Resources;
using YG;
using UnityEngine;

namespace Assets.Scripts.YGScripts.Purchases
{
    public class MoneyPurchaseProvider : MonoBehaviour
    {
        private Money _money;
        private SaveService _saveService;

        private void Awake()
        {
            _money = FindObjectOfType<Money>();     
            _saveService = FindObjectOfType<SaveService>();
        }

        protected void Purchase(string id)
        {
            _money.Add(long.Parse(id), true);
            _saveService.Save();
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
