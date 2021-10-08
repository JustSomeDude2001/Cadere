using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelChooser levelChooser;
    private List<GameObject> oldObjects;
    private Queue<AsyncOperation> loadingLevels = new Queue<AsyncOperation>();
    private Queue<string> sceneNameQueue = new Queue<string>();
    private Transform selfTransform;
    private float getSceneHeight(Scene targetScene) {

        float sceneHeight = 0.0f;

        foreach (GameObject i in targetScene.GetRootGameObjects()) {
            sceneHeight = Mathf.Max(sceneHeight, i.GetComponent<Transform>().lossyScale.y);
        }

        return sceneHeight;
    }

    public void appendLoadedScene() {
        Debug.Log("Appending next level");

        Scene newScene = SceneManager.GetSceneByName(sceneNameQueue.Dequeue());
        Scene oldScene = SceneManager.GetActiveScene();

        float sceneHeight = getSceneHeight(newScene);

        Debug.Log(sceneHeight);

        foreach (GameObject i in oldScene.GetRootGameObjects()) {

            Transform currentTransform = i.GetComponent<Transform>();

            if (currentTransform != null) {
                currentTransform.position += new Vector3(0, sceneHeight, 0);
            }
        }
        
        SceneManager.MergeScenes(newScene, oldScene);

        loadingLevels.Dequeue();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") {
            return;
        }

        Debug.Log("Loading new level");

        string nextSceneName = levelChooser.chooseLevel();

        Debug.Log("Next level is " + nextSceneName);

        loadingLevels.Enqueue(SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive));
        sceneNameQueue.Enqueue(nextSceneName);
    }

    void Start() {
        levelChooser = GetComponent<LevelChooser>();
        selfTransform = GetComponent<Transform>();
    }

    void Update() {
        Debug.Log("LoadingLevels.Count = " + loadingLevels.Count.ToString());
        if (loadingLevels.Count != 0 && loadingLevels.Peek().isDone) {
            Debug.Log("Appending level " + sceneNameQueue.Peek());
            appendLoadedScene();
            selfTransform.position = Vector3.zero;
        }
        //flushObjects();
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
