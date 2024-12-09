using Assets.Scripts.Resources;
using Assets.Scripts.Upgraders;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Game
{
    public class SaveService : MonoBehaviour
    {
        private Money _money;
        private Experience _experience;
        private LevelChanger _levelChanger;
        private MainButton _mainButton;

        [SerializeField] private float _autoSaveInterval;
        [SerializeField] private Upgrader[] _upgraders;

        private const string YandexLeaderboardName = "Money";

        private void Awake()
        {
            _money = FindObjectOfType<Money>();
            _experience = FindObjectOfType<Experience>();
            _levelChanger = FindObjectOfType<LevelChanger>();
            _mainButton = FindObjectOfType<MainButton>();
        }

        private void Start()
        {
            StartCoroutine(AutoSave());
        }

        private void Save()
        {
            if (_money.ResourcesValue > YandexGame.savesData.Money)
            {
                YandexGame.NewLeaderboardScores(YandexLeaderboardName, _money.ResourcesValue);
            }

            YandexGame.savesData.Money = _money.ResourcesValue;
            YandexGame.savesData.Experience = _experience.ResourcesValue;
            YandexGame.savesData.CurrentLevel = _levelChanger.CurrentLevel;
            YandexGame.savesData.MaxExperience = _levelChanger.MaxExperience;
            YandexGame.savesData.MoneyByClick = _mainButton.MoneyByClick;
            YandexGame.savesData.MoneyByAutoClick = _mainButton.MoneyByAutoClick;

            for (int i = 0; i < _upgraders.Length; i++)
            {
                YandexGame.savesData.UnlockedUpgraders[i] = _upgraders[i].IsUnlocked;
            }

            YandexGame.SaveProgress();
        }

        private void Load()
        {
            _money.ResourcesValue = YandexGame.savesData.Money;
            _experience.ResourcesValue = YandexGame.savesData.Experience;
            _levelChanger.CurrentLevel = YandexGame.savesData.CurrentLevel;
            _levelChanger.MaxExperience = YandexGame.savesData.MaxExperience;
            _mainButton.MoneyByClick = YandexGame.savesData.MoneyByClick;
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
