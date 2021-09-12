using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{
    private Transform playerTransform;
    private float deleteBellow;

    void Start()
    {
        playerTransform = GameObject.Find("PlayerChicken").GetComponent<Transform>();

        if (this.CompareTag("BombTag") || this.CompareTag("FriedChickenTag"))
        {
            //19なのはkeyの生成が20だから被らないようにするため
            deleteBellow = 19f;
        }
        else if (this.CompareTag("WoodTag") || this.CompareTag("GroundTag") || this.CompareTag("KeyTag"))
        {
            deleteBellow = 50f;
        }

    }

    void Update()
    {
        //PlayerよりyにdeleteBelow離れたら消滅
        if (playerTransform.position.y - this.transform.position.y > deleteBellow)
        {
            Destroy(this.gameObject);
        }

    }
}
