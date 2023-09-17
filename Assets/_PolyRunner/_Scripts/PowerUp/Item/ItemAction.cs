using UnityEngine;

namespace PolyRunner.Items
{
    public abstract class ItemAction : ScriptableObject
    {
        public abstract void PerformAction();
    }
}
