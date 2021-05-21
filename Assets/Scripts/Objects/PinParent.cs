using System.Collections;
using UnityEngine;

public class PinParent : MonoBehaviour
{
    public PinObject[] pinObjects;

    private void Update()
    {
        switch (GameManager.Instance.gameState)
        {
            case GameState.Counting:
                for (int i = 0; i < pinObjects.Length; i++)
                {
                    if (!pinObjects[i].IsAtRestOrIsCounted)
                    {
                        TimeManager.Instance.ResetEndTimer();
                    }
                }
                break;
        }
    }
}