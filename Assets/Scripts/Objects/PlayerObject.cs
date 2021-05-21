using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public Animator animator;
    public float speed = 0;

    public BowlingObject bowlingObject;

    [SerializeField]
    private float movementXOffset;
    private bool isRunning = false;

    private void Start()
    {
        GameManager.Instance.startAction += StartRunning;    
    }

    private void OnAnimatorMove()
    {
        if (!isRunning) return;

        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.z += speed * Time.deltaTime;
            newPosition.x = movementXOffset;
            transform.position = newPosition;
        }
    }

    public void Movement(float xPos)
    {
        movementXOffset = Mathf.Clamp(xPos, -0.8f, 0.8f);
    }

    public void StartRunning()
    {
        isRunning = true;
        animator.SetBool(AnimatorHashes.RUNHASH, true);
    }
    public void StartKickBall()
    {
        isRunning = false;
        animator.SetBool(AnimatorHashes.RUNHASH, false);
        animator.SetTrigger(AnimatorHashes.KICKHASH);

        bowlingObject.SlowAddForce();
        bowlingObject.transform.SetParent(null);
    }
    //is called in animation
    public void EndKickBall()
    {
        bowlingObject.AddForce();
    }

    public void Celebrate()
    {
        animator.SetTrigger(AnimatorHashes.JUMPHASH);
    }
}