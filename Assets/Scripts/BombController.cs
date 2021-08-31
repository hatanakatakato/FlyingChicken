using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator myAnimator;

    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //爆発アニメーション再生
            myAnimator.SetTrigger("Explosion");
            //短いバイブ
            VibrationMng.ShortVibration();
        }
    }
}
