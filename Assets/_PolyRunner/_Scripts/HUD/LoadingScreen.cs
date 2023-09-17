using PolyRunner.Core;
using System.Collections;
using UnityEngine;

namespace PolyRunner.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingScreen : Singleton<LoadingScreen>
    {
        private CanvasGroup _loadingCanvas;

        private void Start()
        {
            DontDestroyOnLoad(this);

            _loadingCanvas = GetComponent<CanvasGroup>();
            TerminateLoading();
        }

        public void StartLoading()
        {
            StopAllCoroutines();
            StartCoroutine(Routine());

            IEnumerator Routine()
            {
                while (_loadingCanvas.alpha < 1f)
                {
                    _loadingCanvas.alpha += Time.deltaTime * 5f;
                    yield return null;
                }

                _loadingCanvas.alpha = 1f;
                _loadingCanvas.blocksRaycasts = true;
            }
        }

        public void TerminateLoading()
        {
            StopAllCoroutines();
            StartCoroutine(Routine());

            IEnumerator Routine()
            {
                while (_loadingCanvas.alpha > 0f)
                {
                    _loadingCanvas.alpha -= Time.deltaTime * 5f;
                    yield return null;
                }

                _loadingCanvas.alpha = 0f;
                _loadingCanvas.blocksRaycasts = false;
            }
        }
    }
}
