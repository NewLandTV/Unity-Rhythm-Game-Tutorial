using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    [SerializeField]
    private Sound[] bgmSounds;
    [SerializeField]
    private Sound[] sfxSounds;

    [SerializeField]
    private AudioSource bgmPlayer;
    [SerializeField]
    private AudioSource[] sfxPlayers;

    private Action onBgmEnd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!bgmPlayer.isPlaying)
        {
            onBgmEnd?.Invoke();

            onBgmEnd = null;
        }
    }

    public void PlayBGM(string name, bool loop = false, Action onEnd = null)
    {
        onBgmEnd = onEnd;

        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (bgmSounds[i].name.Equals(name))
            {
                bgmPlayer.clip = bgmSounds[i].clip;
                bgmPlayer.loop = loop;

                bgmPlayer.Play();

                return;
            }
        }
    }

    public void PauseBGM(bool pause)
    {
        if (pause)
        {
            bgmPlayer.Pause();
        }
        else
        {
            bgmPlayer.UnPause();
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string name)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (sfxSounds[i].name.Equals(name))
            {
                for (int j = 0; j < sfxPlayers.Length; j++)
                {
                    if (!sfxPlayers[j].isPlaying)
                    {
                        sfxPlayers[j].clip = sfxSounds[i].clip;

                        sfxPlayers[j].Play();

                        return;
                    }
                }

                return;
            }
        }
    }
}
