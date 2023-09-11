using PolyRunner.PowerUp;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace PolyRunner.Core
{
    public class PowerUpBox : CollisionInteraction
    {
        [SerializeField] private PowerUpData[] _powerUpDataList;
        [SerializeField] private TextMeshProUGUI _powerUpLabel;
        private PowerUpData _currentPowerUp;

        private async void Start()
        {
            while (_currentPowerUp == null)
            {
                int chance = Random.Range(0, 100);
                PowerUpData powerUpData = _powerUpDataList[Random.Range(0, _powerUpDataList.Length)];

                if (powerUpData.rarity > chance)
                {
                    _currentPowerUp = powerUpData;
                    break;
                }

                await Task.Delay(10);
            }

            _collisionType = CollisionType.PowerUp;
            _powerUpLabel.text = _currentPowerUp.description;
        }

        protected override void OnCollision()
        {
            _currentPowerUp.ApplyPowerUp();
        }
    }
}
