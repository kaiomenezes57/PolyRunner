using PolyRunner.Player;
using PolyRunner.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PolyRunner.HUD
{
    public class WeaponLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _bodyText;
        [SerializeField] private Image _weaponImage;

        private WeaponData _weaponData;
        private Button _buyButton;

        private void Start()
        {
            _buyButton = GetComponent<Button>();
            OnDestroy();

            _buyButton.onClick.AddListener(() => {
                if (_weaponImage != null)
                {
                    PlayerStatsData weaponStats = _weaponData.weaponStats;
                    PlayerStats.Instance.SumToPlayerStatsData(weaponStats);

                    WeaponSelector.Instance.SetActive(false);
                }
            });
        }

        public void Setup(WeaponData weaponData)
        {
            _titleText.text = weaponData.title;
            _bodyText.text = weaponData.description;
            _weaponImage.sprite = weaponData.WeaponImage;

            _weaponData = weaponData;
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveAllListeners();
        }
    }
}