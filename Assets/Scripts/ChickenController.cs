using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //タッチ情報の取得
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2)
            {
                //画面左タッチ時
                Debug.Log("画面左タッチ");
                this.transform.Translate(1, 0, 0);
            }
            else if(touch.phase == TouchPhase.Began && touch.position.x <= Screen.width / 2)
            {
                //画面右タッチ時
                Debug.Log("画面右タッチ");
                this.transform.Translate(-1, 0, 0);
            }
        }

    }
}
