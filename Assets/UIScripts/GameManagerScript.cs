using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public AudioController audioController;
    public GameObject Player;
    //テキストUI
    public GameObject scoreText;
    public GameObject yourBestText;
    public GameObject bestScoreText;
    public GameObject lastTimeScoreText;
    //ButtonUI
    public GameObject volumeButton;
    public GameObject shearButton;
    public GameObject boxClosedButton;
    public GameObject boxOpenButton;
    public GameObject startButton;
    //PlayerPref
    public int heighScore = 0;
    public int lastScore = 0;
    public int isBoxOpen = 0;//0,1でboolとして使う
    //変数
    public bool isPlayingGame = false;


    private void Start()
    {
        heighScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        lastScore = PlayerPrefs.GetInt("LASTSCORE", 0);
        isBoxOpen = PlayerPrefs.GetInt("BOXSTATE", 0);
        Debug.Log($"{heighScore},{lastScore}");
        bestScoreText.GetComponent<Text>().text = $"{heighScore}";
        lastTimeScoreText.GetComponent<Text>().text = $"LastRecord {lastScore}";
        MenuUI();

    }



    //ゲーム中
    public void PlayingGameUI()
    {
        //UI
        scoreText.SetActive(true);
        yourBestText.SetActive(false);
        bestScoreText.SetActive(false);
        volumeButton.SetActive(false);
        shearButton.SetActive(false);
        boxClosedButton.SetActive(false);
        boxOpenButton.SetActive(false);
        startButton.SetActive(false);
        lastTimeScoreText.SetActive(false);
        //BGM
        audioController.PlayGameBGM();
        //変数
        StartCoroutine("IsPlayingGameTrue");
    }

    //Menu画面のUI
    public void MenuUI()
    {
        //UI
        scoreText.SetActive(false);
        yourBestText.SetActive(true);
        bestScoreText.SetActive(true);
        volumeButton.SetActive(true);
        shearButton.SetActive(true);
        startButton.SetActive(true);
        lastTimeScoreText.SetActive(true);
        BoxStateChange(isBoxOpen);
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


    //シーンの再読み込み
    public void ReloadScene()
    {
        Debug.Log("リロード");
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }

    //宝箱の開け閉め
    public void BoxStateChange(int isBoxOpen)
    {
        if (isBoxOpen == 1)
        {
            boxClosedButton.SetActive(false);
            boxOpenButton.SetActive(true);
        }
        else
        {
            boxClosedButton.SetActive(true);
            boxOpenButton.SetActive(false);
        }
    }

    //isPlayingGameを1フレーム遅れてtrueにする
    //コルーチンにしないとStartButtonを押した時にPlayerがジャンプしてしまうから
    IEnumerator IsPlayingGameTrue()
    {
        yield return null;
        isPlayingGame = true;
    }


}
