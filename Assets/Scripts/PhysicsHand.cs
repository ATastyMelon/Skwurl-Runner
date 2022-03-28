using UnityEngine;

public class PhysicsHand : MonoBehaviour
{
    [Header("PID")]
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] float frequency = 50f;
    [SerializeField] float damping = 1f;
    [SerializeField] float rotFrequency = 100f;
    [SerializeField] float rotDamping = 0.9f;
    [SerializeField] Transform target;

    [Space]
    [Header("Springs")]
    [SerializeField] float climbForce = 500f;
    [SerializeField] float climbDrag = 250f;

    [Space]
    [Header("Audio")]
    [SerializeField] AudioSource stepSound;

    Vector3 _previousPosition;
    Rigidbody _rigidBody;
    bool _isColiding;

    void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.maxAngularVelocity = float.PositiveInfinity;
        _previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        PIDMovement();
        PIDRotation();
        if (_isColiding) HookesLaw();
    }

    private void Update()
    {
        
    }

    void PIDMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5F * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target.position - transform.position) * ksg + (playerRigidBody.velocity - _rigidBody.velocity) * kdg;

        _rigidBody.AddForce(force, ForceMode.Acceleration);
    }

    void PIDRotation()
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

        _rigidBody.AddTorque(torque, ForceMode.Acceleration);
    }

    private void HookesLaw()
    {
        Vector3 displacementFromTarget = transform.position - target.position;
        Vector3 force = displacementFromTarget * climbForce;
        float drag = GetDrag();

        playerRigidBody.AddForce(force, ForceMode.Acceleration);
        playerRigidBody.AddForce(drag * -playerRigidBody.velocity * climbDrag, ForceMode.Acceleration);
    }

    float GetDrag()
    {
        Vector3 handVelocity = (target.localPosition - _previousPosition) / Time.fixedDeltaTime;
        float drag = 1 / handVelocity.magnitude + 0.01f;
        drag = Mathf.Clamp(drag, 0.03f, 1f);
        _previousPosition = transform.position;
        return drag;
    }

    public void Step()
    {
        stepSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isColiding = true;
        Step();
    }

    private void OnCollisionExit(Collision collision)
    {
        _isColiding = false;
    }
}
