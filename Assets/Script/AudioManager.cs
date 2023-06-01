using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	
	void Awake()
	{
		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.pitch = s.pitch;
            s.source.volume = s.volume;
			s.source.loop = s.loop;
			s.source.playOnAwake = s.playOnStart;
			if(s.playOnStart){
				s.source.Play();
			}
		}
	}
	
    /// <returns>Length of the sound clip</returns>
    public float PlaySound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if(s == null) {
            Debug.LogWarning($"Sound {name} not found!");
            return 0f;
        }

        s.source.Play();
        return s.clip.length;
    }

    public Sound GetSound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if(s == null) {
            Debug.LogWarning($"Sound {name} not found!");
        }

        return s;
    }

    public void StopSound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if(s == null) {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        s.source.Stop();
    }
}


[System.Serializable]
public class Sound
{
	public string name;
	
	public AudioClip clip;
	
	public enum AudioTypes 
	{ 
		SFX, 
		EndSFX, 
		Main 
	}
	public AudioTypes type;
	
	[Range(.1f, 3f)]
	public float pitch;
    [Range(.1f, 3f)]
    public float volume;
	public bool loop;
	public bool playOnStart;
	
	[HideInInspector]
	public AudioSource source;
}
