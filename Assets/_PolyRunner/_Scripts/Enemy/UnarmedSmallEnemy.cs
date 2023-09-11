namespace PolyRunner.Enemy
{
    public class UnarmedSmallEnemy : EnemyBase
    {
        private void Start()
        {
            _enemyStats = new EnemyStats("Enemy 1", 30);
        }
    }
}
