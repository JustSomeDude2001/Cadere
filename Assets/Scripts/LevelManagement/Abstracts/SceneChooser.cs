using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneChooser : MonoBehaviour
{
    protected LevelManager selfLevelManager;

    public abstract Scene chooseNextScene();
}
