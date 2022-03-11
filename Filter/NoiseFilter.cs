using UnityEngine;

[System.Serializable]
public class NoiseFilter : HeightFilter {
    public int x;

    public float getHeight(float x, float y) {
        return Mathf.PerlinNoise(x,y);
    }
}