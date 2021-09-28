using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<GameObject> oldObjects;

    public void appendScene(string nextSceneName) {

        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);

        float sceneHeight = 0.0f;

        foreach (GameObject i in SceneManager.GetActiveScene().GetRootGameObjects()) {
            sceneHeight = Mathf.Max(sceneHeight, i.GetComponent<Transform>().lossyScale.y);
        }


        for (int j = 0; j < SceneManager.sceneCount; j++) {
            List<GameObject> currentObjects = 
                new List<GameObject>(SceneManager.GetSceneAt(j).GetRootGameObjects());

            foreach (GameObject i in currentObjects) {

                Transform currentTransform = i.GetComponent<Transform>();

                if (currentTransform != null) {
                    currentTransform.position += new Vector3(0, sceneHeight, 0);
                }
                
                SceneManager.MoveGameObjectToScene(i, SceneManager.GetActiveScene());
            }
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
