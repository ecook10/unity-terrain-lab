using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.IUnified;

// auto-terrain from tutorial https://www.youtube.com/watch?v=64NblGkAabk&ab_channel=Brackeys

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 100;
    public int zSize = 100;

    // public HeightMap[] baseHeightMaps;
    // public PeakMap[] peakMaps;

    // public MapData[] mapData;

    // height map stuff
    // public IList<HeightMap> heightMaps {
    //     get {
    //         if (_interfacesDelegate == null) {
    //             _interfacesDelegate = new IUnifiedContainers<HeightMapContainer, HeightMap>(() => _heightMaps);
    //         }
    //         return _interfacesDelegate;
    //     }
    //     set {
    //         _heightMaps = value.ToContainerList<HeightMapContainer, HeightMap>();
    //     }
    // }
    // private IList<HeightMap> _interfacesDelegate;

    // [SerializeField]
    // private List<HeightMapContainer> _heightMaps;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
    }

    private void  Update()
    {
        UpdateMesh();
    }

    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                // foreach(var heightMap in heightMaps) {
                //     y += heightMap.getHeight(x,z);
                // }
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                {
                    triangles[tris + 0] = vert + 0;
                    triangles[tris + 1] = vert + xSize + 1;
                    triangles[tris + 2] = vert + 1;
                    triangles[tris + 3] = vert + 1;
                    triangles[tris + 4] = vert + xSize + 1;
                    triangles[tris + 5] = vert + xSize + 2;
                };

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    // display vertices in editor
    void OnDrawGizmos()
    {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}

[System.Serializable]
public struct MapData {
    public int something;
    public int somethingElse;
}