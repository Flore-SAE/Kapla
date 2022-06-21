using UnityEngine;
using UnityEngine.Serialization;

public abstract class Rotate2D : MonoBehaviour
{
    [FormerlySerializedAs("anglePerSecond")]
    public float angleStep;

    public bool invert;

    protected float realSpeed;

    public virtual void ActivateRotation(float side)
    {
        if (side != 0)
        {
            var speed = invert ? angleStep * -1 : angleStep;
            realSpeed = speed * Mathf.Sign(side);
        }
        else
            realSpeed = 0;
    }

    private void Update()
    {
        if (realSpeed != 0)
            ComputeRotation();
    }

    protected void Rotate(float speed)
    {
        transform.Rotate(Vector3.forward, speed);
    }

    protected abstract void ComputeRotation();
}
