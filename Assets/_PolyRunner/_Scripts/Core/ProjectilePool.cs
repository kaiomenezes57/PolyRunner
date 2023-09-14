using PolyRunner.Weapon;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PolyRunner.Core
{
    public class ProjectilePool : Singleton<ProjectilePool>
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private int _amount;

        private readonly List<GameObject> _projectiles = new();
        private int _index;

        private void Awake()
        {
            _projectiles?.Clear();

            for (int i = 0; i < _amount; i++)
            {
                GameObject projectile = Instantiate(_projectilePrefab, transform);
                _projectiles.Add(projectile);
            }
        }

        public GameObject GetProjectile()
        {
            GameObject projectile = _projectiles[_index++];
            projectile.transform.SetParent(null);

            if (_index > _projectiles.Count - 1) { _index = 0; }
            return projectile;
        }

        public void StoreProjectile(GameObject projectile)
        {
            if (!_projectiles.Contains(projectile)) { return; }
            
            projectile.SetActive(false);
            projectile.transform.SetParent(transform);
            projectile.transform.localPosition = Vector3.zero;
        }

        public void SetProjectilesColor(Color color)
        {
            _projectiles.ForEach(p => p.GetComponent<MeshRenderer>().materials[0].color = color);
        }

        private void OnDestroy()
        {
            _projectiles?.Clear();
        }
    }
}
