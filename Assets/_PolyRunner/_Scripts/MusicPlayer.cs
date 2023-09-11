using UnityEngine;

namespace PolyRunner
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private int _debugIndex;
        [SerializeField] FMODUnity.EventReference[] _musics;

        private void Start()
        {
#if UNITY_EDITOR
            if (_debugIndex > -1)
            {
                FMODUnity.RuntimeManager.PlayOneShot(_musics[_debugIndex]);
                return;
            }
#endif

            FMODUnity.EventReference music = _musics[Random.Range(0, _musics.Length)];
            FMODUnity.RuntimeManager.PlayOneShot(music);
        }
    }
}
