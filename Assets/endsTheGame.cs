using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endsTheGame : MonoBehaviour
{
    public GameObject endScreen;
    public void endGame()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0f;

    }
    
}
