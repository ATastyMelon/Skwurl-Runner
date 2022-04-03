using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.A_Tasty_Melon.SkwurlRunner
{
    public class StepSound : MonoBehaviour
    {

        [SerializeField] AudioSource stepSound;

        private void OnCollisionEnter(Collision collision)
        {
            stepSound.Play();
        }
    }
}
