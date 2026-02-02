 using Assets.Scripts.Resources;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.YGScripts
{
    public class DoublerYG : MonoBehaviour
    {
        [SerializeField] private Timer _rewardTimer;
        [SerializeField] private Timer _buttonTimer;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Image _castleImage;

        [SerializeField] private int _rewardId;

        [SerializeField] private Resource _resource;      

        private void Double(int id)
        {
            if (id != _rewardId)
                return;

            _rewardTimer.StartTimer();
            _buttonTimer.StartTimer();
            _castleImage.gameObject.SetActive(true);
            _resource.IsDoubled = true;
        }

        private void ResetValue()
        {
            _resource.IsDoubled = false;
        }

        private void Enable()
        {
            _upgradeButton.enabled = true;
        }

        private void Disable()
        {
            _upgradeButton.enabled = false;
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Double;
            _buttonTimer.Started += Disable;
            _rewardTimer.Ended += ResetValue;
            _buttonTimer.Ended += Enable;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Double;
            _buttonTimer.Started -= Disable;
            _rewardTimer.Ended -= ResetValue;
            _buttonTimer.Ended -= Enable;
        }
    }
}
