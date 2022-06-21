using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Canon : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Vector2 minMaxPower;
    public float startingPower;
    [Range(0, 0.1f)] public float powerModifier;

    public Vector2 appliedForce => transform.up * currentPower;

    private float currentPower;
    private float currentModifier;

    private void OnValidate()
    {
        minMaxPower.y = Mathf.Clamp(minMaxPower.y, minMaxPower.x, float.MaxValue);
        minMaxPower.x = Mathf.Clamp(minMaxPower.x, 0, minMaxPower.y);
        startingPower = Mathf.Clamp(startingPower, minMaxPower.x, minMaxPower.y);
    }

    private void Start()
    {
        currentPower = startingPower;
    }

    public void ModifyPower(float newPower)
    {
        currentModifier = newPower;
    }
    
    public void Shoot()
    {
        var randomAngle = Random.value * 360;
        var newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, randomAngle));
        newProjectile.AddForce(appliedForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        var tempPower = currentPower + currentModifier * powerModifier;
        currentPower = Mathf.Clamp(tempPower, minMaxPower.x, minMaxPower.y);
    }
}
