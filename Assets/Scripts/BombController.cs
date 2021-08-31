using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator myAnimator;
    private GameObject playerChicken;

    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.playerChicken = GameObject.Find("Chicken");
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
        }
    }
}
