using System.Collections.Generic;
using UnityEngine;

public class UIAudioController : MonoBehaviour
{
#pragma warning disable 0649
    AudioController audioController;
    [Header("Sliders")]
    [SerializeField] List<AudioSlider> audioSliders;
    //[SerializeField] AudioSlider masterSlider;
    //[SerializeField] AudioSlider musicSlider;
    //[SerializeField] AudioSlider sfxSlider;
#pragma warning restore 0649


    public void SetMasterMixerVolume(float volume)
    {
        audioController.SetMixerVolume(0, volume);
        audioSliders[0].UpdateSlider(audioController.AudioMixerGroups[0].Volume);
    }

    public void SetMusicMixerVolume(float volume)
    {
        audioController.SetMixerVolume(1, volume);
        audioSliders[1].UpdateSlider(audioController.AudioMixerGroups[1].Volume);
    }

    public void SetSFXMixerVolume(float volume)
    {
        audioController.SetMixerVolume(2, volume);
        audioSliders[2].UpdateSlider(audioController.AudioMixerGroups[2].Volume);
    }

    void AudioController_OnVolumeChange(object sender, System.EventArgs e)
    {
        SyncSliders();
        Debug.LogWarning("Volume Updated.");
    }

    bool SyncSliders()
    {
        if (audioSliders.Count != audioController.AudioMixerGroups.Count)
        {
            return false;
        }
        for (int i = 0; i < audioSliders.Count; i++)
        {
            audioSliders[i].SetSlider(audioController.AudioMixerGroups[i].Volume);
        }
        return true;
    }

    void Awake()
    {
        audioController = audioController ? audioController : FindObjectOfType<AudioController>();
    }

    void Start()
    {
        SyncSliders();
        audioController.OnVolumeChange += AudioController_OnVolumeChange;
    }
}





