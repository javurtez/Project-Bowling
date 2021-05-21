using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    public Transform[] obstacleTransforms;

    private Vector3[] startPositions;

    private void Start()
    {
        startPositions = new Vector3[obstacleTransforms.Length];

        for (int i = 0; i < obstacleTransforms.Length; i++)
        {
            startPositions[i] = obstacleTransforms[i].position;
        }

        RandomObstaclePosition();
    }

    private void RandomObstaclePosition()
    {
        Technical.Shuffle(startPositions);

        for (int i = 0; i < obstacleTransforms.Length; i++)
        {
            obstacleTransforms[i].position = startPositions[i];
        }
    }
}