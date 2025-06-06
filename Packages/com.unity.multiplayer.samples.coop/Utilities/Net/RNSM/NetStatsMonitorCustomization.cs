using System.Linq;
using Unity.Multiplayer.Tools.NetStatsMonitor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity.Multiplayer.Samples.Utilities
{
    public class NetStatsMonitorCustomization : MonoBehaviour
    {
        [SerializeField]
        RuntimeNetStatsMonitor m_Monitor;
        [SerializeField]
        InputActionAsset inputActions;
        private InputAction statsAction;

        const int k_NbTouchesToOpenWindow = 3;

        void Start()
        {
            m_Monitor.Visible = false;
            statsAction = inputActions.FindAction("Debug/Stats");
            statsAction.Enable();
        }

        void Update()
        {
            if(statsAction.WasReleasedThisFrame() || Touchscreen.current.touches.Count(touch => touch.isInProgress) == k_NbTouchesToOpenWindow && AnyTouchDown())
            //if (Input.GetKeyUp(KeyCode.S) || Input.touchCount == k_NbTouchesToOpenWindow && AnyTouchDown())
            {
                m_Monitor.Visible = !m_Monitor.Visible; // toggle. Using "Visible" instead of "Enabled" to make sure RNSM keeps updating in the background
                // while not visible. This way, when bring it back visible, we can make sure values are up to date.
            }
        }

        static bool AnyTouchDown()
        {
            /*foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    return true;
                }
            }*/
            if(Touchscreen.current.touches.Any(touch=> touch.ReadValue().phase == UnityEngine.InputSystem.TouchPhase.Began))
                return true;

            return false;
        }
        
        void OnDestroy()
        {
            statsAction.Disable();
        }
    }
}
