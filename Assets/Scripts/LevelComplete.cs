using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject gameObjectMenu;
    [SerializeField] private ParticleSystem levelCompleteParticleEffect = default;
    private const int lastLevelIndex = 5;
    private void Awake() 
    {
        continueButton.onClick.AddListener(LoadNextScene);
        menuButton.onClick.AddListener(ReturnToMenu);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(levelCompleteParticleEffect, transform.position, levelCompleteParticleEffect.transform.rotation);
        AudioManager.instance.Play(ConstantString.levelCompletedSound);
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {            
            if(SceneManager.GetActiveScene().buildIndex == lastLevelIndex)
            {
                Debug.Log("You Won The Game!!!");
                if(!LevelManager.Instance)
                    Debug.Log("Level Manager Instance Null");
                else
                    LevelManager.Instance.SetCurrentLevelComplete();
                gameObjectMenu.GetComponent<TextMeshProUGUI>().text = "You Won The Game!!!";
                gameObjectMenu.gameObject.SetActive(true);
                continueButton.gameObject.SetActive(false);
                menuButton.gameObject.SetActive(true);    
            }
            else
            {
                Debug.Log("not touching player");
                gameObjectMenu.gameObject.SetActive(true);
            }
        }
    }

    public void LoadNextScene(){
        if(SceneManager.GetActiveScene().buildIndex < lastLevelIndex)
        {
            LevelManager.Instance.SetCurrentLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
    }
}
