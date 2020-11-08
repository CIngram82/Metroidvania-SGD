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
	[SerializeField] bool loop = false;
	[SerializeField] AudioSource source;
#pragma warning restore 0649
	AudioMixerGroup mixerGroup;

	
	public string Name
	{
		get { return name; }
	}

	public AudioSource AudioSource
	{
		get { return source; }
		set { source = value; }
	}
	public AudioClip Clip
	{
		get { return clip; }
	}

	public float Volume
	{
		get { return volume; }
	}
	public float VolumeVar
	{
		get { return volumeVariance; }
	}

	public float Pitch
	{
		get { return pitch; }
	}
	public float PitchVar
	{
		get { return pitchVariance; }
	}

	public bool Loop
	{
		get { return loop; }
	}

	public int Priority
	{
		get { return priority; }
	}
}





