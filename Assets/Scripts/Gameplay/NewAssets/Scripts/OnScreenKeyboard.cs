using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.BossRoom.Gameplay.GameplayObjects;
using Unity.Multiplayer.Samples.BossRoom;
using JetBrains.Annotations;

public class OnScreenKeyboard : MonoBehaviour
{
    public InputField myTextBox;
    public TextBoxSelected textBoxComponent;
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void InsertCharacter(string charac)
    {
        myTextBox.text += charac;
    }

    public void DeleteCharacter()
    {
        if(myTextBox.text.Length > 0)
        {
            myTextBox.text = myTextBox.text.Substring(0, myTextBox.text.Length -1);
        }
    }

    public void BringKeyboardUp()
    {
        
    }
}
