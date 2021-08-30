using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{
    private GameObject chicken;

    void Start()
    {
        this.chicken = GameObject.Find("Chicken");
    }

    void Update()
    {
        if (this.chicken.transform.position.y - this.transform.position.y > 20f)
        {
            Destroy(this.gameObject);
        }
    }
}