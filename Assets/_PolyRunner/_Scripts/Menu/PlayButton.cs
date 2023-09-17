using PolyRunner.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PolyRunner.Menu
{
    public class PlayButton : MonoBehaviour
    {
        private Button _playButton;

        private void Start()
        {
            _playButton = GetComponent<Button>();
            _playButton.onClick.AddListener(() => {
                WarningScreen.Instance.ShowWarningScreen("Play", "Are you sure you want to start the run?", () => SceneManager.LoadSceneAsync(1));
            });
        }
    }
}
