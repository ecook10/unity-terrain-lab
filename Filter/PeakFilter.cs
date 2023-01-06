using UnityEngine;
using System;

// TODO implement more curves than just linear
// TODO implement radial noise
public class PeakFilter : HeightFilter {

    public Vector2 position;
    public int radius;
    public int magnitude = 10;

    public override float getHeight(float x, float y) {
        float d = Vector2.Distance(position, new Vector2(x,y));
        return (radius - Math.Min(radius, d)) / radius * magnitude;
    }
}
