using UnityEngine;

public abstract class HeightFilter : ScriptableObject {
  public abstract float getHeight(float x, float y);
}
