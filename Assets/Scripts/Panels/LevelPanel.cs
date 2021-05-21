using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private void Start()
    {
        levelText.text = $"Level {GameManager.Instance.level}";
    }
}