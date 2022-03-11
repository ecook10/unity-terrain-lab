using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int width;
    public int height;
    public float scale;

    public NoiseFilter[] noiseFilters;

    public void GenerateTerrain() {
        float[,] heightMap = TerrainHeightMap.generateHeightMap(width, height, scale, AllFilters());
        TerrainDisplay display = FindObjectOfType<TerrainDisplay>();
        display.Draw2DHeightMap(heightMap);
    }

    public HeightFilter[] AllFilters() {
        return noiseFilters;
    }
}
