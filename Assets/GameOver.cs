using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text timerText; // Assign in Unity editor
    public TMP_Text gameOverTimeText; // Assign in Unity editor
    public GameObject player;
    public GameObject playerDriller;

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.SetText(timer.ToString("0."));
    }

    public void RestartGame()
    {
        InventoryManager.Reset();
        // Reload the scene
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHPScript>().Health = 1000000f;

            player.GetComponent<SpriteRenderer>().enabled = false;
            playerDriller.GetComponent<SpriteRenderer>().enabled = false;


            gameOverTimeText.SetText(timer.ToString("0.") + " seconds");
            Time.timeScale = 0.1f;
            Invoke("OpenGameOverScreen", 0.3f);
        }
    }

    public void OpenGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameOverTimeText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
