using System;
using Codice.Client.Commands;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Unity.BossRoom.Gameplay.UI
{
    /// <summary>
    /// Controls the special Canvas that has the settings icon and the settings window.
    /// The window itself is controlled by UISettingsPanel; the button is controlled here.
    /// </summary>
    public class UISettingsCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_SettingsPanelRoot;

        [SerializeField]
        private GameObject m_QuitPanelRoot;

        public bool isPausedGame;

        private NewInputSystem inputSystem;

        public Button defaultButton;

        void Awake()
        {
            // hide the settings window at startup (this is just to handle the common case where an artist forgets to disable the window in the prefab)
            DisablePanels();
            //isPausedGame = true;

            inputSystem.Menus.Pause.performed += OnPauseController;
        }

        void DisablePanels()
        {
            m_SettingsPanelRoot.SetActive(false);
            m_QuitPanelRoot.SetActive(false);
        }

        /// <summary>
        /// Called directly by the settings button in the UI prefab
        /// </summary>
        public void OnClickSettingsButton()
        {
            m_SettingsPanelRoot.SetActive(!m_SettingsPanelRoot.activeSelf);
            m_QuitPanelRoot.SetActive(false);
        }

        /// <summary>
        /// Called directly by the quit button in the UI prefab
        /// </summary>
        public void OnClickQuitButton()
        {
            m_QuitPanelRoot.SetActive(!m_QuitPanelRoot.activeSelf);
            m_SettingsPanelRoot.SetActive(false);

            isPausedGame = true;
        }

        public void OnPauseController(InputAction.CallbackContext context)
        {
            if(context.performed)
            {                    
                m_QuitPanelRoot.SetActive(!m_QuitPanelRoot.activeSelf);
                m_SettingsPanelRoot.SetActive(false);

                Debug.Log("Something Should have happened");

                if(isPausedGame)
                {
                    isPausedGame = false;
                }
                else if (!isPausedGame)
                {
                    //now we can pause the game and the following things will happen
                    isPausedGame = true;

                    defaultButton.Select();
                }
            }
        }

    }
}
