using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        this.playerTransform = GameObject.Find("Chicken").GetComponent<Transform>().transform;
    }

    void Update()
    {
        //Playerよりyに-20離れたら消滅
        if (playerTransform.position.y - this.transform.position.y > 10f)
        {
            Destroy(this.gameObject);
        }

    }
}
