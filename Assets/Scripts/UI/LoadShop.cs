using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour
{
    public void loadShop() {
        Debug.Log("Loading Shop");

        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
}
