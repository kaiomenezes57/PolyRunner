using PolyRunner.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PolyRunner.Menu
{
    public class WarningScreen : Singleton<WarningScreen>
    {
        private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _bodyText;

        [SerializeField] private Button _negativeButton;
        [SerializeField] private Button _positiveButton;
        [SerializeField] private Button _okButton;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _negativeButton.onClick.AddListener(HideWarningScreen);
            _okButton.onClick.AddListener(HideWarningScreen);

            HideWarningScreen();
        }

        public void ShowWarningScreen(string title, string body)
        {
            ShowWarningScreen(title, body, null);
        }

        public void ShowWarningScreen(string title, string body, Action positiveAction)
        {
            ButtonActiveHandler(positiveAction);

            _titleText.text = title;
            _bodyText.text = body;
            
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        }

        public void HideWarningScreen()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            
            _titleText.text = null;
            _bodyText.text = null;
        }

        private void ButtonActiveHandler(Action positiveAction)
        {
            bool isChoose = positiveAction != null;
            _positiveButton.onClick.RemoveAllListeners();

            if (isChoose)
            {
                _positiveButton.onClick.AddListener(() => positiveAction());
            }

            _negativeButton.gameObject.SetActive(isChoose);
            _positiveButton.gameObject.SetActive(isChoose);
            _okButton.gameObject.SetActive(!isChoose);
        }
    }
}
