using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Nombre de la música del menú principal y la música del juego
    public string gameOverMusic = "GameOver";
    public string gameMusic = "GameMusic";
    public string sFxReStart = "ReStartButton";

    private void Start()
    {
        // Reproducir la música del menú principal al inicio
        AudioManager.Instance.PlayMusic(gameOverMusic);
    }

    public void PlayGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(gameMusic);
            AudioManager.Instance.PlaySFX(sFxReStart, 0.5f, 0.8f); // Volumen a 0.5 y pitch a 1.2
        }
        else
        {
            Debug.LogError("AudioManager.Instance is null in GameOver.PlayGame()");
        }

        SceneManager.LoadScene("Test");
    }
}