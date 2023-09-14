using PolyRunner.Player;
using UnityEngine;

namespace PolyRunner.PowerUp
{
    [CreateAssetMenu(menuName = "Scriptables/Power Up")]
    public class StatsPowerUp : PowerUpData
    {
        [SerializeField] private PlayerStatsData _playerStatsData;

        public override void ApplyPowerUp()
        {
            PlayerStats.Instance.SumToPlayerStatsData(_playerStatsData);
            FMODUnity.RuntimeManager.PlayOneShot("event:/PowerUp");
        }
    }
}
