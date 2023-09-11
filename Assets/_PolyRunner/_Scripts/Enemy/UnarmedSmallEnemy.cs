namespace PolyRunner.Enemy
{
    public class UnarmedSmallEnemy : EnemyBase
    {
        private PlayerController _playerController;

        private void Start()
        {
            _enemyStats = new EnemyStats("Enemy 1", 20);
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            transform.LookAt(_playerController.transform);
        }
    }
}
