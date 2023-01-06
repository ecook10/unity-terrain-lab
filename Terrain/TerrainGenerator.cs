using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int width;
    public int height;
    public float scale;
    public int asdf;

    // public NoiseFilter[] noiseFilters;
    public HeightFilter[] heightFilters;

    public void GenerateTerrain() {
        float[,] heightMap = TerrainHeightMap.generateHeightMap(width, height, scale, AllFilters());
        TerrainDisplay display = FindObjectOfType<TerrainDisplay>();
        display.Draw2DHeightMap(heightMap);
    }

    public HeightFilter[] AllFilters() {
        return new HeightFilter[0];
    }
}
