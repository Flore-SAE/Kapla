using System;
using Unity.Mathematics;
using UnityEngine;

public class KaplaResizer : MonoBehaviour
{
    public float3 scale;

    private const int HeightPerDepth = 3;
    private const int DepthPerWidth = 5;
    private const int FullWidth = HeightPerDepth * DepthPerWidth;
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
            scale.yz = new float2(scale.x / FullWidth, scale.x / DepthPerWidth);
        if (delta.y != 0)
            scale.xz = new float2(scale.y * FullWidth, scale.z * HeightPerDepth);
        if (delta.z != 0)
            scale.xy = new float2(scale.z * DepthPerWidth, scale.z / HeightPerDepth);
        previousScale = scale;
        transform.localScale = scale;
    }

    public void SwitchSides()
    {
        var isRotated = Math.Abs(transform.localScale.y - scale.y) > scale.y;
        transform.localScale = isRotated ? scale : scale.xzy;
    }
}
