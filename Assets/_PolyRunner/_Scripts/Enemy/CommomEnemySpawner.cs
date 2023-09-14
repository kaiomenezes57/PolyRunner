using PolyRunner.Core;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Enemy
{
    public class CommomEnemySpawner : EnemySpawner
    {
        private readonly List<Transform> _spawnPoints = new();

        protected override void Start()
        {
            FindAllSpawnPoints();
            base.Start();
        }

        protected override void SpawnEnemy()
        {
            if (_spawnPoints.Count == 0 || _enemiesPrefab.Count == 0) { return; }

            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                int spawnPointRandomIndex = Random.Range(0, _spawnPoints.Count);
                int enemyRandomIndex = Random.Range(0, _enemiesPrefab.Count);

                Transform spawnPoint = _spawnPoints[spawnPointRandomIndex];
                EnemyBase enemyPrefab = _enemiesPrefab[enemyRandomIndex];

                EnemyBase enemy = Instantiate(enemyPrefab);
                enemy.transform.position = spawnPoint.position;
                enemy.transform.SetParent(spawnPoint);

                EnemyStats enemyStats = GetComponentInParent<RunBlock>().enemyStats;
                enemy.SumToEnemyStatsData(enemyStats);

                _spawnPoints.Remove(spawnPoint);
            }
        }

        private void FindAllSpawnPoints()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i));
            }
        }
    }
}