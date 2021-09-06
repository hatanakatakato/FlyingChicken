using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NatSuite.Sharing;

public class GameManagerScript : MonoBehaviour
{

    //外部からアサイン
    public AudioController audioController;
    public GameObject Player;
    public AdMobInterstitialScript admobInterstitialScript;
    //テキストUI
    public GameObject scoreText;
    public GameObject yourBestText;
    public GameObject bestScoreText;
    public GameObject lastTimeScoreText;
    public GameObject noKeyPopupText;
    public GameObject noConnectionText;
    //ButtonUI
    public GameObject shearButton;
    public GameObject boxClosedButton;
    public GameObject boxOpenButton;
    public GameObject startButton;
    //PlayerPref
    //"BESTSCORE""LASTSCORE""BOXSTATE""KEY"
    public int heighScore = 0;
    public int lastScore = 0;
    public int isBoxOpen = 0;//0,1でboolとして使う
    private int isKeyFound = 0;
    //変数
    public bool isPlayingGame = false;



    private void Start()
    {

        heighScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        lastScore = PlayerPrefs.GetInt("LASTSCORE", 0);
        isBoxOpen = PlayerPrefs.GetInt("BOXSTATE", 0);
        isKeyFound = PlayerPrefs.GetInt("KEY", 0);

        bestScoreText.GetComponent<Text>().text = $"{heighScore}";
        lastTimeScoreText.GetComponent<Text>().text = $"LastRecord {lastScore}";
        MenuUI();
        //アプリ内評価出現
        if(heighScore > 300)
        {
            StoreReviewManager.Instance.RequestReview();
        }

        //インターステシャル広告を最初は表示しない
        //偶数番目だけ表示する
        RepositoryScript.instance.gameNum += 1;
        if (RepositoryScript.instance.gameNum % 2 == 0)
        {
            admobInterstitialScript.ShowAdMobInterstitial();
        }

    }



    //ネット接続確認後ゲーム中にする(isPlayingGame = true)
    public void PlayingGameUI()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // 機内モードなど、ネットワーク接続エラー状態
            this.gameObject.SetActive(true);
            noConnectionText.GetComponent<NoConnectionTextScript>().deleteTime = 1f;
            noConnectionText.SetActive(true);
            Debug.Log("ネット未接続");
        }
        else
        {
            // ネットワーク接続OK状態
            //UI
            scoreText.SetActive(true);
            yourBestText.SetActive(false);
            bestScoreText.SetActive(false);
            shearButton.SetActive(false);
            boxClosedButton.SetActive(false);
            boxOpenButton.SetActive(false);
            startButton.SetActive(false);
            lastTimeScoreText.SetActive(false);
            noKeyPopupText.SetActive(false);
            noConnectionText.SetActive(false);
            //BGM
            audioController.PlayGameBGM();
            //変数
            StartCoroutine("IsPlayingGameTrue");
        }

    }

    //Menu画面のUI
    public void MenuUI()
    {
        //UI
        scoreText.SetActive(false);
        yourBestText.SetActive(true);
        bestScoreText.SetActive(true);
        shearButton.SetActive(true);
        startButton.SetActive(true);
        lastTimeScoreText.SetActive(true);
        noKeyPopupText.SetActive(false);
        noConnectionText.SetActive(false);
        if(isBoxOpen == 1)
        {
            boxClosedButton.SetActive(false);
            boxOpenButton.SetActive(true);
        }
        else
        {
            boxClosedButton.SetActive(true);
            boxOpenButton.SetActive(false);
        }

        //BGM
        audioController.PlayMenuBGM();
        isPlayingGame = false;

    }

    //ハイスコア保存
    public void SaveBestScore(int score)
    {
        PlayerPrefs.SetInt("BESTSCORE", score);
        PlayerPrefs.Save();
    }
    //前回スコア保存
    public void SaveLastRecord(int score)
    {
        PlayerPrefs.SetInt("LASTSCORE", score);
        PlayerPrefs.Save();
    }

    //isPlayingGameを1フレーム遅れてtrueにする
    //コルーチンにしないとStartButtonを押した時にPlayerがジャンプしてしまうから
    IEnumerator IsPlayingGameTrue()
    {
        yield return null;
        isPlayingGame = true;
    }

    //シーンの再読み込み
    //0.5秒遅らせる
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("リロード");
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);

    }

    //シェア機能
    public void Share()
    {
        var payload = new SharePayload();
        payload.AddText($"Flying Chicken");
        payload.Commit();
    }

    //宝箱ボタンの開け閉め
    public void BoxStateChange()
    {
        if (isKeyFound == 1)
        {
            if(isBoxOpen == 1)
            {
                //箱を閉める
                boxOpenButton.SetActive(false);
                boxClosedButton.SetActive(true);
                isBoxOpen = 0;
                PlayerPrefs.SetInt("BOXSTATE", 0);
                PlayerPrefs.Save();
            }
            else
            {
                //箱を開ける
                boxOpenButton.SetActive(true);
                boxClosedButton.SetActive(false);
                isBoxOpen = 1;
                PlayerPrefs.SetInt("BOXSTATE", 1);
                PlayerPrefs.Save();

            }
        }
        else
        {
            //鍵を探すようにpopupを出す
            noKeyPopupText.SetActive(true);
        }

    }
}
