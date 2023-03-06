using UnityEngine;

[RequireComponent(typeof(AudioStorage))]
public class AudioHandler : MonoBehaviour
{
    AudioSource _audioSource;
    AudioStorage _audioStorage;

    void OnEnable()
    {
        UI_Counter.PlayAudio += PlayAudio;
    }

    void OnDisable()
    {
        UI_Counter.PlayAudio -= PlayAudio;
    }

    void Awake()
    {
        _audioStorage = GetComponent<AudioStorage>();
        _audioSource = GetComponent<AudioSource>();
    }

    void PlayAudio(string audioName)
    {
        var audio = _audioStorage.GetAudio(audioName);

        if(_audioSource != null && audio != null)
        {
            _audioSource.PlayOneShot(audio);
        } 
    }
}
