using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;
    public Transform speaker;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    public bool hasAcorn = false;

    public Transform networkAcorn;
    public Transform handheldAcorn;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Physics XR Rig/Hand Left");
        rightHandRig = rig.transform.Find("Physics XR Rig/Hand Right");

        /*if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }*/
    } 

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            //MapPosition(networkAcorn, handheldAcorn);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
        target.localScale = rigTransform.localScale; 
    }

    void HandPosition(Transform target, Transform pHand)
    {
        target.position = pHand.position;
        target.rotation = pHand.rotation;
    }
}
