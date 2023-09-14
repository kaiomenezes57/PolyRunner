using PolyRunner.Trigger;
using UnityEngine;

namespace PolyRunner.Core
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _runBlockPrefabs;
        [SerializeField] private Transform _parentTransform;

        [Space, SerializeField] private int _amount;
        private bool _isWeaponSelectorGenerated = true;
        private int _runCount = 1;

        private void Start()
        {
            Create();
        }

        private void Create()
        {
            int z = 10;

            for (int i = 0; i < _amount; i++)
            {
                GameObject prefab = RunHandler();
                GameObject runBlock = Instantiate(prefab);
            
                runBlock.GetComponentInChildren<WeaponSelectorTrigger>(true).gameObject.SetActive(_isWeaponSelectorGenerated);
                _isWeaponSelectorGenerated = false;

                runBlock.transform.position = new(0f, 0f, z);
                runBlock.transform.SetParent(_parentTransform);

                z += 20;
            }
        }

        private GameObject RunHandler()
        {
            switch (_runCount++)
            {
                case 10:
                    return _runBlockPrefabs[1];

                case 20:
                    _runCount = 1;
                    return _runBlockPrefabs[2];

                default:
                    return _runBlockPrefabs[0];
            }
        }
    }
}
