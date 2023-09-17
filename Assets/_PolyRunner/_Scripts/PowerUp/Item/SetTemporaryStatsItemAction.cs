using PolyRunner.Player;
using System.Threading.Tasks;
using UnityEngine;

namespace PolyRunner.Items
{
    [CreateAssetMenu(menuName = "Scriptables/Item Actions/Temporary Stats Item Action")]
    public class SetTemporaryStatsItemAction : ItemAction
    {
        [SerializeField] private int _time;
        [SerializeField] private PlayerStatsData _stats;

        public override async void PerformAction()
        {
            PlayerStats.Instance?.SumToPlayerStatsData(_stats);

            int timeInSeconds = _time * 1000;
            await Task.Delay(timeInSeconds);

            PlayerStats.Instance?.SubtractPlayerStatsData(_stats);
        }
    }
}
