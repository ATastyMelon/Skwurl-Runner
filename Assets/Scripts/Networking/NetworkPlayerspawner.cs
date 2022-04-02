using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerspawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    private Vector3 spawnLocation = new Vector3(0, 3.5f, 0);

    public bool hasAcorn;
    public bool hasCap;
    private GameObject acorn;
    public GameObject handAcorn;
    public GameObject acornHat;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (hasAcorn & hasCap)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Melon Player", transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = true;
            handAcorn.GetComponent<Renderer>().enabled = true;
        } else if (hasAcorn)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Acorn Player", transform.position, transform.rotation);
            handAcorn.GetComponent<Renderer>().enabled = true;
            acornHat.GetComponent<Renderer>().enabled = false;
        } else if (hasCap)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Cap Player", transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = true;
            handAcorn.GetComponent<Renderer>().enabled = false;
        } else
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = false;
            handAcorn.GetComponent<Renderer>().enabled = false;
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
