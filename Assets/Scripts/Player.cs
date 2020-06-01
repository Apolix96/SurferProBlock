using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{

    private float speed = 0.1f;
    private float Pspeed = 16f;

    private GameObject Sphere;
    private GameObject player;
    private GameObject MainCube;
    private GameObject Bonus;
    private BoxCollider BoxCollider;

    [SerializeField] GameObject fireworks;



  
    public bool finish = false;
    private void movementPlayer()
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

            
            
            if (player.transform.childCount <5)
            {
                Camera.main.transform.parent = null;
                Destroy(gameObject);
            }
            movementPlayer();

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
            //Sphere.transform.position = new Vector3(Sphere.transform.position.x, Sphere.transform.position.y, Sphere.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var tagTrigger = "Finish";
        var tagTriggerFireForks = "Winner";

        if(other.gameObject.tag == tagTriggerFireForks)
        {
            fireworks.SetActive(true);
            
        }
        if (other.gameObject.tag == tagTrigger)
        {
            finish = true;
            SceneManager.LoadScene("mainmenu/MainMenu");
        }
        var groundTrigger = "Ground";
        if(other.gameObject.tag == groundTrigger)
        {
            //finish = true;
            SceneManager.LoadScene("SampleScene");
            //Destroy(gameObject);
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
