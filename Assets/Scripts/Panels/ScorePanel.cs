using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public GameObject scoreObject;
    public GameObject endObject;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.Instance.scoreAction += UpdateScore;
        GameManager.Instance.endAction += ShowEnd;
    }

    private void UpdateScore(int score)
    {
        if (!scoreObject.activeInHierarchy)
        {
            scoreObject.SetActive(true);
        }
        scoreText.text = score.ToString();
    }
    public void ShowEnd()
    {
        endObject.SetActive(true);
    }

    public void OnNext()
    {
        GameManager.Instance.GameNext();
    }
}