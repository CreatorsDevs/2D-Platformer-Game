using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play(ConstantString.buttonSound);
    }
}
