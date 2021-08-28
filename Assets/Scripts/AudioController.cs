using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //AudioSource宣言
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip endSound;


    void Start()
    {
        //取得
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(this.jumpSound);
    }

    public void PlayEndSound()
    {
        audioSource.PlayOneShot(this.endSound);
    }
}
