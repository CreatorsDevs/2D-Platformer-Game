using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public GameObject moveToNextLevelUI;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered with Player");
            if(SceneManager.GetActiveScene().buildIndex == 6)
            {
                Debug.Log("You Won The Game!!!");
            }
            else
            {
                //Move to next level
                moveToNextLevelUI.gameObject.SetActive(true);
                Debug.Log("Trigger entered");

                //Setting Int for Index
                if(nextSceneLoad > PlayerPrefs.GetInt("leveAt"))
                {
                    PlayerPrefs.SetInt("LevelAt", nextSceneLoad);
                }
            }            
        }
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(nextSceneLoad);
        LevelSelection.levelManagerInstance.LevelName();
    }
}
