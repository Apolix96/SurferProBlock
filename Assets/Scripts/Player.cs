using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    private float speed = 0.1f;
    private float Pspeed =  16f;

    private bool turn = false;
    
    private GameObject Sphere;
    private GameObject player;
    private GameObject MainCube;
    private GameObject Bonus;
    private BoxCollider BoxCollider;

    private void MovementPlayer()
    {
        var aMovement = Input.GetAxis("Horizontal");
        var dMovement = Input.GetAxis("Vertical");
        transform.Translate(aMovement * speed, 0, dMovement * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Sphere = GameObject.Find("Sphere");
        MainCube = GameObject.Find("MainCube");
        BoxCollider = player.GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {

        //childCounter = player.transform.childCount - 2;
        //if (BoxCollider.size.y < childCounter)
        //{
        //    BoxCollider.size = new Vector3(BoxCollider.size.x, BoxCollider.size.y + Bonus.transform.localScale.y, BoxCollider.size.z);
        //    BoxCollider.center = new Vector3(BoxCollider.center.x, BoxCollider.center.y + Bonus.transform.localScale.y / 2, BoxCollider.center.z);
        //}
        //else if (BoxCollider.size.y > childCounter)
        //{
        //    BoxCollider.size = new Vector3(BoxCollider.size.x, BoxCollider.size.y - 1, BoxCollider.size.z);
        //    BoxCollider.center = new Vector3(BoxCollider.center.x, BoxCollider.center.y - 0.5f, BoxCollider.center.z);
        //}

        //Debug.Log(childCounter);
     
            MovementPlayer();
            MovePlayerStraight();
    }

    private void MovePlayerStraight()
    {
        transform.Translate(Vector3.forward * (Pspeed) * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collisin)
    {
        if (collisin.gameObject.tag == "Bonus" && collisin.gameObject.transform.parent != player.transform)
        {
            Bonus = collisin.gameObject;
            Bonus.transform.parent = player.transform;
            Bonus.transform.position = new Vector3(Sphere.transform.position.x, Sphere.transform.position.y, Sphere.transform.position.z);
            Sphere.transform.position = new Vector3(Sphere.transform.position.x, Sphere.transform.position.y+ Bonus.transform.localScale.y+1, Sphere.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TurnLeft")
        {
            gameObject.transform.DORotate(new Vector3(0, -90, 0), 1f);   
        }
        if (other.gameObject.name == "TurnRight")
        {         
            gameObject.transform.DORotate(new Vector3(0, 0, 0), 1f);  
        }
    }
}
