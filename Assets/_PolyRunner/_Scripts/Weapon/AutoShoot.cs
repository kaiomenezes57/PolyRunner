using PolyRunner.Core;
using PolyRunner.Player;
using PolyRunner.Weapon;
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

                float delay = 1f - PlayerStats.Instance.PlayerStatsData.AttackSpeed;
                GameObject projectile = ProjectilePool.Instance.GetProjectile();
                projectile.transform.position = transform.position;
                projectile.SetActive(true);

                delay = Mathf.Clamp(delay, 0f, 0.9f);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
