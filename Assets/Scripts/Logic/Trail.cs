using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    //list needs to be converted to arrays
    List<Vector3> verticeslist = new List<Vector3>();
    //List<Vector2> uvlist = new List<Vector2>();
    List<int> triangleslist = new List<int>();

    //please check again
    int index = 4;
    int indextri = 6;
    //bool uvbottom = false;

    //thearrays
    Vector3[] vertices = new Vector3[4];
    //Vector2[] uv = new Vector2[4];
    int[] triangles = new int[6];

    //meshrelatedvariables
    [SerializeField]
    float wallheight = 2f;
    Mesh mesh;
    float playerheightby2 = 1f;


#region initialisinguv
    private void Start()
    {
        Vector3 pos = transform.position;
        mesh = new Mesh();
        //initialisingvertices
        vertices[0] = pos;
        vertices[1] = pos + new Vector3(0, wallheight, 0);
        vertices[2] = pos + new Vector3(0.1f, wallheight, 0.1f);
        vertices[3] = pos + new Vector3(0.1f, 0, 0.1f);
        verticeslist.Add(pos);
        verticeslist.Add(pos + new Vector3(0, wallheight, 0));
        verticeslist.Add(pos + new Vector3(0.1f, wallheight, 0.1f));
        verticeslist.Add(pos + new Vector3(0.1f, 0, 0.1f));
        //initialisinguvs
        /*
        uvlist[0] = uv[0] = new Vector2(0, 0);
        uvlist[1] = uv[1] = new Vector2(0, 1);
        uvlist[2] = uv[2] = new Vector2(1, 1);
        uvlist[3] = uv[3] = new Vector2(1, 0);
        */
        //initialisingtriangles
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;
        triangleslist.Add(0);
        triangleslist.Add(1);
        triangleslist.Add(2);
        triangleslist.Add(0);
        triangleslist.Add(2);
        triangleslist.Add(3);


    }
   #endregion




    private void FixedUpdate()
    {
        //initmesh
        mesh.vertices = vertices;
        //mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }




    public void straight(Vector3 pos)
    {
        //vertexupdate
        verticeslist[index - 2] = vertices[index - 2] = new Vector3(pos.x, pos.y + (wallheight-playerheightby2), pos.z);
        verticeslist[index - 1] = vertices[index - 1] = new Vector3(pos.x, pos.y - playerheightby2, pos.z);


        //trianglesupdate
        triangleslist[indextri-6] = triangles[indextri-6] = index-4;
        triangleslist[indextri-5] = triangles[indextri-5] = index-3;
        triangleslist[indextri-4] = triangles[indextri-4] = index-2;
        triangleslist[indextri-3] = triangles[indextri-3] = index-4;
        triangleslist[indextri-2] = triangles[indextri-2] = index-2;
        triangleslist[indextri-1] = triangles[indextri-1] = index-1;
    }

    public void turn(Vector3 pos)
    {

        //vertices
        index += 2;
        verticeslist.Add(new Vector3(pos.x, pos.y + (wallheight-playerheightby2), pos.z));
        verticeslist.Add(new Vector3(pos.x, pos.y - playerheightby2, pos.z));
        vertices = verticeslist.ToArray();

        //uv
        /*
        int x = uvbottom ? 1 : 0;
        uvlist[index - 2] = new Vector2(x, 1);
        uvlist[index - 1] = new Vector2(x, 0);
        uvbottom = !uvbottom;
        uv = uvlist.ToArray();
        */

        //triangles
        indextri += 6;
        triangleslist.Add(index - 4);
        triangleslist.Add(index - 3);
        triangleslist.Add(index - 2);
        triangleslist.Add(index - 4);
        triangleslist.Add(index - 2);
        triangleslist.Add(index - 1);
        triangles = triangleslist.ToArray();

    }

    public void specialpos(Vector3 pos)
    {
        Vector3 offset = new Vector3(0.1f, 0, 0.1f);
        verticeslist[0] = vertices[0] = pos + offset;
        verticeslist[1] = vertices[1] = pos + offset + new Vector3(0, wallheight-playerheightby2, 0);
    }

}
