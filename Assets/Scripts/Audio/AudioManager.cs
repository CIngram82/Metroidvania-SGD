using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AM;
#pragma warning disable 0649
    [SerializeField] GameObject audioSource;
    [Header("Audio Mixers")]
    [SerializeField] AudioMixerGroup sfxMixerGroup;
    [SerializeField] AudioMixerGroup musicMixerGroup;
    [Header("Sounds")]
    [SerializeField] Sound[] sfx;
    [SerializeField] Sound[] music;
#pragma warning restore 0649

    public Sound[] GetSFX() { return sfx; }
    public Sound[] GetMusic() { return music; }
    public bool HasLoaded { get; set; }


    public IEnumerator PlayChain(Sound[] sounds, bool loop)
    {
        while (loop)
        {
            foreach (Sound s in sounds)
            {
                if (s == null)
                {
                    Debug.LogWarning("Sound: " + s.Name + " not found!");
                    break;
                }
                Debug.Log("Playing: " + s.Name);

                s.AudioSource.volume = s.Volume * (1f + UnityEngine.Random.Range(-s.VolumeVar / 2f, s.VolumeVar / 2f));
                s.AudioSource.pitch = s.Pitch * (1f + UnityEngine.Random.Range(-s.PitchVar / 2f, s.PitchVar / 2f));
                s.AudioSource.Play();
                Debug.Log("Sound Length: " + s.AudioSource.clip.length);
                yield return new WaitForSeconds(s.AudioSource.clip.length);
            }
        }
    }

    public void Play(Sound[] sounds, string sound, int num = 0)
    {
        sound += num;
        Sound s = Array.Find(sounds, item => item.Name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found!");
            return;
        }
        Debug.Log("Playing: " + sound);

        s.AudioSource.volume = s.Volume * (1.0f + UnityEngine.Random.Range(-s.VolumeVar / 2.0f, s.VolumeVar / 2.0f));
        s.AudioSource.pitch = s.Pitch * (1.0f + UnityEngine.Random.Range(-s.PitchVar / 2.0f, s.PitchVar / 2.0f));
        s.Play();
    }

    void LoadAudioSource(Sound[] sounds, AudioMixerGroup mixerGroup)
    {
        foreach (Sound s in sounds)
        {
            s.SetAudioSource(audioSource.AddComponent<AudioSource>());
            s.AudioSource.outputAudioMixerGroup = mixerGroup;
        }
    }

    void Awake()
    {
        if (AM != null && AM != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            AM = this;
        }
        DontDestroyOnLoad(gameObject);

        LoadAudioSource(music, musicMixerGroup);
        LoadAudioSource(sfx, sfxMixerGroup);
    }

    void Start()
    {

    }
}





