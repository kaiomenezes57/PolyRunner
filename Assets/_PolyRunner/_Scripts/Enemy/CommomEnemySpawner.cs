using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Enemy
{
    public class CommomEnemySpawner : EnemySpawner
    {
        private readonly List<Transform> _spawnPoints = new();
        private int _amount;

        protected override void Start()
        {
            _amount = Random.Range(1, 3);
            
            FindAllSpawnPoints();
            base.Start();
        }

        protected override void SpawnEnemy()
        {
            for (int i = 0; i < _amount; i++)
            {
                int spawnPointRandomIndex = Random.Range(0, _spawnPoints.Count);
                int enemyRandomIndex = Random.Range(0, _enemiesPrefab.Count);

                Transform spawnPoint = _spawnPoints[spawnPointRandomIndex];
                EnemyBase enemyPrefab = _enemiesPrefab[enemyRandomIndex];

                GameObject enemy = Instantiate(enemyPrefab).gameObject;
                enemy.transform.position = spawnPoint.position;
                enemy.transform.SetParent(spawnPoint);

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