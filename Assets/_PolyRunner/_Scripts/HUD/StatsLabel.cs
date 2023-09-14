using PolyRunner.Player;
using PolyRunner.Weapon;
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

        [SerializeField] private WeaponLabel _currentWeapon;

        private void Start()
        {
            PlayerStatsData playerStatsData = PlayerStats.Instance.PlayerStatsData;
            SetInformation(playerStatsData);

            _currentWeapon.gameObject.SetActive(false);
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

        public void SetCurrentWeapon(WeaponData weaponData)
        {
            _currentWeapon.Setup(weaponData);
            _currentWeapon.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            PlayerStats.Instance.OnPlayerStatsChanged -= SetInformation;
        }
    }
}
