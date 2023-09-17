using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PolyRunner.Audio
{
    public partial class MusicPlayer : MonoBehaviour
    {
        private FMOD.Studio.EventInstance _instance;
        [SerializeField] private List<Music> _musics;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _forwardButton;

        private Music _currentMusic;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            RandomizeMusic();

            _playButton.onClick.AddListener(() => {
                _instance.getPaused(out bool paused);
                _instance.setPaused(!paused);
            });

            _backButton.onClick.AddListener(() => {
                int currentIndex = _musics.IndexOf(_currentMusic);
                if ((currentIndex - 1) < 0) { currentIndex = _musics.Count; }

                ChangeMusic(_musics[currentIndex - 1]);
            });

            _forwardButton.onClick.AddListener(() => {
                int currentIndex = _musics.IndexOf(_currentMusic);
                if ((currentIndex + 1) > (_musics.Count - 1)) { currentIndex = -1; }

                ChangeMusic(_musics[currentIndex + 1]);
            });
        }

        private void RandomizeMusic()
        {
            Music music = _musics[Random.Range(0, _musics.Count)];
            ChangeMusic(music);
        }

        public void ChangeMusic(Music music)
        {
            FMODUnity.EventReference path = music.musicPath;
            _instance.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
            
            if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                _instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                _instance.release();
            }

            _instance = FMODUnity.RuntimeManager.CreateInstance(path);
            _instance.start();
            _instance.release();

            ShowCurrentMusicVisual(music);
            _currentMusic = music;
        }
    }

    public partial class MusicPlayer
    {
        [Space, SerializeField] private TextMeshProUGUI _musicInfoText;
        [SerializeField] private float _textFadeMultiplier = 3f;
        private CanvasGroup _canvasGroup;

        private void ShowCurrentMusicVisual(Music music)
        {
            StartCoroutine(Routine());
            IEnumerator Routine()
            {
                while (_canvasGroup.alpha > 0f)
                {
                    _canvasGroup.alpha -= Time.deltaTime * _textFadeMultiplier;
                    yield return null;
                }

                _musicInfoText.text = music.musicName;
                yield return new WaitForSeconds(0.5f);

                while (_canvasGroup.alpha < 1f)
                {
                    _canvasGroup.alpha += Time.deltaTime * _textFadeMultiplier;
                    yield return null;
                }
            }
        }
    }
}
