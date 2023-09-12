using UnityEngine;

namespace PolyRunner.Enemy
{
    public class SubBossSpawner : EnemySpawner
    {
        [SerializeField] private Transform _spawnPoint;

        protected override void Start()
        {
            base.Start();
        }

        protected override void SpawnEnemy()
        {
            int enemyRandomIndex = Random.Range(0, _enemiesPrefab.Count);
            EnemyBase enemyPrefab = _enemiesPrefab[enemyRandomIndex];

            GameObject enemy = Instantiate(enemyPrefab).gameObject;
            enemy.transform.position = _spawnPoint.position;
            enemy.transform.SetParent(_spawnPoint);
        }
    }
}