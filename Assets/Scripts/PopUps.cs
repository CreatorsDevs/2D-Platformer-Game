using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    [SerializeField] private GameObject collectAllKeysWindow;
    public void ShowCollectAllKeysWindow()
    {
        AudioManager.instance.Play(ConstantString.keyPickUpSound);
        collectAllKeysWindow.SetActive(true);
    }
    public void HideCollectAllKeysWindow()
    {
        collectAllKeysWindow.SetActive(false);
    }
}
