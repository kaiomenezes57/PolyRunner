using UnityEngine;

namespace PolyRunner.Core
{
    public abstract class CollisionInteraction : MonoBehaviour
    {
        protected CollisionType _collisionType;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Player")) { return; }
            OnCollision();
            Destroy(gameObject);
        }

        protected abstract void OnCollision();
    }

    public enum CollisionType { PowerUp = 1, Enemy = 2, }
}
