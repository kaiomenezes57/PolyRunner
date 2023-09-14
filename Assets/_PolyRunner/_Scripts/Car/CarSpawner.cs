using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Car
{
    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] private int _spawnChance;
        [SerializeField] private int _interval = 5;
        
        [Space, SerializeField] private List<CarBehaviour> _carList = new();
        private readonly List<Transform> _spawnPoints = new();

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                _spawnPoints.Add(child);
            }

            StartCoroutine(SpawnRoutineLoop());
        }

        private IEnumerator SpawnRoutineLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(_interval);
                if (_spawnChance > Random.Range(0, 100))
                {
                    GameObject randomCar = _carList[Random.Range(0, _carList.Count)].gameObject;
                    Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

                    GameObject spawnedCar = Instantiate(randomCar, randomSpawnPoint.transform.position, Quaternion.Euler(0f, 180f, 0f));
                }
            }
        }
    }
}
