using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameObject LeftCollider, RightCollider;
   
    // Start is called before the first frame update
    void Start()
    {
        LeftCollider = GameObject.Find("LeftColliderWall");
        RightCollider = GameObject.Find("RightColliderWall");
    }

    // Update is called once per frame
    void Update()
    {;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Trap")
        { 
            gameObject.tag = "Untagged";
            gameObject.transform.parent = null;
            
            //улучшить хуйню
            System.Random rnd = new System.Random();
            int RandomNumber = rnd.Next(1, 3);
            if (RandomNumber == 1)
            {
                LeftCollider.SetActive(false);
                gameObject.GetComponent<Rigidbody>().AddForce(transform.right * -3500);
                LeftCollider.SetActive(true);
            }
            else if(RandomNumber == 2)
            {
                RightCollider.SetActive(false);
                gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 3500);
                RightCollider.SetActive(true);
            }                                              
           //Destroy(gameObject);
        }
    }
}
