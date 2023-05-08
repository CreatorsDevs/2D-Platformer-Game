using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public static LevelSelection levelManagerInstance;
    public Button[] lvlButtons;
    private string levelName;

    //Level Manager Singleton
    private void Awake() {
        if (levelManagerInstance == null){
            levelManagerInstance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if(i+1 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

    public void LevelName(){
        levelName = SceneManager.GetActiveScene().name;
        Debug.Log(levelName);
    }
}
