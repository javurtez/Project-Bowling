using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePanel : MonoBehaviour
{
    public PlayerObject playerObject;

    public Slider movementSlider;

    private void OnDisable()
    {
        GameManager.Instance.startAction -= EnableSlider;
        GameManager.Instance.endAction -= DisableSlider;
    }
    private void Start()
    {
        movementSlider.enabled = false;
        GameManager.Instance.startAction += EnableSlider;
        GameManager.Instance.endAction += DisableSlider;
    }

    private void EnableSlider()
    {
        movementSlider.enabled = true;
    }
    private void DisableSlider()
    {
        gameObject.SetActive(false);
    }

    public void OnMove(float moveX)
    {
        playerObject.Movement(moveX);
    }
}