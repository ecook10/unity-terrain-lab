using UnityEngine;

[CreateAssetMenu(fileName = "NoiseFilter", menuName = "ScriptableObjects/NoiseFilter", order = 1)]
public class NoiseFilter : HeightFilter {

  public int resolution;

  public override float getHeight(float x, float y) {
      return Mathf.PerlinNoise(x,y);
  }
}
