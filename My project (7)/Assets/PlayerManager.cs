using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float moveSpeed= 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player移動の処理
        //前に進む
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
            Debug.Log("W");
        }
        //後ろに進む
         if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed);
            Debug.Log("S");
        }
        //右に進む
         if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed);
            Debug.Log("D");
        }
        //左に進む
         if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * moveSpeed);
            Debug.Log("A");
        }
    }
}
