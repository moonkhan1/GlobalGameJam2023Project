using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CASP.SoundManager;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start() {
    }
    public void LoadScene(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    IEnumerator LoadLevel(string name)
    {
        yield return SceneManager.LoadSceneAsync(name);
    }

    public void GameScene()
    {
        LoadScene("Game");
    }

}
