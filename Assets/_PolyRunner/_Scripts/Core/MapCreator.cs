using UnityEngine;

namespace PolyRunner.Core
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _runBlockPrefab;
        [SerializeField] private Transform _parentTransform;

        [Space, SerializeField] private int _amount;

        private void Start()
        {
            Create();
        }

        private void Create()
        {
            int z = 10;

            for (int i = 0; i < _amount; i++)
            {
                GameObject runBlock = Instantiate(_runBlockPrefab);
                
                runBlock.transform.position = new(0f, 0f, z);
                runBlock.transform.SetParent(_parentTransform);

                z += 20;
            }
        }
    }
}
