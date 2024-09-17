using System.Collections;
using System.Collections.Generic;
//using Codice.CM.Client.Differences;
using Unity.BossRoom.Gameplay.UserInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class PlayerNewInput : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        public bool skill1;
        [HideInInspector] public bool skill2;
        [HideInInspector] public bool skill3;
        [HideInInspector] public bool skill4;

        [HideInInspector] public bool move;
        [HideInInspector] public bool emote1;
        [HideInInspector] public bool emote2;
        [HideInInspector] public bool emote3;
        [HideInInspector] public bool emote4;

        private ClientInputSender clientInput;

        private void Awake()
        {
            clientInput = GetComponent<ClientInputSender>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void SkillMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Debug.Log("LetsDoThis" + context.phase);
                move = true;
            }
            else
            {
                move = false;
            }
        }
        public void DEADSkill1(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Debug.Log("Skill 1 has been activated" + context.phase);
                skill1 = true;
            }
            else if(context.canceled)
            {
                skill1 = false;
            }
        }
    }

}
