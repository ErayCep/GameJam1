using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraControl : MonoBehaviour
{

    public Transform TargetCharacter;

    public float CameraSpeed;

    void FixedUpdate()
    {

        transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x + 1, TargetCharacter.position.y, transform.position.z), CameraSpeed);

    }
}
