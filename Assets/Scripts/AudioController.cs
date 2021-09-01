using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //自身のコンポーネント
    public AudioSource myAudioSource;

    //音ファイルmp3
    public AudioClip jumpSound;
    public AudioClip endSound;
    public AudioClip[] clips;

    //ジャンプ音再生
    public void PlayJumpSound()
    {
        myAudioSource.PlayOneShot(this.jumpSound);
    }
    //死んだ音再生
    public void PlayEndSound()
    {
        myAudioSource.PlayOneShot(this.endSound);
    }
    //メニューBGM再生
    public void PlayMenuBGM()
    {
        myAudioSource.clip = clips[0];
        myAudioSource.Play();
    }
    //GameBGM再生
    public void PlayGameBGM()
    {
        myAudioSource.clip = clips[1];
        myAudioSource.Play();
    }
}
