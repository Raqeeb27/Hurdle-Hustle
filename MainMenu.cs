using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Player player;
    public int currentSceneNumber;
    public Slider speedSlider, soundSlider, musicSlider;
    public TMP_InputField playerName;
    public TextMeshProUGUI speedValueText, soundValueText, musicValueText;
    public TextMeshPro playerNameDisplay;

    public void nextLevel(){
        if(currentSceneNumber < 3){
            SceneManager.LoadScene(currentSceneNumber + 1);
            Time.timeScale = 1f;

            if(currentSceneNumber  > PlayerPrefs.GetInt("LevelReached")){
                PlayerPrefs.SetInt("LevelReached", currentSceneNumber - 1);
            }
        }
    }

    public void directlyLoadLevel(int directlyLevelLoad){
        SceneManager.LoadScene(directlyLevelLoad);
        Time.timeScale = 1f;
    }

    public void previousLevel(){
        SceneManager.LoadScene(currentSceneNumber - 1);
        Time.timeScale = 1f;
    }

    public void backToLevelSelection(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PauseGame(){
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
    }

    public void ResetGame () {
        PlayerPrefs.DeleteAll();
    }

    public void savePlayerPrefs(){
        PlayerPrefs.SetString("PlayerName",playerName.text);
        PlayerPrefs.SetFloat("PlayerSpeed",speedSlider.value);
        PlayerPrefs.SetFloat("SoundValue",soundSlider.value);
        PlayerPrefs.SetFloat("MusicValue",musicSlider.value);
        playerNameDisplay.text = PlayerPrefs.GetString("PlayerName");
        player.Speed = PlayerPrefs.GetFloat("PlayerSpeed");
    }

    public void loadPlayerPrefs(){
        playerName.text = PlayerPrefs.GetString("PlayerName");
        speedSlider.value = PlayerPrefs.GetFloat("PlayerSpeed");
        soundSlider.value = PlayerPrefs.GetFloat("SoundValue");
        musicSlider.value = PlayerPrefs.GetFloat("MusicValue");
    }

    public void silderValueChange(){
        speedValueText.text = speedSlider.value.ToString("0.00");
        soundValueText.text = soundSlider.value.ToString() + "%";
        musicValueText.text = musicSlider.value.ToString() + "%";
    }

    void Start()
    {
        currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
}