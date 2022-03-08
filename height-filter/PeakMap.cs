using System;
using UnityEngine;

// TODO implement more curves than just linear
// TODO implement radial noise
public class PeakMap : MonoBehaviour, HeightMap {
    public Vector2 position;
    public int radius;
    public int magnitude = 10;

    public float getHeight(int x, int z) {
        float d = Vector2.Distance(position, new Vector2(x,z));
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