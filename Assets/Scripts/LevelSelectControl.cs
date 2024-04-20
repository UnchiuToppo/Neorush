using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectControl : MonoBehaviour
{
    private Image imageObject;
    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);

    }
    public Button[] lvlButtons;
    void Start()
    {
        imageObject = GetComponent<Image>();
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
    public void resetPlayerPrefs()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
                PlayerPrefs.DeleteAll();
            }
        }
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BackPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void NextPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
