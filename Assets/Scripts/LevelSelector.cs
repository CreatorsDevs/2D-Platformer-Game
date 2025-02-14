using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelSelector : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick(){
        SceneManager.LoadScene(LevelName);
    }
}
