using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroomsTrigger : MonoBehaviour
{
    [SerializeField] CapsuleCollider playerCapsuleCollider;
    [SerializeField] SphereCollider playerSphereCollider;
    [SerializeField] Transform player;
    [SerializeField] GameObject backroomsSpawn;

    [SerializeField] GameObject backrooms;

    private void FixedUpdate()
    {
        if (player.position.y <= -250)
        {
            backrooms.SetActive(true);
        }
    }
}
