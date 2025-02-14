using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("This Level is Locked");
                break;
            case LevelStatus.Unlocked:
                Debug.Log("This Level is Unlocked");
                AudioManager.instance.Play(ConstantString.newlevelStartSound);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                Debug.Log("This Level is Completed");
                AudioManager.instance.Play(ConstantString.newlevelStartSound);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
