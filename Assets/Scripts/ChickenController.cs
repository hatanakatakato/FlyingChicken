using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    //コンポーネント宣言
    private Rigidbody2D rb2D;
    private AudioSource audioSource;

    //変数宣言
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float jumpVectorX = 4f;
    [SerializeField] float jumpVectorY = 10f;
    public AudioClip sound1;
    

    void Start()
    {
        //コンポーネント取得
        this.rb2D = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //タッチ情報の取得
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2)
            {
                //画面右タッチ時
                Debug.Log("右タッチされた");
                this.rb2D.velocity = new Vector2(this.jumpVectorX, this.jumpVectorY);
                audioSource.PlayOneShot(sound1);

            }
            else if(touch.phase == TouchPhase.Began && touch.position.x <= Screen.width / 2)
            {
                //画面左タッチ時
                Debug.Log("左タッチされた");
                this.rb2D.velocity = new Vector2(-this.jumpVectorX, this.jumpVectorY);
                audioSource.PlayOneShot(sound1);
            }

        }

    }
}
