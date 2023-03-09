using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AudioStorage : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> _audios;

    public AudioClip GetAudio( string audioName ){
        return _audios.Where( obj => obj.name == audioName ).SingleOrDefault();
    }
}
