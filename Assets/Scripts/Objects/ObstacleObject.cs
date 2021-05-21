using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ColorType colorType;
    public float speedAdjustment = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag) && other.TryGetComponent(out BowlingObject bowling))
        {
            if (bowling.IsSameColor(colorType))
            {
                bowling.IncreaseSpeed(speedAdjustment);
            }
            else
            {
                bowling.DeductSpeed(speedAdjustment);
            }

            gameObject.SetActive(false);
        }
    }
}