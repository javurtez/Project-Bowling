using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObject : MonoBehaviour
{
    public new Rigidbody rigidbody;

    public Transform downward;
    public LayerMask groundLayer;

    private bool isCounted = false;

    public bool IsAtRestOrIsCounted => rigidbody.velocity == Vector3.zero || isCounted;

    private void Start()
    {
        //improves difficulty by increasing mass every level
        float additionalMass = GameManager.Instance.level * 1.25f;
        rigidbody.mass = Mathf.Clamp(rigidbody.mass + additionalMass, 1f, 50f);
    }
    private void FixedUpdate()
    {
        if (isCounted) return;

        //not grounded anymore
        if (!Physics.Raycast(downward.position, -downward.up, .1f, groundLayer))
        {
            isCounted = true;
            GameManager.Instance.IncreaseScore(1);
        }
    }
}