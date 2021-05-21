using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObject : MonoBehaviour
{
    public Vector3 offset;
    public Transform objectToFollow;

    public PathFollower pathFollower;

    private void OnDisable()
    {
        GameManager.Instance.countAction -= AnimateCamera;
    }
    private void Start()
    {
        GameManager.Instance.countAction += AnimateCamera;
    }
    private void LateUpdate()
    {
        if (!objectToFollow) return;

        transform.position = objectToFollow.position + offset;
    }

    private void AnimateCamera()
    {
        pathFollower.enabled = true;
    }
}