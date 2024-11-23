using Assets.Scripts.Resources;
using System.Collections;
using System.Collections.Generic;
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
            YandexGame.savesData.Money = _money.ResourcesValue;
            YandexGame.savesData.Experience = _experience.ResourcesValue;
            YandexGame.savesData.CurrentLevel = _levelChanger.CurrentLevel;
            YandexGame.savesData.MaxExperience = _levelChanger.MaxExperience;
            YandexGame.savesData.ResourceByClick = _mainButton.ResourceByClick;
            YandexGame.savesData.MoneyByAutoClick = _mainButton.MoneyByAutoClick;

            YandexGame.SaveProgress();
        }

        private void Load()
        {
            _money.ResourcesValue = YandexGame.savesData.Money;
            _experience.ResourcesValue = YandexGame.savesData.Experience;
            _levelChanger.CurrentLevel = YandexGame.savesData.CurrentLevel;
            _levelChanger.MaxExperience = YandexGame.savesData.MaxExperience;
            _mainButton.ResourceByClick = YandexGame.savesData.ResourceByClick;
            _mainButton.MoneyByAutoClick = YandexGame.savesData.MoneyByAutoClick;
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
            YandexGame.SaveProgress();
            SceneManager.LoadScene(0);
        }
    }
}
