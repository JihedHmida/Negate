using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    private static bool isInit = false;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    private static Dictionary<Sound, AudioClip> soundAudioClipDictionary;

    public enum Sound
    {
        x,
        y,
        z,
        w
    }

    public static void Initialize()
    {
        if (!isInit)
        {
            GetSoundGameAssets();
            isInit = true;
        }
    }

    public static void PlaySound(Sound sound)
    {
        //    Initialize(); //TODO to remove in production Init is called by the GameHandler
        if (!oneShotGameObject)
        {
            oneShotGameObject = new GameObject("One Shot Sound");
            oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }
        oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        //    Initialize(); //TODO to remove in production Init is called by the GameHandler
        GameObject soundGameObject = new GameObject("Position Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();


        Object.Destroy(soundGameObject, audioSource.clip.length);
    }

    public static AudioClip GetAudioClip(Sound sound)
    {
        if (soundAudioClipDictionary.ContainsKey(sound))
        {
            return soundAudioClipDictionary[sound];
        }
        Debug.LogWarning("Sound " + sound + " Not found!!");
        return null;
    }

    public static void GetSoundGameAssets()
    {
        soundAudioClipDictionary = new Dictionary<Sound, AudioClip>();
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.soundAudioClips)
        {
            soundAudioClipDictionary.Add(soundAudioClip.sound, soundAudioClip.audioClip);
        }
    }
}
