using Assets.Scripts.Game;
using Assets.Scripts.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        private LevelChanger _levels;
        private Health _health;

        private void Awake()
        {
            _levels = FindObjectOfType<LevelChanger>();
            _health = FindObjectOfType<Health>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += RenderProgressBar;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= RenderProgressBar;
        }

        private void RenderProgressBar(float health)
        {
            _progressBar.fillAmount = health / _levels.StartHealth;
        }
    }
}
