using PolyRunner.Core;
using PolyRunner.Player;
using System.Collections;
using UnityEngine;

namespace PolyRunner.Car
{
    public class CarBehaviour : CollisionInteraction
    {
        private void Start()
        {
            StartCoroutine(CarRoutine());
        }

        private IEnumerator CarRoutine()
        {
            while (transform.position.z > -15f)
            {
                Vector3 translation = 15f * Time.deltaTime * Vector3.forward;
                transform.Translate(translation);
                yield return null;
            }

            Destroy(gameObject);
        }

        protected override void OnCollision()
        {
            float damage = Random.Range(50f, 80f);
            PlayerStats.Instance.ApplyDamage(damage);
        }
    }
}
