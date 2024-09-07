using Assets.Scripts.Game;
using Assets.Scripts.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ExperienceView : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        private LevelChanger _levels;
        private Experience _experience;

        private void Awake()
        {
            _levels = FindObjectOfType<LevelChanger>();
            _experience = FindObjectOfType<Experience>();
        }

        private void OnEnable()
        {
            _experience.ExperienceChanged += RenderProgressBar;
        }

        private void OnDisable()
        {
            _experience.ExperienceChanged -= RenderProgressBar;
        }

        private void RenderProgressBar(float experience)
        {
            _progressBar.fillAmount = experience / _levels.MaxExperience;
        }
    }
}
