using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoConnectionTextScript : MonoBehaviour
{
    //表示時間GameManagerから変更される
    public float showingTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(showingTime > 0)
        {
            showingTime -= Time.deltaTime;

            if(showingTime < 0)
            {
                //非表示にする
                this.gameObject.SetActive(false);
            }
        }
    }

}
