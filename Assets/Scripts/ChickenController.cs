using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenController : MonoBehaviour
{
    //コンポーネント宣言
    private Rigidbody2D rb2D;
    private GameObject audioController;
    private Animator myAnimator;
    private GameObject scoreText;

    //変数宣言
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float jumpVectorX = 4f;
    [SerializeField] float jumpVectorY = 10f;
    //無敵時間
    public float invincibleTime = 0f;
    //フライドチキン獲得点
    private int friedChickenScore = 0;


    void Start()
    {
        //コンポーネント取得
        this.rb2D = GetComponent<Rigidbody2D>();
        this.audioController = GameObject.Find("AudioController");
        this.myAnimator = GetComponent<Animator>();
        this.scoreText = GameObject.Find("ScoreText");
    }

    void Update()
    {
        //スコア計算と表示
        ScoreCalculator();

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
                    //右ジャンプ
                    this.Jump(true);

                }
                else if (myTouches[i].phase == TouchPhase.Began && myTouches[i].position.x <= Screen.width / 2)
                {
                    //左ジャンプ
                    this.Jump(false);
                }

            }

        }

        //落下の速度制限
        if (this.rb2D.velocity.y < -10f)
        {
            this.rb2D.velocity = new Vector2(this.rb2D.velocity.x, -10f);
        }

    }

    //BombとWoodに当たった時
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //木に当たる
        if (collision.gameObject.CompareTag("WoodTag"))
        {
            ContactPoint2D[] contact = collision.contacts;
            if (contact[0].point.x < 0)
            {
                //右ジャンプ
                this.Jump(true);
            }
            else
            {
                //左ジャンプ
                this.Jump(false);
            }

        }

        //Bombに当たる
        if (collision.gameObject.CompareTag("BombTag"))
        {
            this.myAnimator.SetTrigger("EndTrigger");
        }
    }

    //friedChickenに当たった時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //フライドチキンに当たる
        if (collision.gameObject.CompareTag("FriedChickenTag"))
        {
            this.friedChickenScore += 100;
        }
    }

    //左右ジャンプ
    private void Jump(bool isRight)
    {
        if (isRight)
        {
            //右ジャンプ
            this.myAnimator.SetTrigger("RightJumpTrigger");
            this.rb2D.velocity = new Vector2(this.jumpVectorX, this.jumpVectorY);
        }
        else
        {
            //左ジャンプ
            this.myAnimator.SetTrigger("LeftJumpTrigger");
            this.rb2D.velocity = new Vector2(-this.jumpVectorX, this.jumpVectorY);
        }

        //無敵状態じゃないならジャンプ音を鳴らす
        if (this.invincibleTime <= 0)
        {
            this.audioController.GetComponent<AudioController>().PlayJumpSound();
        }
    }

    //スコア計算と表示
    private void ScoreCalculator()
    {
        //計算
        int score = (int)this.transform.position.y + this.friedChickenScore + 4;
        //表示
        this.scoreText.GetComponent<Text>().text = $"Score:{score}";
    }



}
