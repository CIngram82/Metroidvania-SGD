using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
#pragma warning disable 0649
    [SerializeField] string name;
    [SerializeField] AudioClip clip;
    [Range(0f, 1f)]
    [SerializeField] float volume = 1.0f;
    [Range(0f, 1f)]
    [SerializeField] float volumeVariance = 0.1f;
    [Range(.1f, 3f)]
    [SerializeField] float pitch = 1.0f;
    [Range(0f, 1f)]
    [SerializeField] float pitchVariance = 0.1f;
    [Range(0f, 256f)]
    [SerializeField] int priority = 128;
    [SerializeField] bool playOnAwake = false;
    [SerializeField] bool loop = false;
#pragma warning restore 0649
    AudioMixerGroup mixerGroup;

    public AudioSource AudioSource { get; private set; }
    public string Name { get { return name; } }
    public float Volume { get { return volume; } }
    public float VolumeVar { get { return volumeVariance; } }
    public float Pitch { get { return pitch; } }
    public float PitchVar { get { return pitchVariance; } }


    public void SetAudioSource(AudioSource audioSource)
    {
        AudioSource = audioSource;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.playOnAwake = playOnAwake;
        audioSource.priority = priority;
        audioSource.loop = loop;
    }

    public void Play()
    {
        AudioSource.Play();
    }
}





