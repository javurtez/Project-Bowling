using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPanel : MonoBehaviour
{
    public Image speedProgressImage;

    private void Start()
    {
        FindObjectOfType<BowlingObject>().speedAdjustAction += UpdateImage;
    }

    private void UpdateImage(float speed)
    {
        speedProgressImage.fillAmount = speed / 100f;
    }
}