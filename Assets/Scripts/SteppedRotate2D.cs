using UnityEngine;

public class SteppedRotate2D : Rotate2D
{
    public float waitTime;
    private float lastRotation;

    protected override void ComputeRotation()
    {
        if (Time.time <= lastRotation + waitTime) return;
        Rotate(realSpeed);
        lastRotation = Time.time;
    }
}
