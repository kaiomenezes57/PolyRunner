using PolyRunner.Player;
using TMPro;
using UnityEngine;

namespace PolyRunner.HUD
{
    public class StatsLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _weaponDamageText;
        [SerializeField] private TextMeshProUGUI _attackSpeedText;
        
        [SerializeField] private TextMeshProUGUI _attackRangeText;
        [SerializeField] private TextMeshProUGUI _lifeStealText;
        [SerializeField] private TextMeshProUGUI _cooldownText;

        private void Start()
        {
            PlayerStatsData playerStatsData = PlayerStats.Instance.PlayerStatsData;
            SetInformation(playerStatsData);

            PlayerStats.Instance.OnPlayerStatsChanged += SetInformation;
        }

        private void SetInformation(PlayerStatsData playerStatsData)
        {
            _healthText.text = $"{playerStatsData.Health:F0}% health";
            _weaponDamageText.text = $"{playerStatsData.WeaponDamage:F0} damage";
            _attackSpeedText.text = $"{playerStatsData.AttackSpeed:F2} attack speed";

            _attackRangeText.text = $"{playerStatsData.AttackRange:F0} range";
            _lifeStealText.text = $"{playerStatsData.LifeSteal:F2}% life steal";
            _cooldownText.text = $"{playerStatsData.CooldownReducer:F0}% cooldown";
        }

        private void OnDestroy()
        {
            PlayerStats.Instance.OnPlayerStatsChanged -= SetInformation;
        }
    }
}
