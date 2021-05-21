using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingObject : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public ColorType currentColor;
    public float currentSpeed = 0;

    [SerializeField]
    private MeshRenderer meshRenderer;

    public delegate void SpeedAction(float speed);
    public SpeedAction speedAdjustAction;

    private void OnDestroy()
    {
        speedAdjustAction = null;
    }
    private void Start()
    {
        currentColor = (ColorType)Random.Range(0, Technical.EnumCount<ColorType>());
        ChangeColor(currentColor);

        speedAdjustAction?.Invoke(currentSpeed);
    }
    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Looping) return;

        //avoids gimbal lock
        transform.rotation = Quaternion.Euler(2f, 0, 0) * transform.rotation;
    }

    public void SlowAddForce()
    {
        rigidbody.AddForce(Vector3.forward * 25, ForceMode.Force);

        GameManager.Instance.GameCount();
    }
    public void AddForce()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.forward * currentSpeed * Constants.AddSpeedForce, ForceMode.Force);
    }

    public void ChangeColor(ColorType colorType)
    {
        meshRenderer.sharedMaterial = GameManager.Instance.colorMaterials[(int)colorType];
        currentColor = colorType;
    }
    public bool IsSameColor(ColorType color)
    {
        return color == currentColor;
    }

    public void IncreaseSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(currentSpeed + speed, Constants.MinSpeed, Constants.MaxSpeed);
        speedAdjustAction?.Invoke(currentSpeed);
    }
    public void DeductSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(currentSpeed - speed, Constants.MinSpeed, Constants.MaxSpeed);
        speedAdjustAction?.Invoke(currentSpeed);
    }
}