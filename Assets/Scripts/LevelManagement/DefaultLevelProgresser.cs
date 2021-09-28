using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultLevelProgresser : LevelProgresser
{   
    private Transform selfTransform;

    public int levelAmount;

    void OnEnable() {
        selfTransform = GetComponent<Transform>();
        selfLevelManager = GetComponent<LevelManager>();
        selfSceneChooser = GetComponent<SceneChooser>();    
    }

    protected override Vector3 nextPosition() {
        return Vector3.zero;
    }

    protected override void progressLevel()
    {
        string nextSceneName = "Level";

        int nextLevel = (Random.Range(0, levelAmount));

        if (nextLevel == levelAmount) {
            nextLevel--;
        }

        nextSceneName += nextLevel.ToString();

        selfLevelManager.appendScene(nextSceneName);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            progressLevel();
            selfTransform.position = nextPosition();
        }
    }
}
