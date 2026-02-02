using Assets.Scripts.Resources;
using Assets.Scripts.Upgraders;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game;
using YG;
using System.Collections;

namespace Assets.Scripts.YGScripts
{
    public class SaveService : MonoBehaviour
    {
        private Money _money;
        private Health _health;
        private LevelChanger _levelChanger;
        private MainButton _mainButton;

        [SerializeField] private float _autoSaveInterval;
        [SerializeField] private Upgrader[] _upgraders;

        private const string YandexLeaderboardName = "Money";

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
            _health = FindObjectOfType<Health>();
            _levelChanger = FindObjectOfType<LevelChanger>();
            _mainButton = FindObjectOfType<MainButton>();
        }

        private void Start()
        {
            StartCoroutine(AutoSave());
        }

        private void Save()
        {
            if (_levelChanger.CurrentLevel > YandexGame.savesData.CurrentLevel)
            {
                YandexGame.NewLeaderboardScores(YandexLeaderboardName, _levelChanger.CurrentLevel);
            }

            YandexGame.savesData.HealthByClick = _mainButton.HealthByClick;
            YandexGame.savesData.Money = _money.ResourcesValue;
            YandexGame.savesData.Health = _health.ResourcesValue;
            YandexGame.savesData.CurrentLevel = _levelChanger.CurrentLevel;
            YandexGame.savesData.CurrentIndex = _levelChanger.CurrentIndex;
            YandexGame.savesData.StartHealth = _levelChanger.StartHealth;
            YandexGame.savesData.StartReward = _levelChanger.StartReward;
            YandexGame.savesData.MoneyByAutoClick = _mainButton.MoneyByAutoClick;

            for (int i = 0; i < _upgraders.Length; i++)
            {
                YandexGame.savesData.UnlockedUpgraders[i] = _upgraders[i].IsUnlocked;
            }

            YandexGame.SaveProgress();
        }

        private void Load()
        {
            _mainButton.HealthByClick = YandexGame.savesData.HealthByClick;
            _money.ResourcesValue = YandexGame.savesData.Money;
            _health.ResourcesValue = YandexGame.savesData.Health;
            _levelChanger.CurrentLevel = YandexGame.savesData.CurrentLevel;
            _levelChanger.CurrentIndex = YandexGame.savesData.CurrentIndex;
            _levelChanger.StartHealth = YandexGame.savesData.StartHealth;
            _levelChanger.StartReward = YandexGame.savesData.StartReward;
            _mainButton.MoneyByAutoClick = YandexGame.savesData.MoneyByAutoClick;

            for (int i = 0; i < _upgraders.Length; i++)
            {
                _upgraders[i].IsUnlocked = YandexGame.savesData.UnlockedUpgraders[i];
            }
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += Load;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Load;
        }

        private IEnumerator AutoSave()
        {
            while (true)
            {
                yield return new WaitForSeconds(_autoSaveInterval);
                Save();
            }
        }

        public void ResetProgress()
        {
            YandexGame.ResetSaveProgress();
            YandexGame.NewLeaderboardScores(YandexLeaderboardName, 0);
            YandexGame.SaveProgress();
            SceneManager.LoadScene(0);
        }
    }
}
