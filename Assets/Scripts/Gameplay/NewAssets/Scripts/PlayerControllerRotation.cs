using System.Collections;
using System.Collections.Generic;
using Unity.BossRoom.Gameplay.UI;
using Unity.Multiplayer.Samples.BossRoom;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerRotation : MonoBehaviour
{
    Vector2 movementVector;
    [SerializeField] float aimSpeed;
    [SerializeField] float maxMovementX;
    [SerializeField] float maxMovementY;

    private Light controllerRayObjectLight;
    public NewInputSystem input;

    public UISettingsCanvas uiManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //input.Game.Movement.performed += InputRotateObject;
        controllerRayObjectLight = GameObject.Find("TestPointLight").GetComponent<Light>();
        uiManager = GameObject.Find("SettingsPanelCanvas").GetComponent<UISettingsCanvas>();
    }

    public void InputRotateObject(InputAction.CallbackContext context)
    {
        controllerRayObjectLight.intensity = 10;

        movementVector = context.ReadValue<Vector2>();

        Debug.Log(context);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(uiManager.isPausedGame == false)
        // {
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
        // }
    }

}
