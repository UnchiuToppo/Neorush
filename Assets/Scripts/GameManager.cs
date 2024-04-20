using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool EndGame = false;
    public float restartDelay = 0.1f;
    public GameObject completeLevelUI;
    public void End()
    {
        if(EndGame == false)
        {
            EndGame = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
