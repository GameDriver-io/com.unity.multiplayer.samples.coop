using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEditor.Search;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class TextBoxSelected : MonoBehaviour
    {
        [SerializeField] public GameObject onScreenKeyboard; 
        
        public Button keypadButton;

        [SerializeField] public bool keypadActive;

        // Start is called before the first frame update
        void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnSelectedInputField()
        {
            
        }

#region Enable and Disable Keyboard

        //These two functions disable and enable the keyboard when we hit the bring keyboard button when hovering over an input field
        //our desired keyboard will be brought up if the context is performed and a default button will be selected
        //this will also enable the keypad active bool so we can swap between the two

        //by default the enable keyboard button will be brought up with the triangle button (Y on Xbox)
        public void EnableKeyboard()
        {
           if(keypadActive == false)
            {
                onScreenKeyboard.SetActive(true);
                keypadActive = true;

                keypadButton.Select();
            }
        }
      

        //disabling the keyboard
        public void DisableKeyboard()
        {
            if(keypadActive == true)
            {
                onScreenKeyboard.SetActive(false);
                keypadActive = false;

                this.GetComponent<Button>().Select();
            }
        }

#endregion

    }
}
