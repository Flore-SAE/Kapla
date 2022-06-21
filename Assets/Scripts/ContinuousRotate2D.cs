using UnityEngine;

public class ContinuousRotate2D : Rotate2D
{
    protected override void ComputeRotation()
    {
        Rotate(realSpeed * Time.deltaTime);
    }
}