using System;

public interface HeightMap {
    public float getHeight(int x, int z);
}

[Serializable]
public class HeightMapContainer : IUnifiedContainer<HeightMap> {}