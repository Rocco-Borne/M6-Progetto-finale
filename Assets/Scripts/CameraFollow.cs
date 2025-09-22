using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset= new Vector3(0, 3, -5);
    [SerializeField] float sensitivity = 2.0f;
    [SerializeField] float bottomClamp = -45.0f;
    [SerializeField] float topClamp = 45.0f;

    float pitch, yaw;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, bottomClamp, topClamp);

        Quaternion Rotation= Quaternion.Euler(pitch, yaw, 0);
        Vector3 cameraPosition = target.position + Rotation * offset;
        transform.position = cameraPosition;
        transform.LookAt(target.position + Vector3.up * 2.0f);
    }
}
