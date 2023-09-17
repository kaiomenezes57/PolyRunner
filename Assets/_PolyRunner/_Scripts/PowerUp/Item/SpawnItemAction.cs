using UnityEngine;

namespace PolyRunner.Items
{
    [CreateAssetMenu(menuName = "Scriptables/Item Actions/Spawn Item Action")]
    public class SpawnItemAction : ItemAction
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Vector3 _spawnPosition;

        public override void PerformAction()
        {
            Instantiate(_itemPrefab, _spawnPosition, Quaternion.identity);
        }
    }
}
