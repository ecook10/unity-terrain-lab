using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMeshDisplay : MonoBehaviour {

    public Renderer textureRender;

    public void Draw2DHeightMap(float[,] heightMap) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] colorMap = new Color[width*height];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                colorMap[y*width + x] = Color.Lerp(Color.black, Color.white, heightMap[x,y]);
            }
        }
        texture.SetPixels(colorMap);
        texture.Apply();

        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(width, 1, height);

        Debug.Log("[TerrainMeshDisplay] height map drawn");
    }
}
