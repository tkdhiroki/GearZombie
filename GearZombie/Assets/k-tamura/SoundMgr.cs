using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr :SingletonMonoBehaviour<SoundMgr>
{
    [SerializeField]
    AudioSource[] audioSource;
    [SerializeField]
    AudioClip[] audioClip;
    public static void BgmPlay(int i)
    {
        instance.audioSource[0].clip = instance.audioClip[i];
        instance.audioSource[0].loop = true;
        instance.audioSource[0].Play();

    }
    private void Start()
    {
        DontDestroyOnLoad(this);
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
