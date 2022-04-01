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

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Physics XR Rig/Hand Left");
        rightHandRig = rig.transform.Find("Physics XR Rig/Hand Right");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            MapPosition(speaker, head);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;

    }

    void HandPosition(Transform target, Transform pHand)
    {
        target.position = pHand.position;
        target.rotation = pHand.rotation;
    }
}
