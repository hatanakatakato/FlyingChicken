using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Player;
    //テキストUI
    public GameObject scoreText;
    public GameObject yourBestText;
    public GameObject bestScoreText;
    //ButtonUI
    public GameObject volumeButton;
    public GameObject shearButton;
    public GameObject boxClosedButton;
    public GameObject boxOpenButton;
    public GameObject startButton;
    //PlayerPref
    public int heighScore = 0;
    public int isPlayingGame = 0;//0,1でboolとして使う


    private void Start()
    {
        MenuUI();
        heighScore = PlayerPrefs.GetInt("SCORE", 100);
        Debug.Log(heighScore);
    }



    //ゲーム中のUI
    public void PlayingGameUI()
    {
        scoreText.SetActive(true);
        yourBestText.SetActive(false);
        bestScoreText.SetActive(false);
        volumeButton.SetActive(false);
        shearButton.SetActive(false);
        boxClosedButton.SetActive(false);
        boxOpenButton.SetActive(false);
        startButton.SetActive(false);
    }

    //Menu画面のUI
    public void MenuUI()
    {
        scoreText.SetActive(false);
        yourBestText.SetActive(true);
        bestScoreText.SetActive(true);
        volumeButton.SetActive(true);
        shearButton.SetActive(true);
        //PlayerPefで状態を保存する
        boxClosedButton.SetActive(true);
        boxOpenButton.SetActive(true);
        startButton.SetActive(true);

    }

    //ハイスコア保存
    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("SCORE", score);
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




}
