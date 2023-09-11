using PolyRunner.Core;
using System;
using UnityEngine;

namespace PolyRunner.Player
{
    public class PlayerStats : Singleton<PlayerStats>, IDamageable
    {
        public PlayerStatsData PlayerStatsData { get { return _playerStatsData; } }
        [SerializeField] private PlayerStatsData _playerStatsData;

        public event Action<PlayerStatsData> OnPlayerStatsChanged;
        
        private void Awake()
        {
            _playerStatsData = new PlayerStatsData(
                health: 100,
                armor: 5,
                weaponDamage: 5,
                attackSpeed: 0.2f,
                attackRange: 10,
                lifeSteal: 0,
                cooldownReducer: 0);
        }

        public void SumToPlayerStatsData(PlayerStatsData playerStatsData)
        {
            _playerStatsData.Health += playerStatsData.Health;
            _playerStatsData.Armor += playerStatsData.Armor;

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
        public float Armor;
        
        public float WeaponDamage;
        [Range(0f, 0.8f)] public float AttackSpeed;
        public float AttackRange;
        public float LifeSteal;
        
        public float CooldownReducer;

        public PlayerStatsData(float health, float armor, float weaponDamage, float attackSpeed, float attackRange, float lifeSteal, float cooldownReducer)
        {
            Health = health;
            Armor = armor;
            WeaponDamage = weaponDamage;
            AttackSpeed = attackSpeed;
            AttackRange = attackRange;
            LifeSteal = lifeSteal;
            CooldownReducer = cooldownReducer;
        }
    }
}
