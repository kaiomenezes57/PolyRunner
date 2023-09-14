using PolyRunner.Core;
using PolyRunner.HUD;

namespace PolyRunner.Trigger
{
    public class WeaponSelectorTrigger : CollisionInteraction
    {
        protected override void OnCollision()
        {
            WeaponSelector.Instance.SetActive(true);
        }
    }
}
