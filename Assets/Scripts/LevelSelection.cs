using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public TextMeshProUGUI[] levelNumbers;
    
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached");
        for(int i = 0; i <= levelReached; i++){         
            levelButtons[i].enabled = true;    
            levelNumbers[i].gameObject.SetActive(true);
        }
    }
}