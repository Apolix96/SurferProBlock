using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using UnityEngine;

public class TouchControll : MonoBehaviour
{

    [SerializeField] private Transform playerHorizontalMovement;
    bool isMoving = false;

    [Header("Parameters")]
    [SerializeField]
    private float forwardMovementSpeed;

    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float hapticSliceCooldown = 0.05f;
    public AnimationCurve unitSpeedToZPos;

    public float MovementSpeed => forwardMovementSpeed;
    public Vector3 LeaderPosition => playerHorizontalMovement.localPosition;

    private float traveledDistance;
    
    private Vector3 prevMousePosition;

    private void Start()
    {

    }

   

private void Update()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            prevMousePosition = Input.mousePosition;
        }
#endif
        isMoving = Input.GetMouseButton(0) || Input.touchCount > 0;
        print(isMoving);
        if (isMoving)
        {
            var delta = Input.touchCount > 0
                ? Input.GetTouch(0).deltaPosition
                : (Vector2)(Input.mousePosition - prevMousePosition);

            var playerPos = playerHorizontalMovement.localPosition;
            var movementSpeed = delta.x * horizontalMovementSpeed;
            playerPos.x += movementSpeed * Time.deltaTime;
            //playerPos.x = Mathf.Clamp(playerPos.x, LevelController.Instance.minX, LevelController.Instance.maxX);
            playerHorizontalMovement.localPosition = playerPos;
        }
    }
    
    private void FixedUpdate()
    {
        

    }

}
