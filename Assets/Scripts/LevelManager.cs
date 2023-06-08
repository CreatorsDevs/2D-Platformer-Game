using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance{ get{ return instance; } }

    private string Level1 = "Level1";

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //Application.targetFrameRate = 60;
        if(GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(levelName);
        return levelStatus;
    }

    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int) levelStatus);
    }

    public void SetCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
  
        if(SceneManager.GetActiveScene().buildIndex < 5) 
        {  
            string nextSceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1);
            SetLevelStatus(nextSceneName, LevelStatus.Unlocked);
        }
    }

    private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
