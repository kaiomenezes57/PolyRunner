using PolyRunner.Core;
using PolyRunner.Enemy;
using PolyRunner.Player;
using System.Collections;
using UnityEngine;

namespace PolyRunner.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        public WeaponData weaponData;

        private void Start()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.forward * 500);

            StartCoroutine(StoreDelay());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemyBase))
            {
                StopAllCoroutines();
                float damage = PlayerStats.Instance.PlayerStatsData.WeaponDamage + weaponData.damage;
                enemyBase.ApplyDamage(damage);

                ProjectilePool.Instance.StoreProjectile(gameObject);
                return;
            }
        }

        private IEnumerator StoreDelay()
        {
            while (transform.position.z < PlayerStats.Instance.PlayerStatsData.AttackRange) { yield return null; }
            ProjectilePool.Instance.StoreProjectile(gameObject);
        }
    }
}