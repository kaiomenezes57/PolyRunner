using PolyRunner.Core;
using PolyRunner.Weapon;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.HUD
{
    public class WeaponSelector : Singleton<WeaponSelector>
    {
        [SerializeField] private GameObject _weaponLabelPrefab;
        [SerializeField] private Transform _gridTransform;
        [SerializeField] private List<WeaponData> _weaponsToSpawn = new();

        private CanvasGroup _canvasGroup;
        private List<GameObject> _spawnedWeapons = new();

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void SpawnWeaponsOnGrid()
        {
            for (int i = 0; i < _weaponsToSpawn.Count; i++)
            {
                GameObject weapon = Instantiate(_weaponLabelPrefab, _gridTransform);
                weapon.GetComponent<WeaponLabel>().Setup(_weaponsToSpawn[i]);

                _spawnedWeapons.Add(weapon);
            }
        }

        public void SetActive(bool enabled)
        {
            Time.timeScale = enabled ? 0f : 1f;

            _canvasGroup.alpha = enabled ? 1f : 0f;
            _canvasGroup.blocksRaycasts = enabled;

            _spawnedWeapons.ForEach(w => Destroy(w));
            _spawnedWeapons?.Clear();

            if (enabled) { SpawnWeaponsOnGrid(); }
        }
    }
}