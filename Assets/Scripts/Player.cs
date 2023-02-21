using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
     float speed=10;
     float rotation=100;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position+=transform.forward * speed * Time.deltaTime;
        }
         if(Input.GetKey(KeyCode.S)){
            transform.position-=transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position+=transform.right * speed * Time.deltaTime;
        }
         if(Input.GetKey(KeyCode.A)){
            transform.position-=transform.right * speed * Time.deltaTime;
        }
         if(Input.GetKey(KeyCode.UpArrow)){
            transform.Rotate(new Vector3(0,-rotation*Time.deltaTime,0));
        }else{
             if(Input.GetKey(KeyCode.DownArrow)){
            transform.Rotate(new Vector3(0,rotation*Time.deltaTime,0));
        }}
         if(Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody>().velocity = new Vector3(0,10,0);}
    }
}
