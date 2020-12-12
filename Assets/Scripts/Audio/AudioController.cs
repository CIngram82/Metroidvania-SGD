/* Refactor to making more abstract:
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public event EventHandler OnVolumeChange;

#pragma warning disable 0649
    [Header("Audio Mixers")]
    [SerializeField] List<AudioMixerHolder> audioMixerGroups;
#pragma warning restore 0649

    public List<AudioMixerHolder> AudioMixerGroups { get { return audioMixerGroups; } }

    public void SetMixerVolume(int index, float volume)
    {
        audioMixerGroups[index].Volume = volume;
    }
    /// <summary>
    /// Converts a percentage to dB scale.
    /// </summary>
    /// <param name="percent">Percent of Max volume.</param>
    /// <returns>Volume in Decibels.</returns>
    public static float PercentToVolume(float percent)
    {
        return Mathf.Log10(percent / 100) * 20;
    }
    /// <summary>
    /// Converts dB scale to a percentage.
    /// </summary>
    /// <param name="volume"></param>
    /// <returns>Percentage of Max volume.</returns>
    public static float VolumeToPercent(float volume)
    {
        return Mathf.Pow(10, volume / 20);
    }

    void Start()
    {
        AudioManager.AM.Play(AudioManager.AM.GetMusic(), "music_");
        SetMixerVolume(1, 0.3f);     //Sets Music volume to 30%
        OnVolumeChange?.Invoke(this, EventArgs.Empty);
    }
}

[System.Serializable]
public class AudioMixerHolder
{
#pragma warning disable 0649
    [SerializeField] AudioMixerGroup mixerGroup;
#pragma warning restore 0649


    public string Name { get { return mixerGroup.name; } }
    public float Volume
    {
        get
        {
            mixerGroup.audioMixer.GetFloat(Name + "Volume", out float volume);
            return volume;
        }
        set
        {
            mixerGroup.audioMixer.SetFloat(Name + "Volume", LogScale(value));
        }
    }

    float LogScale(float value)
    {
        return Mathf.Log10(value) * 20;
    }
}




