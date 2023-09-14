using System;
using System.Collections;
using UnityEngine;

namespace PolyRunner.Core
{
    public class CoinManager : Singleton<CoinManager>
    {
        public double CoinAmount { get { return _coinAmount; } }
        private double _coinAmount;

        public event Action<double> OnCoinUpdate;

        private void Start()
        {
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
        }

        public void RemoveCoin(double amount)
        {
            _coinAmount -= amount;
            if (_coinAmount <= 0) { _coinAmount = 0; }
            OnCoinUpdate?.Invoke(_coinAmount);
        }
    }
}
