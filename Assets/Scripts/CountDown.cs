using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;
    void Start()
    {
        textBox.text = timeStart.ToString();
    }
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        if (timeStart < 0.2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
