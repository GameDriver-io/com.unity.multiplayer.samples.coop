using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class AutoSelectButton : MonoBehaviour
    {
        public Button primaryButton;
        // Start is called before the first frame update
        void Start()
        {
            primaryButton.Select();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
