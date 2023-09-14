using PolyRunner.Core;
using PolyRunner.Player;
using PolyRunner.PowerUp;
using UnityEngine;

namespace PolyRunner.Weapon
{
    [CreateAssetMenu(menuName = "Scriptables/Weapon")]
    public class WeaponData : PowerUpData
    {
        public Sprite WeaponImage;
        public Color projectileColor;
        public PlayerStatsData weaponStats;

        public override void ApplyPowerUp()
        {
            PlayerStats.Instance.SumToPlayerStatsData(weaponStats);
            ProjectilePool.Instance.SetProjectilesColor(projectileColor);
            
            FMODUnity.RuntimeManager.PlayOneShot("event:/WeaponChoose");
        }
    }
}