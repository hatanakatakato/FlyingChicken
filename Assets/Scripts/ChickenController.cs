using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    //コンポーネント宣言
    private Rigidbody2D rb2D;
    private GameObject audioController;
    private Animator myAnimator;

    //変数宣言
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float jumpVectorX = 4f;
    [SerializeField] float jumpVectorY = 10f;
    

    void Start()
    {
        //コンポーネント取得
        this.rb2D = GetComponent<Rigidbody2D>();
        this.audioController = GameObject.Find("AudioController");
        this.myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //タッチ操作
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
                    this.Jump("Right");

                }
                else if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x <= Screen.width / 2)
                {
                    //画面左タッチ時
                    this.Jump("Left");
                }

            }

        }

        //落下の速度制限
        if(this.rb2D.velocity.y < -10f)
        {
            this.rb2D.velocity = new Vector2(this.rb2D.velocity.x, -10f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //木に当たる
        if (collision.gameObject.CompareTag("WoodTag"))
        {
            ContactPoint2D[] contact = collision.contacts;
            if (contact[0].point.x < 0)
            {
                //右ジャンプ
                this.Jump("Right");
            }
            else
            {
                //左ジャンプ
                this.Jump("Left");
            }

        }

        //Bombに当たる
        if (collision.gameObject.CompareTag("BombTag"))
        {
            this.myAnimator.SetTrigger("EndTrigger");
        }

        //フライドチキンに当たる
        if (collision.gameObject.CompareTag("FriedChickenTag"))
        {
            //フライドチキンは休憩ポイント
        }
    }

    //左右ジャンプ//direction"Right"or"Left"
    private void Jump(string direction)
    {
        if(direction == "Right")
        {
            //右ジャンプ
            this.myAnimator.SetTrigger("RightJumpTrigger");
            this.rb2D.velocity = new Vector2(this.jumpVectorX, this.jumpVectorY);
        }else if(direction == "Left")
        {
            //左ジャンプ
            this.myAnimator.SetTrigger("LeftJumpTrigger");
            this.rb2D.velocity = new Vector2(-this.jumpVectorX, this.jumpVectorY);
        }

        //音
        this.audioController.GetComponent<AudioController>().PlayJumpSound();
    }



}
