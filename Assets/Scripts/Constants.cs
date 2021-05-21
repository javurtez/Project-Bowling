using UnityEngine;
using System.Collections;

public struct Constants
{
    public const float MaxSpeed = 100;
    public const float MinSpeed = 10;

    public const float AddSpeedForce = 60;

    public const string PlayerTag = "Player";
    public const string GroundTag = "Ground";
    public const string PinTag = "Pin";
    public const string ObjectTag = "Object";
}
public struct AnimatorHashes
{
    public static readonly int RUNHASH = Animator.StringToHash("IsRunning");
    public static readonly int KICKHASH = Animator.StringToHash("Kick");
    public static readonly int JUMPHASH = Animator.StringToHash("Jump");
}

public enum ColorType
{
    Red,
    Green,
    Yellow
}
public enum GameState
{
    Start,
    Looping,
    Counting,
    End
}