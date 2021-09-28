using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelProgresser : MonoBehaviour
{
    protected LevelManager selfLevelManager;
    protected SceneChooser selfSceneChooser;

    protected abstract Vector3 nextPosition();
    protected abstract void progressLevel();
}
