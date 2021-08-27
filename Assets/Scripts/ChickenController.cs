using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    [SerializeField] float maxVelocity = 10f;

    void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
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
                //画面右タッチ時
                Debug.Log("右タッチされた");
                this.rb2D.velocity = new Vector2(4f, 10f);
            }
            else if(touch.phase == TouchPhase.Began && touch.position.x <= Screen.width / 2)
            {
                //画面左タッチ時
                Debug.Log("左タッチされた");
                this.rb2D.velocity = new Vector2(-4f, 10f);
            }

        }

    }
}
