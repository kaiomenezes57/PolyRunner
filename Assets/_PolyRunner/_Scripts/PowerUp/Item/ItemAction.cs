using UnityEngine;

namespace PolyRunner.Item
{
    public abstract class ItemAction : ScriptableObject
    {
        public abstract void PerformAction();
    }
}
