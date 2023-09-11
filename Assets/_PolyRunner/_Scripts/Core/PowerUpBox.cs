using UnityEngine;

namespace PolyRunner.Core
{
    public class PowerUpBox : CollisionInteraction
    {
        private void Start()
        {
            _collisionType = CollisionType.PowerUp;
        }

        protected override void OnCollision()
        {
            Debug.Log($"Power Up Picked!");
        }
    }
}
