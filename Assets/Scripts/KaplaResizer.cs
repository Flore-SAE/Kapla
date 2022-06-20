using System;
using Unity.Mathematics;
using UnityEngine;

public class KaplaResizer : MonoBehaviour
{
    public float3 scale;

    private float3 previousScale;

    private void OnValidate()
    {
        if ((Vector3)scale == transform.localScale)
        {
            previousScale = scale;
            return;
        }

        var delta = scale - previousScale;

        if (delta.x != 0)
            scale.yz = new float2(scale.x / 15f, scale.x / 5f);
        if (delta.y != 0)
            scale.xz = new float2(scale.y * 15f, scale.z * 3f);
        if (delta.z != 0)
            scale.xy = new float2(scale.z * 5f, scale.z / 3f);
        previousScale = scale;
        transform.localScale = scale;
    }

    public void SwitchSides()
    {
        var isRotated = Math.Abs(transform.localScale.y - scale.y) > scale.y;
        transform.localScale = isRotated ? scale : scale.xzy;
    }
}
