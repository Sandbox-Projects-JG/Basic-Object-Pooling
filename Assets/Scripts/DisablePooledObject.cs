using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DisablePooledObject : MonoBehaviour
{
    //this script assumes your pooled object has a rigidbody, otherwise you can remove the "RequireComponent" line
    //along with the rigidbody
    private Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnBecameInvisible()
    {
        //allows the game object that has this script to be disabled when not visible on screen
        //rigidbody velocity is reset to zero to avoid velocity accumulating with each subsequent use
        rigid.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
