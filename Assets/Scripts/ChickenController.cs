using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    //コンポーネント宣言
    private Rigidbody2D rb2D;
    private GameObject audioController;

    //変数宣言
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float jumpVectorX = 4f;
    [SerializeField] float jumpVectorY = 10f;
    

    void Start()
    {
        //コンポーネント取得
        this.rb2D = GetComponent<Rigidbody2D>();
        this.audioController = GameObject.Find("AudioController");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch[] myTouches = Input.touches;

            //検出されている指の数だけ回して
            //指の位置にImageを移動
            for (int i = 0; i < myTouches.Length; i++)
            {
                if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x > Screen.width / 2)
                {
                    //画面右タッチ時
                    Debug.Log("右タッチされた");
                    //ジャンプ
                    this.rb2D.velocity = new Vector2(this.jumpVectorX, this.jumpVectorY);
                    //音
                    this.audioController.GetComponent<AudioController>().PlayJumpSound();

                }
                else if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x <= Screen.width / 2)
                {
                    //画面左タッチ時
                    Debug.Log("左タッチされた");
                    //ジャンプ
                    this.rb2D.velocity = new Vector2(-this.jumpVectorX, this.jumpVectorY);
                    //音
                    this.audioController.GetComponent<AudioController>().PlayJumpSound();
                }

            }

        }

    }
}
