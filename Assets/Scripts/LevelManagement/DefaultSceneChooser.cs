using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultSceneChooser : SceneChooser
{
    public override Scene chooseNextScene() {
        Debug.Log("Choosing next scene...");

        Scene nextScene = SceneManager.GetSceneByName("SampleScene");

        return nextScene;
    }
}
