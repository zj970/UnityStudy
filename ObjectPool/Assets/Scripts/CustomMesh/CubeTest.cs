using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
//public class CubeTest : MonoBehaviour
//{
//    [Header("顶点")]
//    public Vector3[] newVertices;
//    [Header("三角形")]
//    public int[] newTriangles;

//    [ContextMenu("Create")]
//    public void Create()
//    {
//        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
//        mesh.vertices = newVertices;
//        mesh.triangles = newTriangles;


//    }
//}
public class CubeTest : MonoBehaviour
{
    public List<Transform> pos;

    /*
        void Start()
        {
            Vector3[] newVertices = { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 2, 0), new Vector3(1, 3, 0), new Vector3(1, 2, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0) };
            Vector2[] newUV = { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };
            int[] newTriangles = { 0, 1, 5, 0, 5, 6, 1, 2, 4, 1, 4, 5, 2, 3, 4 };

            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            mesh.vertices = newVertices;
            //mesh.uv = newUV;
            mesh.triangles = newTriangles;
        }*/

    private void Update()
    {
        CreateMesh();
    }

    public Vector3[] GetPos()
    {
        Vector3[] newVertices = new Vector3[pos.Count];
        for (int i = 0; i < pos.Count; i++)
        {
            newVertices[i] = pos[i].position;
        }
        return newVertices;
    }


    public void CreateMesh()
    {
        int[] newTriangles = { 0, 2, 1, 0, 3, 2, 0,4,7, 0,7,3, 0,1,5 , 0,1,4, 4,5,6, 4,6,7, 1,5,6, 1,6,2,3,7,6, 3,6,2 };
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = GetPos();
        //mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }
}