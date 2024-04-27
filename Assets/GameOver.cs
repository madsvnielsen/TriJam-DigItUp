using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text timerText; // Assign in Unity editor
    public TMP_Text gameOverTimeText; // Assign in Unity editor

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.SetText(timer.ToString("0."));
    }

    public void RestartGame()
    {
        // Reload the scene
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameOverScreen.SetActive(true);
            gameOverTimeText.gameObject.SetActive(true);
            Time.timeScale = 0;
            gameOverTimeText.SetText(timer.ToString("0.") + " seconds");
        }
    }
}
