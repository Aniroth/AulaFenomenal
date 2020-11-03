using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetTarget;
    public float damp;

    float lerpTimeStart;
    bool isUp;
    bool isDown;
    Vector3 offset;
    Rigidbody targetRigidBody;

    void Start()
    {
        targetRigidBody = target.GetComponent<Rigidbody>();
        offset = offsetTarget;
    }

    void Update()
    {
        if (targetRigidBody.velocity.y > 0f)
        {
            if (!isUp)
            {
                isUp = true;
                isDown = false;
                lerpTimeStart = Time.time;
            }

            offset.y = Mathf.Lerp(offset.y, offsetTarget.y - 1f, (Time.time - lerpTimeStart) * damp);
        }
        else if (targetRigidBody.velocity.y < 0f)
        {
            if (!isDown)
            {
                isUp = false;
                isDown = true;
                lerpTimeStart = Time.time;
            }
            offset.y = Mathf.Lerp(offset.y, offsetTarget.y + 1f, (Time.time - lerpTimeStart) * damp);
        }
        else
        {
            if (isDown || isUp)
            {
                isUp = false;
                isDown = false;
                lerpTimeStart = Time.time;
            }
            offset.y = Mathf.Lerp(offset.y, offsetTarget.y, (Time.time - lerpTimeStart) * damp);
        }

        transform.position = target.position + offset;
    }
}
