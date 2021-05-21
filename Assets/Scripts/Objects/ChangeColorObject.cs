using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorObject : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public ColorType colorType;

    private void Start()
    {
        colorType = (ColorType)Random.Range(0, Technical.EnumCount<ColorType>());
        var main = particleSystem.main;
        switch (colorType)
        {
            case ColorType.Green:
                main.startColor = Color.green;
                break;
            case ColorType.Red:
                main.startColor = Color.red;
                break;
            case ColorType.Yellow:
                main.startColor = Color.yellow;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag) && other.TryGetComponent(out BowlingObject bowling))
        {
            bowling.ChangeColor(colorType);
        }
    }
}