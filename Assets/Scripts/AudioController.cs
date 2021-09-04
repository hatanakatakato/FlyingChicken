using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //自身のコンポーネント
    public AudioSource myBGMAudioSource;
    public AudioSource mySEAudioSource;
    public AudioSource myBIGSEAudioSource;

    //音ファイルmp3
    public AudioClip keySound;
    public AudioClip jumpSound;
    public AudioClip endSound;
    public AudioClip eatingSound;
    public AudioClip[] clips;


    //ジャンプ音再生
    public void PlayJumpSound()
    {
        mySEAudioSource.PlayOneShot(this.jumpSound);
    }
    //死んだ音再生
    public void PlayEndSound()
    {
        mySEAudioSource.PlayOneShot(this.endSound);
    }
    //メニューBGM再生
    public void PlayMenuBGM()
    {
        myBGMAudioSource.clip = clips[0];
        myBGMAudioSource.Play();
    }
    //GameBGM再生
    public void PlayGameBGM()
    {
        myBGMAudioSource.clip = clips[1];
        myBGMAudioSource.Play();
    }
    //肉食った音再生
    public void PlayEatingSound()
    {
        myBIGSEAudioSource.PlayOneShot(this.eatingSound);

    }
    //鍵音再生
    public void PlayKeySound()
    {
        mySEAudioSource.PlayOneShot(keySound);
    }

}
