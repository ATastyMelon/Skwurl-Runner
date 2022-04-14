using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace com.A_Tasty_Melon.SkwurlRunner
{
    public class StepSound : MonoBehaviour
    {

        [SerializeField] AudioSource stepSound;
        [SerializeField] private XRBaseController controller;
        public float defaultApmlitude = 0.025f;
        public float defaultDuration = 0.01f;

        private void OnCollisionEnter(Collision collision)
        {
            stepSound.Play();
            controller.SendHapticImpulse(defaultApmlitude, defaultDuration);
        }
    }
}
