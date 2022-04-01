using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{

    [SerializeField] AudioSource stepSound;

    private void OnCollisionEnter(Collision collision)
    {
        stepSound.Play();
    }
}
