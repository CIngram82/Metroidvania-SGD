using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Audio Mixers")]
    [SerializeField] AudioMixerGroup masterMixerGroup;
    [SerializeField] AudioMixerGroup effectsMixerGroup;
    [SerializeField] AudioMixerGroup musicMixerGroup;
    [Header("Sliders")]
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;
#pragma warning restore 0649


    public void SetMasterVolume(float volume)
    {
        masterMixerGroup.audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetEffectVolume(float volume)
    {
        effectsMixerGroup.audioMixer.SetFloat("EffectVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", volume);
    }

    void Start()
    {
        float volume;

        masterMixerGroup.audioMixer.GetFloat("MasterVolume", out volume);
        masterSlider.value = volume;

        effectsMixerGroup.audioMixer.GetFloat("EffectVolume", out volume);
        effectsSlider.value = volume;

        musicMixerGroup.audioMixer.GetFloat("MusicVolume", out volume);
        musicSlider.value = volume;
    }
}





