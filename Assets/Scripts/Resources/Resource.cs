using UnityEngine;

namespace Assets.Scripts.Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] protected long _resourceValue;
        public bool IsDoubled { get; set; } = false;

        public long ResourcesValue { get => _resourceValue; set => _resourceValue = value; }

        public virtual void Add(long value, bool isPurchase)
        {
            if (IsDoubled && !isPurchase)
                value *= 2;

            _resourceValue += value;
        }
    }
}