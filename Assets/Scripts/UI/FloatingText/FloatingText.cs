using UnityEngine;

namespace Assets.Scripts.UI.FloatingText
{
    public abstract class FloatingText : MonoBehaviour
    {
        [SerializeField] protected GameObject _text;

       
        [SerializeField] protected char _prefix;
        [SerializeField] protected float _lifeTime;

        protected abstract void SpawnFloatingText(long value);
    }
}
