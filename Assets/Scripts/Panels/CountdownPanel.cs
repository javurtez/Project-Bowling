using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownPanel : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    private void OnDisable()
    {
        TimeManager.Instance.countdownAction -= UpdateCountdown;
        GameManager.Instance.startAction -= Close;
    }
    private void Start()
    {
        TimeManager.Instance.countdownAction += UpdateCountdown;
        GameManager.Instance.startAction += Close;
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }
    private void UpdateCountdown(float countdown)
    {
        countdownText.text = countdown.ToString("0");
    }
}