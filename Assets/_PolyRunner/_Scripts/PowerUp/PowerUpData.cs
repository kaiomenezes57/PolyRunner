using UnityEngine;

namespace PolyRunner.PowerUp
{
    public abstract class PowerUpData : ScriptableObject
    {
        public string title;
        [TextArea(4, 8)] public string description;
        
        public int rarity;

        public abstract void ApplyPowerUp();
    }
}
