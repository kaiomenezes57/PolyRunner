using UnityEngine;

namespace PolyRunner.PowerUp
{
    public abstract class PowerUpData : ScriptableObject
    {
        public string description;
        public int rarity;

        public abstract void ApplyPowerUp();
    }
}
