using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr :SingletonMonoBehaviour<SoundMgr>
{
    [SerializeField]
    AudioSource[] audioSource;
    [SerializeField]
    AudioClip[] audioClip;
    bool played;
    public static bool BgmPlay(int i)
    {
        if (i >= instance.audioClip.Length)
            return false;
        instance.audioSource[0].clip = instance.audioClip[i];
        instance.audioSource[0].volume = 0.7f;
        instance.audioSource[0].Play();
        instance.played = true;
        return true;



    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
       if(!instance.audioSource[0].isPlaying && instance.played)
        {
            instance.audioSource[0].Play();
        }
    }
    public static void SeShot(int soundNum)
    {
        for(var i=1;i<=instance.audioSource.Length;i++)
        {
            if(!instance.audioSource[i].isPlaying)
            {
                instance.audioSource[i].PlayOneShot(instance.audioClip[soundNum]);
                return;
            }
        }
    }
}
class SoundData
{

}
