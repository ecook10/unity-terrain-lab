using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainHeightMap {

    public static float[,] generateHeightMap(
        int width,
        int height,
        float scale,
        HeightFilter[] filters
    ) {

        if (scale <= 0) {
            scale = 0.0001f;
        }

        float[,] heightMap = new float[width,height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float scaledX = x / scale;
                float scaledY = y / scale;

                float value = 0;
                for (int i = 0; i < filters.Length; i++) {
                    value += filters[i].getHeight(scaledX, scaledY);
                }
                heightMap[x,y] = value;
            }
        }

        return heightMap;
    }
}
