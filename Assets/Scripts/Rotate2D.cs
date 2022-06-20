using UnityEngine;

public class Rotate2D : MonoBehaviour
{
    public float anglePerSecond;
    public bool invert;
    
    private float realSpeed;

    public void SetRotationSpeed(float rotationPower)
    {
        realSpeed =  anglePerSecond * rotationPower;
        if (invert)
            realSpeed *= -1;
    }

    private void Update()
    {
        if (realSpeed != 0)
            transform.Rotate(Vector3.forward, realSpeed * Time.deltaTime);
    }
}
