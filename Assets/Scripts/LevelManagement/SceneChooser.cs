using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneChooser : MonoBehaviour
{
    public abstract Scene chooseNextScene();
}
