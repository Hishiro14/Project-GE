using System;
using Production.Plugins.XboxCtrlrInput.Assets.Plugins;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Scripts.Components
{
    public class ButtonComponent : MonoBehaviour
    {
        public XboxButton Button;
        private void Update()
        {
            if (XCI.GetButtonDown(Button, XboxController.Any))
            {
                Debug.Log("Click A ");
                this.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}