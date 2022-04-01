using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerspawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    private Vector3 spawnLocation = new Vector3(0, 3.5f, 0);

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
