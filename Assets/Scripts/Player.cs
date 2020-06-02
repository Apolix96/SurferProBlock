using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 0.1f;
    private float PlayerSpeed = 16f;
    private int DiamondsCount;
    public bool finish = false;

    public GameObject FinishPanel;
    public GameObject Hero;
    public GameObject player;
    private GameObject Bonus;
    
  
    private void MovementPlayer()
    {
        var aMovement = Input.GetAxis("Horizontal");
        var dMovement = Input.GetAxis("Vertical");
        transform.Translate(aMovement * speed, 0, dMovement * speed);
    }

    void Start()
    {
        GameObject[] Diamonds = GameObject.FindGameObjectsWithTag("Diamond");
        DiamondsCount = Diamonds.Length;
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
                SceneManager.LoadScene("SampleScene");
            }
            MovementPlayer();
            MovePlayerStraight();
        }      
    }

    private void MovePlayerStraight()
    {
        transform.Translate(Vector3.forward * (PlayerSpeed) * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collisin)
    {
        if (collisin.gameObject.CompareTag("Bonus") && collisin.gameObject.transform.parent != player.transform)
        {
            Bonus = collisin.gameObject;
            Bonus.transform.parent = player.transform;
            Bonus.transform.position = Hero.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish") && finish == false)
        {
            var Finish = GetComponent<GetDiamonds>();   
            finish = true;
            FinishPanel.SetActive(true);
            int Stars = 0;
            if (Finish.score <= DiamondsCount * 50 / 100)
            {
                Stars++;
            }
            else if (Finish.score > DiamondsCount * 50 / 100)
            {
                Stars+=2;
            }
            else if (Finish.score > DiamondsCount * 85 / 100)
            {
                Stars+=3;
            }
            for(int i=0;i<Stars;i++)
            { 
                FinishPanel.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        var groundTrigger = "Ground";
        if(other.gameObject.CompareTag(groundTrigger))
        {
            SceneManager.LoadScene("SampleScene");
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