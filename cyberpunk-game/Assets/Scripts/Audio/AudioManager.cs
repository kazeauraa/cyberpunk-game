using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] Audio[] sounds;
    [SerializeField] Audio[] musics;

    [SerializeField] AudioSource musicAudioSource;

    public void PlaySound(string id, Vector2 spawnPosition, float pitch = 1f)
    {
        if (id == "") return;

        Audio sound = Array.Find(sounds, sound => sound.id == id);

        if (sound == null)
        {
            Debug.LogError($"Sound \"{id}\" not found!");

            return;
        }

        Sound soundObject = PoolManager.Instance.Instantiate("sound", spawnPosition, Quaternion.identity)
                                    .GetComponent<Sound>();


        soundObject.SetSound(sound.clip, pitch);
    }

    public void PlayMusic(string id)
    {
        if (id == "") return;

        Audio music = Array.Find(musics, music => music.id == id);

        if (music == null)
        {
            Debug.LogError($"Music \"{id}\" not found!");

            return;
        }

        musicAudioSource.clip = music.clip;
        musicAudioSource.loop = music.isLooped;

        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public bool IsMusicPlaying()
    {
        return musicAudioSource.isPlaying;
    }
}