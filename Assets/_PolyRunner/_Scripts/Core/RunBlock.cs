using PolyRunner.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Core
{
    public class RunBlock : MonoBehaviour
    {
        public EnemyStats enemyStats;
        private readonly List<GameObject> _renderers = new();

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                _renderers.Add(child);
            }
        }

        public void SetActiveVisual(bool enabled)
        {
            _renderers.RemoveAll(r => r == null);
            _renderers.ForEach(r => r.SetActive(enabled));
        }
    }
}
