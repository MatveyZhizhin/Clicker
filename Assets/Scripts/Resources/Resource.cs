using UnityEngine;

namespace Assets.Scripts.Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] protected long _resourceValue;
        public bool IsDoubled { private get; set; } = false;

        public long ResourcesValue { get => _resourceValue; set => _resourceValue = value; }

        public virtual void Add(long value)
        {
            if (IsDoubled)
                value *= 2;

            _resourceValue += value;
        }
    }
}