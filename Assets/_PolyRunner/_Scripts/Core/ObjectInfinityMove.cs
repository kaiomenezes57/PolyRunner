using System.Collections;
using UnityEngine;

namespace PolyRunner.Core
{
    public class ObjectInfinityMove : MonoBehaviour
    {
        private readonly float _speed = 3;
        private readonly float _maxZ = -15f;

        private void OnEnable()
        {
            StartCoroutine(MoveRoutine());
        }

        private IEnumerator MoveRoutine()
        {
            while (transform.position.z > _maxZ)
            {
                Vector3 direction = _speed * Time.deltaTime * -transform.forward;
                transform.Translate(direction, Space.World);
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}
