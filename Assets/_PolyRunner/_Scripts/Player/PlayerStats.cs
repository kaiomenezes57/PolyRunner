using PolyRunner.Core;
using PolyRunner.HUD;
using System;
using UnityEngine;

namespace PolyRunner.Player
{
    [RequireComponent(typeof(DamageText))]
    public class PlayerStats : Singleton<PlayerStats>, IDamageable
    {
        public PlayerStatsData PlayerStatsData { get { return _playerStatsData; } }
        [SerializeField] private PlayerStatsData _playerStatsData;

        public event Action<PlayerStatsData> OnPlayerStatsChanged;
        
        private void Awake()
        {
            _playerStatsData = new PlayerStatsData(
                health: 100,
                weaponDamage: 5,
                attackSpeed: 0.2f,
                attackRange: 10,
                lifeSteal: 0,
                cooldownReducer: 0);
        }

        public void SumToPlayerStatsData(PlayerStatsData playerStatsData)
        {
            _playerStatsData.Health += playerStatsData.Health;

            _playerStatsData.WeaponDamage += playerStatsData.WeaponDamage;
            _playerStatsData.AttackSpeed += playerStatsData.AttackSpeed;
            _playerStatsData.AttackRange += playerStatsData.AttackRange;
            _playerStatsData.LifeSteal += playerStatsData.LifeSteal;
            
            _playerStatsData.CooldownReducer += playerStatsData.CooldownReducer;
            OnPlayerStatsChanged?.Invoke(_playerStatsData);
        }

        public void ApplyDamage(float damage)
        {
            _playerStatsData.Health -= damage;
            DeathHandler();

            GetComponent<DamageText>().Setup(damage, transform.position, Color.red);
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerApplyDamage");
            OnPlayerStatsChanged?.Invoke(_playerStatsData);
        }

        public void ApplyHeal(float damage)
        {
            float lifeSteal = damage * _playerStatsData.LifeSteal;
            _playerStatsData.Health += lifeSteal;

            OnPlayerStatsChanged?.Invoke(_playerStatsData);
        }

        public void DeathHandler()
        {
            if (_playerStatsData.Health > 0) { return; }
            Time.timeScale = 0;
        }
    }

    [System.Serializable]
    public struct PlayerStatsData
    {
        public float Health;

        [Space]
        public float WeaponDamage;
        public float AttackSpeed;
        public float AttackRange;
        public float LifeSteal;

        [Space]
        public float CooldownReducer;

        public PlayerStatsData(float health, float weaponDamage, float attackSpeed, float attackRange, float lifeSteal, float cooldownReducer)
        {
            Health = health;
            WeaponDamage = weaponDamage;
            AttackSpeed = attackSpeed;
            AttackRange = attackRange;
            LifeSteal = lifeSteal;
            CooldownReducer = cooldownReducer;
        }
    }
}
