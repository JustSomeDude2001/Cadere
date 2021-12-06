using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HasSkin : MonoBehaviour
{
    PlayerStats playerStats;
    MeshFilter selfMeshFilter;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        PlayerStats.refresh();
        selfMeshFilter = GetComponent<MeshFilter>();
        foreach(GameObject x in playerStats.availableSkins) {
            if(x == null) {
                PlayerStats.refresh();
                Start();
                return;
            }
            if(x.name == playerStats.currentSkin) {

                selfMeshFilter.mesh = x.GetComponent<MeshFilter>().sharedMesh;
                
                Mesh mesh = selfMeshFilter.mesh;
                Vector3[] baseVertices = mesh.vertices;
            
                var vertices = new Vector3[baseVertices.Length];

                float mx = 0;

                for (var i=0;i < vertices.Length;i++)
                {
                    var vertex = baseVertices[i];
                    mx = Math.Max(Math.Abs(vertex.x), mx);
                    mx = Math.Max(Math.Abs(vertex.y), mx);
                    mx = Math.Max(Math.Abs(vertex.z), mx);           
                }

                float scale = 1f / (mx + 0.75f);

                for (var i=0;i<vertices.Length;i++)
                {
                    var vertex = baseVertices[i];
                    vertex.x = vertex.x * scale;
                    vertex.y = vertex.y * scale;
                    vertex.z = vertex.z * scale;
            
                    vertices[i] = vertex;
                }

            
                mesh.vertices = vertices;
            
                mesh.RecalculateNormals();
                mesh.RecalculateBounds();
                break;
            }
        }
    }
}
