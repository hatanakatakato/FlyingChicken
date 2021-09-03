using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCanvasScript : MonoBehaviour
{
    private void Awake()
    {
        var panel = GetComponent<RectTransform>();
        var area = Screen.safeArea;
        var anchorMin = area.position;
        var anchorMax = area.position + area.size;

        Debug.Log(anchorMin.x);
        Debug.Log(anchorMin.y);
        Debug.Log(anchorMax.x);
        Debug.Log(anchorMax.y);
        Debug.Log(panel.anchorMin);
        Debug.Log(panel.anchorMax);

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;

        Debug.Log(anchorMin.x);
        Debug.Log(anchorMin.y);
        Debug.Log(anchorMax.x);
        Debug.Log(anchorMax.y);
        Debug.Log(panel.anchorMin);
        Debug.Log(panel.anchorMax);

    }
}
