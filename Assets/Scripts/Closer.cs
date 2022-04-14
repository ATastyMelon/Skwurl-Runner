using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closer : MonoBehaviour
{

    [SerializeField] GameObject vrRig;
    [SerializeField] Transform backSpawn;
    [SerializeField] GameObject backrooms;
    [SerializeField] GameObject closer;
    [Tooltip("The Y Level your game closes at")]
    [SerializeField] [Range(-25, -2500)] float closeRange;

    private void FixedUpdate()
    {
        if (vrRig.transform.position.y <= -250)
        {
            backrooms.SetActive(true);
        }
        if (vrRig.transform.position.y <= closeRange)
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
    }
}
