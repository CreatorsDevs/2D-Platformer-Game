using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    private void Awake() {
        restartButton.onClick.AddListener(ReloadLevel);
        menuButton.onClick.AddListener(ReturnToMenu);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
    }
}
