using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float speed = 0.1f;
    private float Pspeed = 16f;

    private bool turn = false;

    private GameObject Sphere;
    private GameObject player;
    private GameObject MainCube;
    private GameObject Bonus;
    private BoxCollider BoxCollider;


    private readonly float speed1 = 15.1f;
    private bool move = false;
    private Vector3 target;
    private Vector2 startPos;




    private Vector3 screenPoint;
    private Vector3 offset;
    Vector3 startDirection;


    public bool finish = false;
    private void MovementAccelerationPlayer()
    {
        Vector3 dir = new Vector3(-Input.acceleration.y, 0, Input.acceleration.x);
        dir.Normalize();
        transform.Translate(dir * 10f * Time.deltaTime);

    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Sphere = GameObject.Find("Sphere");
        MainCube = GameObject.Find("MainCube");
        BoxCollider = player.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!finish)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Vector3 touchPosition = Input.GetTouch(0).position;
                double halfScreen = Screen.width / 2.0;

                //Check if it is left or right?
                if (touchPosition.x < halfScreen)
                {
                    player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
                }
                else if (touchPosition.x > halfScreen)
                {
                    player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
                }

            }
            /*if (player.transform.childCount == 4)
            {
                Camera.main.transform.parent = null;
                Destroy(gameObject);
            }*/
            MovePlayerStraight();
        }
       
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
            Bonus.transform.position = Sphere.transform.position;
            Sphere.transform.position = new Vector3(Sphere.transform.position.x, Sphere.transform.position.y+ Bonus.transform.localScale.y+1, Sphere.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var tagTrigger = "Finish";
        if (other.gameObject.tag == tagTrigger)
        {
            finish = true;
            Destroy(other.gameObject);
        }
        var groundTrigger = "Ground";
        if(other.gameObject.tag == groundTrigger)
        {
            finish = true;
            Destroy(gameObject);
        }
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
