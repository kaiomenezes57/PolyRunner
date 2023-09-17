using UnityEngine;

namespace PolyRunner.Audio
{
    [CreateAssetMenu(menuName = "Scriptables/Music")]
    public class Music : ScriptableObject
    {
        public string musicName;
        public FMODUnity.EventReference musicPath;
    }
}
