using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Vector3[] verticies;
    private int[] triangles;
    private Mesh mesh;
    private MeshCollider meshC;
    public int xsize = 20;
    public int zsize = 20;
    public float noiseValue = 0;
    public float noiseOffset = 0;

    private void Awake()
    {
        OnButtonClicked();
    }
    private void Update()
    {
        UpdateMesh();
    }
    private void CreateShape()
    {
        verticies = new Vector3[(xsize + 1) * (zsize + 1)];
        for (int i = 0, z = 0; z <= zsize; z++)
        {
            for (int x = 0; x <= xsize; x++)
            {
                verticies[i] = new Vector3(x, Mathf.PerlinNoise(x * noiseOffset/100f, z * noiseOffset / 100f) * noiseValue, z);
                i++;
            }
        }
        triangles = new int[6 * xsize * zsize];
        for (int z = 0, vert = 0, tris = 0; z < zsize; z++)
        {
            for (int x = 0; x < xsize; x++)
            {
                triangles[0 + tris] = vert + 0;
                triangles[1 + tris] = vert + xsize + 1;
                triangles[2 + tris] = vert + 1;
                triangles[3 + tris] = vert + 1;
                triangles[4 + tris] = vert + xsize + 1;
                triangles[5 + tris] = vert + xsize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }
    private void UpdateMesh()
    {
        mesh.Clear();
        CreateShape();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshC.sharedMesh = mesh;
    }


    [InspectorButton("OnButtonClicked")]
    public bool createShape;
    private void OnButtonClicked()
    {
        mesh = new Mesh();
        meshC = GetComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }
}
