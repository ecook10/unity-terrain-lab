using UnityEngine;
using System;

// TODO implement more curves than just linear
// TODO implement radial noise
[System.Serializable]
public class PeakFilter : HeightFilter {
    public Vector2 position;
    public int radius;
    public int magnitude = 10;

    public float getHeight(float x, float y) {
        float d = Vector2.Distance(position, new Vector2(x,y));
        return (radius - Math.Min(radius, d)) / radius * magnitude;
    }
}

// public class PeakMapContainer : MonoBehaviour {
//     public HeightMap Interface {
//         get { return _interface.Result; }
//         set { _interface.Result = new PeakMap(); }
//     } 

//     [SerializeField]
//     private HeightMapContainer _interface;
// }