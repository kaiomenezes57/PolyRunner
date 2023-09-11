using PolyRunner.Core;
using PolyRunner.Player;

namespace PolyRunner.Enemy
{
    public class EnemyBase : CollisionInteraction, IDamageable
    {
        protected EnemyStats _enemyStats;

        protected override void OnCollision()
        {
            float damage = _enemyStats.Health;
            PlayerStats.Instance.ApplyDamage(damage);
        }

        public void ApplyDamage(float damage)
        {
            _enemyStats.Health -= damage;
            DeathHandler();
        }

        public void DeathHandler()
        {
            if (_enemyStats.Health > 0) { return; }
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public struct EnemyStats
    {
        public string Name;
        public float Health;

        public EnemyStats(string name, float health)
        {
            Name = name;
            Health = health;
        }
    }
}
