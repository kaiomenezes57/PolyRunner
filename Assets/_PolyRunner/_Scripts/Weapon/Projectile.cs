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
        private void Start()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Vector3 force = Vector3.forward * 500;
            rigidbody.AddForce(force);

            StartCoroutine(StoreDelay());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemyBase))
            {
                StopAllCoroutines();
                float damage = PlayerStats.Instance.PlayerStatsData.WeaponDamage;
                enemyBase.ApplyDamage(damage);
                PlayerStats.Instance.ApplyHeal(damage);

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