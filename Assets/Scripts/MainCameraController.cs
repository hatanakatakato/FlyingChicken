using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Camera camera;
    public float baseWidth = 9.0f;
    public float baseHeight = 16.0f;

    void Awake()
    {
        Debug.Log($"ベース維持開始:camera.orthographic = {this.camera.orthographicSize}");
        // ベース維持
        var scaleWidth = (Screen.height / this.baseHeight) * (this.baseWidth / Screen.width);
        var scaleRatio = Mathf.Max(scaleWidth, 1.0f);
        this.camera.orthographicSize *= scaleRatio;
        Debug.Log($"ベース維持終了:camera.orthographic = {this.camera.orthographicSize}");
    }
}
