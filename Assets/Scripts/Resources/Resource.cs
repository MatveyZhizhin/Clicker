using UnityEngine;

namespace Assets.Scripts.Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] protected int _resourceValue;
        public bool IsDoubled { private get; set; } = false;

        public int ResourcesValue { get => _resourceValue; set => _resourceValue = value; }

        public virtual void Add(int value)
        {
            if (IsDoubled)
                value *= 2;

            _resourceValue += value;
        }
    }
}