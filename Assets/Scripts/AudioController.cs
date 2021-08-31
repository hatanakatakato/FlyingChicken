using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //自身のコンポーネント
    private AudioSource audioSource;

    //音ファイルmp3
    public AudioClip jumpSound;
    public AudioClip endSound;
    public AudioClip[] clips;


    void Awake()
    {
        //自身のコンポーネント取得
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    //ジャンプ音再生
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(this.jumpSound);
    }
    //死んだ音再生
    public void PlayEndSound()
    {
        audioSource.PlayOneShot(this.endSound);
    }
    //メニューBGM再生
    public void PlayMenuBGM()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }
    //GameBGM再生
    public void PlayGameBGM()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
