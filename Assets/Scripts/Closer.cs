using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closer : MonoBehaviour
{

    [SerializeField] GameObject vrRig;

    private void FixedUpdate()
    {
        if (vrRig.transform.position.y < -50)
        {
            Application.Quit();
        }
    }
}
