using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int NextSceneID;

    public void LoadScene()
    {
        SceneManager.LoadScene(NextSceneID);
    }
}
