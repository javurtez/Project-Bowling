using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag) && other.TryGetComponent(out BowlingObject bowling))
        {
            other.GetComponentInParent<PlayerObject>().StartKickBall();
        }
    }
}