using UnityEngine;

public class Rotate2D : MonoBehaviour
{
    public float anglePerSecond;
    public bool invert;
    public float waitTime;

    private float realSpeed;
    private float lastRotation;

    public void ActivateRotation(int side)
    {
        if (side != 0)
        {
            realSpeed = (invert ? anglePerSecond * -1 : anglePerSecond) * side;
            Rotate();
        }
        else
            realSpeed = 0;
    }

    private void Update()
    {
        if (Time.time <= lastRotation + waitTime) return;
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward, realSpeed);
        lastRotation = Time.time;
    }
}
