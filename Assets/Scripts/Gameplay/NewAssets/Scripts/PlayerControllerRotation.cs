using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Samples.BossRoom;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerRotation : MonoBehaviour
{
    Vector2 movementVector;
    [SerializeField] float aimSpeed;
    [SerializeField] float maxMovementX;
    [SerializeField] float maxMovementY;

    public NewInputSystem input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //input.Game.Movement.performed += InputRotateObject;
    }

    public void InputRotateObject(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();

        Debug.Log(context);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementVector.x, 0, movementVector.y);
        movement.Normalize();

        this.transform.Translate(aimSpeed * movement * Time.deltaTime);

        if(movement.x >= maxMovementX)
        {
            movement.x = maxMovementX;
        }

        if(movement.y >= maxMovementY)
        {
            movement.y = maxMovementY;
        }
    }
}
