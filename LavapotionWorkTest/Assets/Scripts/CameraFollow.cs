using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] Vector3 _cameraOffset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        transform.position = _target.position + _cameraOffset;
    }
}
