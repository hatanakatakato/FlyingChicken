using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //外部のコンポーネント取得
    public AudioController audioController;

    //画面の状態
    private bool isPlayingGame = false;


    void Start()
    {
        //MeneBGMを鳴らす
        audioController.PlayMenuBGM();
    }

    void Update()
    {
        //画面タッチかつゲーム中でないならゲームBGM再生
        if (Input.touchCount > 0 && !isPlayingGame)
        {
            audioController.PlayGameBGM();
            isPlayingGame = true;
        }
    }
}
