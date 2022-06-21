using UnityEngine;

public class Canon : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float power;

    public Vector2 appliedForce => transform.up * power;

    public void Shoot()
    {
        var randomAngle = Random.value * 360;
        var newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, randomAngle));
        newProjectile.AddForce(appliedForce, ForceMode2D.Impulse);
    }
}
