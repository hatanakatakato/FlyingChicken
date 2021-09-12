using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoConnectionTextScript : MonoBehaviour
{
    public float deleteTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deleteTime > 0)
        {
            deleteTime -= Time.deltaTime;
            if(deleteTime <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
