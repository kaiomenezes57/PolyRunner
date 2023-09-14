using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Enemy
{
    public abstract class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected List<EnemyBase> _enemiesPrefab;

        protected virtual void Start()
        {
            if (_enemiesPrefab.Count == 0) { return; }
            SpawnEnemy();
        }

        protected abstract void SpawnEnemy();
    }
}