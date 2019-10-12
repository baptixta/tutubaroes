using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;
    [Range(0.5f,1.5f)]
    public float volume = 0.7f;
    private AudioSource source;

    public void setSource (AudioSource _source) {
        source = _source;
        source.clip = clip;
    }

    public void Play () {
        source.volume = volume;
        source.Play();
    }
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake() {
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene");
        } else
        {
            instance = this;       
        }
    }

    void Start() {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].setSource(_go.AddComponent<AudioSource>()); 
        }
    }

    public void PlaySound (string _name) {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        // no sound for _name
        Debug.LogWarning("AudioManager: sound not found in list" + _name);
    }
}
