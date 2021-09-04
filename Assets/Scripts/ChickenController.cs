using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenController : MonoBehaviour
{
    //自身のコンポーネント
    private Rigidbody2D myRb2D;
    private Animator myAnimator;
    //外部から注入するコンポーネント
    public AudioController audioController;
    public Text scoreText;
    public GameManagerScript gameManager;
    //速度
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float jumpVectorX = 4f;
    [SerializeField] float jumpVectorY = 10f;
    //フライドチキン獲得点
    private int friedChickenScore = 0;
    //スコア
    public int gameScore = 0;

 
    void Start()
    {
        //自身のコンポーネント取得
        this.myRb2D = GetComponent<Rigidbody2D>();
        this.myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameManager.isPlayingGame)
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
            if (this.myRb2D.velocity.y < -this.maxVelocity)
            {
                this.myRb2D.velocity = new Vector2(this.myRb2D.velocity.x, -this.maxVelocity);
            }

        }

    }

    //BombとWoodに当たった時
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.isPlayingGame)
        {
            //木に当たる
            if (collision.gameObject.CompareTag("WoodTag"))
            {
                //当たったx座標の正負でジャンプ方向を決める
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
                //死亡アニメ,音,タップ反応なし
                gameManager.isPlayingGame = false;
                myAnimator.SetTrigger("EndTrigger");
                audioController.PlayEndSound();
                //前回スコアを更新
                gameManager.SaveLastRecord(gameScore);
                //ハイスコアを更新していたらハイスコア更新
                if (gameScore > gameManager.heighScore)
                {
                    gameManager.heighScore = gameScore;
                    // スコアを保存
                    gameManager.SaveBestScore(gameScore);
                }
                //シーンをリロード
                gameManager.StartCoroutine("ReloadScene");

            }

        }
    }

    //friedChicken,Keyに当たった
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.isPlayingGame)
        {
            if (collision.gameObject.CompareTag("FriedChickenTag"))
            {
                this.friedChickenScore += 100;
                Destroy(collision.gameObject);
                audioController.PlayEatingSound();
            }else if (collision.gameObject.CompareTag("KeyTag"))
            {
                //鍵が発見された
                PlayerPrefs.SetInt("KEY", 1);
                PlayerPrefs.Save();
                Destroy(collision.gameObject);
                audioController.PlayKeySound();
            }
            
        }

    }

    //左右ジャンプ
    private void Jump(bool isRight)
    {
        if (isRight)
        {
            //右ジャンプ
            this.myAnimator.SetTrigger("RightJumpTrigger");
            this.myRb2D.velocity = new Vector2(this.jumpVectorX, this.jumpVectorY);
        }
        else
        {
            //左ジャンプ
            this.myAnimator.SetTrigger("LeftJumpTrigger");
            this.myRb2D.velocity = new Vector2(-this.jumpVectorX, this.jumpVectorY);
        }

        //無敵状態じゃないならジャンプ音を鳴らす

        this.audioController.PlayJumpSound();
    }

    //スコア計算と表示
    private void ScoreCalculator()
    {
        //計算
        gameScore = (int)this.transform.position.y + this.friedChickenScore + 4;
        //表示
        scoreText.text = $"Record {gameScore}";
    }



}
