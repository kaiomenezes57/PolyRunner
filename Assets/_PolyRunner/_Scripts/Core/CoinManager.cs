using BayatGames.SaveGameFree;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace PolyRunner.Core
{
    public class CoinManager : Singleton<CoinManager>
    {
        public double CoinAmount { get { return _coinAmount; } }
        private double _coinAmount;

        private const string _saveKey = "Coin";
        public event Action<double> OnCoinUpdate;

        private async void Start()
        {
            await Task.Delay(100);
            LoadCurrentCoinAmount();

            StartCoroutine(CoinEarnLoop());
            OnCoinUpdate?.Invoke(_coinAmount);
        }

        private IEnumerator CoinEarnLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(10f);
                AddCoin(amount: 0.1);
            }
        }

        public void AddCoin(double amount)
        {
            _coinAmount += amount;
            OnCoinUpdate?.Invoke(_coinAmount);

            FMODUnity.RuntimeManager.PlayOneShot("event:/CoinEarn");
            SaveCurrentCoinAmount();
        }

        public void RemoveCoin(double amount)
        {
            _coinAmount -= amount;
            if (_coinAmount <= 0) { _coinAmount = 0; }
            OnCoinUpdate?.Invoke(_coinAmount);
            SaveCurrentCoinAmount();
        }

        private void SaveCurrentCoinAmount()
        {
            SaveGame.Save(_saveKey, _coinAmount);
        }

        private void LoadCurrentCoinAmount()
        {
            if (!SaveGame.Exists(_saveKey)) { return; }
            _coinAmount = SaveGame.Load<double>(_saveKey);
        }
    }
}
