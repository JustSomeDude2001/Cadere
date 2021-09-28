using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<GameObject> oldObjects;

    public void appendScene(string nextSceneName) {
        List<GameObject> currentObjects = 
            new List<GameObject>(SceneManager.GetActiveScene().GetRootGameObjects());

        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);

        float sceneHeight = 0.0f;

        foreach (GameObject i in SceneManager.GetActiveScene().GetRootGameObjects()) {
            sceneHeight = Mathf.Max(sceneHeight, i.GetComponent<Transform>().lossyScale.y);
        }

        foreach (GameObject i in currentObjects) {

            Transform currentTransform = i.GetComponent<Transform>();

            if (currentTransform != null) {
                currentTransform.position += new Vector3(0, sceneHeight, 0);
            }
            
            SceneManager.MoveGameObjectToScene(i, SceneManager.GetActiveScene());
        }
    }

    public void ageObjects(GameObject target) {
        oldObjects.Add(target);
    }

    public void flushObjects() {
        foreach (GameObject i in oldObjects) {
            Destroy(i);
        }
    }
}
