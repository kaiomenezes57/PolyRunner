using PolyRunner.Core;
using PolyRunner.Player;
using System.Collections;
using UnityEngine;

namespace PolyRunner.Weapon
{
    public class AutoShoot : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Routine());
        }

        private IEnumerator Routine()
        {
            while (true)
            {
                GameObject projectile = ProjectilePool.Instance.GetProjectile();
                float attackSpeed = Mathf.Clamp(PlayerStats.Instance.PlayerStatsData.AttackSpeed, 0f, DefaultValues.maxAttackSpeed);
                float delay = (1f - attackSpeed);
                
                projectile.transform.position = transform.position;
                projectile.SetActive(true);

                yield return new WaitForSeconds(delay);
            }
        }
    }
}
