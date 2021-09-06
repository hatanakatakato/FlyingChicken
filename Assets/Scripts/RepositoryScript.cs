using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositoryScript : MonoBehaviour
{
    //シングルトン
    static public RepositoryScript instance;
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    //ゲーム回数
    //インターステシャル広告表示のために使う
    public int gameNum = 0;
}
