using PolyRunner.Core;
using TMPro;
using UnityEngine;

namespace PolyRunner.Menu
{
    public class CoinVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;

        private void Start()
        {
            CoinManager.Instance.OnCoinUpdate += OnCoinUpdate;
        }

        private void OnCoinUpdate(double obj)
        {
            _coinText.text = $"{obj:F2}";
        }

        private void OnDestroy()
        {
            CoinManager.Instance.OnCoinUpdate -= OnCoinUpdate;
        }
    }
}
