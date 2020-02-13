using UnityEngine;

namespace Production.Scripts.Framework
{
    [System.Serializable]
    public class Sounds
    {
        public string name;
        public AudioClip clip;

        [Range (0f,1f)]
        public float Volume;
        [Range(.1f,3f)]
        public float pitch;

        [HideInInspector]
        public AudioSource source;

    }
}
