using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.A_Tasty_Melon.SkwurlRunner
{
    public class PHandRot : MonoBehaviour
    {
        private float rotFrequency = 100f;
        private float rotDamping = 0.9f;
        public Transform target;
        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.maxAngularVelocity = float.PositiveInfinity;
        }

        private void FixedUpdate()
        {
            _rigidBody.AddTorque(PIDRotation(), ForceMode.Acceleration);
        }

        Vector3 PIDRotation()
        {
            float kp = (6f * rotFrequency) * (6f * rotFrequency) * 0.25f;
            float kd = 4.5f * rotFrequency * rotDamping;
            float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
            float ksg = kp * g;
            float kdg = (kd + kp * Time.fixedDeltaTime) * g;
            Quaternion q = target.rotation * Quaternion.Inverse(transform.rotation);
            if (q.w < 0)
            {
                q.x = -q.x;
                q.y = -q.y;
                q.z = -q.z;
                q.w = -q.w;
            }
            q.ToAngleAxis(out float angle, out Vector3 axis);
            axis.Normalize();
            axis *= Mathf.Deg2Rad;
            Vector3 torque = ksg * axis * angle + -_rigidBody.angularVelocity * kdg;
            // _rigidBody.AddTorque(torque, ForceMode.Acceleration);
            return torque;
        }
    }
}