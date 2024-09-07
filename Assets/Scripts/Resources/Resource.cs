using UnityEngine;

namespace Assets.Scripts.Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] protected int _resourceValue;

        public int ResourcesValue { get => _resourceValue; set => _resourceValue = value; }

        public virtual void Add(int value)
        {
            _resourceValue += value;
        }
    }
}