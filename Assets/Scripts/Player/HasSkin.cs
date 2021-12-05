using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                break;
            }
        }
    }
}
