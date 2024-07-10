using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Nombre de la música del menú principal y la música del juego
    public string gameOverMusic = "GameOver";
    public string gameMusic = "GameMusic";

    private void Start()
    {
        // Reproducir la música del menú principal al inicio
        AudioManager.Instance.PlayMusic(gameOverMusic);
    }

    public void PlayGame()
    {

        AudioManager.Instance.PlayMusic(gameMusic);

        SceneManager.LoadScene("Test");
    }
}