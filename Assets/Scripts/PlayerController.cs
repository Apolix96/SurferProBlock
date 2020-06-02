using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 lastTapPos;
    private Vector3 startRotation;

    // Start is called before the first frame update

    private void Awake()
    {


        startRotation = transform.position;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 curTapPos = Input.mousePosition;
            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = curTapPos;
            }
            float delta = lastTapPos.x - curTapPos.x;
            lastTapPos = curTapPos;
            transform.Translate((Vector3.left * delta)* Time.deltaTime );

            if (Input.GetMouseButtonUp(0))
            {
                lastTapPos = Vector2.zero;
            }
        }

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 curTapPos = touch.position;
            if (touch.phase == TouchPhase.Moved)
            {


                if (lastTapPos == Vector2.zero)
                {
                    lastTapPos = curTapPos;
                }
                float delta = lastTapPos.x - curTapPos.x;
                Debug.Log(delta);
                lastTapPos = curTapPos;
                transform.position = Vector3.left * delta;
            }
            //if (Input.GetMouseButtonUp(0))
            //{
            //    lastTapPos = Vector2.zero;
            //}*/
        }
    }
