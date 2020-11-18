/* Refactor to making more abstract:
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Audio Mixers")]
    [SerializeField] List<AudioMixerHolder> audioMixerGroups;
#pragma warning restore 0649

    public List<AudioMixerHolder> AudioMixerGroups { get { return audioMixerGroups; } }

    public void SetMixerVolume(int index, float volume)
    {
        audioMixerGroups[index].Volume = volume;
    }
}

[System.Serializable]
public class AudioMixerHolder
{
    [SerializeField] AudioMixerGroup mixerGroup;

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




