using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;
        private Image buttonImage;
        private Text buttonText;

        void OnEnable()
        {
            buttonImage = GetComponent<Image>();
            Color spriteColor = buttonImage.color;
            spriteColor.a = 0.5f;
            buttonImage.color = spriteColor;

            buttonText = GetComponentInChildren<Text>();
            Color textColor = buttonText.color;
            textColor.a = 0.5f;
            buttonText.color = textColor;
        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);

            Color spriteColor = buttonImage.color;
            spriteColor.a = 1f;
            buttonImage.color = spriteColor;


            Color textColor = buttonText.color;
            textColor.a = 1f;
            buttonText.color = textColor;
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
            Color spriteColor = buttonImage.color;
            spriteColor.a = 0.5f;
            buttonImage.color = spriteColor;

            Color textColor = buttonText.color;
            textColor.a = 0.5f;
            buttonText.color = textColor;
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
