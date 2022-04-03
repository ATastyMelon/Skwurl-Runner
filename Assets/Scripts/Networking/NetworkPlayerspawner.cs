using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerspawner : MonoBehaviourPunCallbacks
{
    private GameObject playerPrefab;

    public GameObject Player;
    public GameObject Moderator;
    public GameObject Admin;
    public GameObject Crowner;
    public GameObject Melon;

    private Vector3 spawnLocation = new Vector3(0, 3.5f, 0);

    public bool hasAcorn;
    public bool hasCap;
    public bool hasCrown;
    public bool isMelon;
    private GameObject acorn;
    public GameObject handAcorn;
    public GameObject acornHat;
    public GameObject gridCrown;
    public GameObject melonHat;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (isMelon)
        {
            playerPrefab = PhotonNetwork.Instantiate(this.Melon.name, transform.position, transform.rotation);
            melonHat.GetComponent<Renderer>().enabled = true;
            handAcorn.GetComponent<Renderer>().enabled = true;
            gridCrown.GetComponent<Renderer>().enabled = false;
            acornHat.GetComponent<Renderer>().enabled = false;
        }
        else if (hasAcorn)
        {
            playerPrefab = PhotonNetwork.Instantiate(this.Moderator.name, transform.position, transform.rotation);
            handAcorn.GetComponent<Renderer>().enabled = true;
            acornHat.GetComponent<Renderer>().enabled = false;
            gridCrown.GetComponent<Renderer>().enabled = false;
            melonHat.GetComponent<Renderer>().enabled = false;
        }
        else if (hasCap)
        {
            playerPrefab = PhotonNetwork.Instantiate(this.Admin.name, transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = true;
            handAcorn.GetComponent<Renderer>().enabled = false;
            gridCrown.GetComponent<Renderer>().enabled = false;
            melonHat.GetComponent<Renderer>().enabled = false;
        }
        else if (hasCrown)
        {
            playerPrefab = PhotonNetwork.Instantiate(this.Crowner.name, transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = false;
            handAcorn.GetComponent<Renderer>().enabled = false;
            gridCrown.GetComponent<Renderer>().enabled = true;
            melonHat.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            playerPrefab = PhotonNetwork.Instantiate(this.Player.name, transform.position, transform.rotation);
            acornHat.GetComponent<Renderer>().enabled = false;
            handAcorn.GetComponent<Renderer>().enabled = false;
            gridCrown.GetComponent<Renderer>().enabled = false;
            melonHat.GetComponent<Renderer>().enabled = false;
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(playerPrefab);
    }
}
