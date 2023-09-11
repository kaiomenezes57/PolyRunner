using Codice.Client.Common.GameUI;
using PolyRunner.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyBase> _enemiesPrefab;

        private void Start()
        {
            int amount = Random.Range(1, 3);
            List<Transform> spawnPoints = new();

            for (int i = 0; i < transform.childCount; i++)
            {
                spawnPoints.Add(transform.GetChild(i));
            }

            for (int i = 0; i < amount; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                EnemyBase enemyPrefab = _enemiesPrefab[Random.Range(0, _enemiesPrefab.Count)];
                
                GameObject enemy = Instantiate(enemyPrefab).gameObject;
                enemy.transform.position = spawnPoint.position;
                enemy.transform.SetParent(spawnPoint);
            }
        }
    }
}
