namespace PolyRunner.Enemy
{
    public class UnarmedEnemy : EnemyBase
    {
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            transform.LookAt(_playerController.transform);
        }
    }
}
