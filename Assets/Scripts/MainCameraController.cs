using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //自身のコンポーネント
    public Camera myCamera;
    //外部のコンポーネント
    public Transform playerTransform;

    //ベースのアスペクト比を16:9にする
    public float baseWidth = 9.0f;
    public float baseHeight = 16.0f;
    //Playerよりカメラを高い位置におく
    public float distanceHeight = 4.2f;

    void Awake()
    {
        // ベース維持
        var scaleWidth = (Screen.height / this.baseHeight) * (this.baseWidth / Screen.width);
        var scaleRatio = Mathf.Max(scaleWidth, 1.0f);
        this.myCamera.orthographicSize *= scaleRatio;
    }

    private void Update()
    {
        //カメラをplayerに合わせて動かす

        this.transform.position = new Vector3(0f, playerTransform.position.y + distanceHeight, -10f);
    }

}
