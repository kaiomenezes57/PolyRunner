using UnityEngine;
using PolyRunner.Core;
using PolyRunner.Player;
using PolyRunner.HUD;
using System;
using PolyRunner.PowerUp;

namespace PolyRunner.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class EnemyBase : CollisionInteraction, IDamageable
    {
        [SerializeField] protected EnemyStats _enemyStats;
        [SerializeField] protected PowerUpData _dropPowerUp;
        
        private DamageText _damageText;
        protected PlayerController _playerController;

        protected virtual void Start()
        {
            _damageText = gameObject.AddComponent<DamageText>();
            _playerController = FindObjectOfType<PlayerController>();
            
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.constraints =
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionZ;
        }

        protected override void OnCollision()
        {
            float damage = _enemyStats.Health;
            PlayerStats.Instance.ApplyDamage(damage);
        }

        public void ApplyDamage(float damage)
        {
            _enemyStats.Health -= damage;

            _damageText.Setup(damage, transform.position, Color.cyan);
            FMODUnity.RuntimeManager.PlayOneShot("event:/EnemyApplyDamage");

            DeathHandler();
        }

        public void DeathHandler()
        {
            if (_enemyStats.Health > 0) { return; }
            CoinManager.Instance.AddCoin(_enemyStats.DropCoinAmount);
            
            DropItem();
            Destroy(gameObject);
        }

        public void SumToEnemyStatsData(EnemyStats enemyStats)
        {
            _enemyStats.Health += enemyStats.Health;
        }

        private void DropItem()
        {
            GameObject prefab = (GameObject)Resources.Load("PowerUpBoxDrop");
            GameObject powerUp = Instantiate(prefab, transform.parent.transform);

            powerUp.transform.position = transform.position;
        }
    }

    [System.Serializable]
    public struct EnemyStats
    {
        public string Name;
        public float Health;
        public double DropCoinAmount;

        public EnemyStats(string name, float health, double dropCoinAmount)
        {
            Name = name;
            Health = health;
            DropCoinAmount = dropCoinAmount;
        }
    }
}
