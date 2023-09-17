using PolyRunner.Core;
using PolyRunner.Player;
using PolyRunner.Weapon;
using System.Collections;
using TMPro;
using UnityEngine;

namespace PolyRunner.HUD
{
    public class StatsLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _weaponDamageText;
        [SerializeField] private TextMeshProUGUI _attackSpeedText;

        [Space]
        [SerializeField] private TextMeshProUGUI _attackRangeText;
        [SerializeField] private TextMeshProUGUI _lifeStealText;
        [SerializeField] private TextMeshProUGUI _cooldownText;

        [Space]
        [SerializeField] private WeaponLabel _currentWeapon;

        [Space]
        [SerializeField] private TextMeshProUGUI _coinAmount;

        private void Start()
        {
            PlayerStats.Instance.OnPlayerStatsChanged += SetInformation;
            CoinManager.Instance.OnCoinUpdate += UpdateCoinAmount;

            PlayerStatsData playerStatsData = PlayerStats.Instance.PlayerStatsData;
            SetInformation(playerStatsData);

            _currentWeapon.gameObject.SetActive(false);
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

        private void UpdateCoinAmount(double coinAmount)
        {
            StartCoroutine(Animation());
            IEnumerator Animation()
            {
                double current = double.Parse(_coinAmount.text);
                float multiplier = GetMultiplierByDifference(coinAmount, current);
                _coinAmount.fontSize += 1f;

                while (current < coinAmount)
                {
                    current += Time.deltaTime * multiplier;
                    _coinAmount.text = $"<color=green>{current:F2}</color>";
                    yield return null;
                }

                _coinAmount.fontSize -= 1f;
                _coinAmount.text = $"{coinAmount:F2}";
            }
        }

        private float GetMultiplierByDifference(double coinAmount, double current)
        {
            float multiplier = 1f;

            if (coinAmount - current >= 1)
            {
                float difference = (float)(coinAmount - current);
                multiplier = difference;
            }

            return multiplier;
        }

        public void SetCurrentWeapon(WeaponData weaponData)
        {
            _currentWeapon.Setup(weaponData);
            _currentWeapon.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            if (PlayerStats.Instance != null) { PlayerStats.Instance.OnPlayerStatsChanged -= SetInformation; }
            if (CoinManager.Instance != null) { CoinManager.Instance.OnCoinUpdate -= UpdateCoinAmount; }
        }
    }
}
