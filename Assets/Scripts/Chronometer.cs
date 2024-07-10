using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UIElements;

public class Chronometer : MonoBehaviour
{
    //Declaración de Variables
    [SerializeField] TextMeshProUGUI textCrono;
    private float tiempo = 60; 
    //[SerializeField] private GameObject finishTime, backGround;
    public PlayerController playerController;
    bool stopGame;
    private int minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Llamada a la función que mide el tiempo
        Chrono();
    }

    private void Chrono(){
        
        if(!stopGame){
        //Se define tiempo cómo un contador en reversa
            tiempo -= Time.deltaTime;
        }
        //Calcular el deltaTime en minutos y segundos
        minutes = Mathf.FloorToInt(tiempo/60);
        seconds = Mathf.FloorToInt(tiempo%60);
        //Escribir el texto del cronometro
        textCrono.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Desactiva el juego
        if(tiempo<=0)
        {
            stopGame = true;
            tiempo = 0;
            //finishTime.SetActive(true);
            //backGround.SetActive(true);
            playerController.enabled = false;
            //Agregar el salto a escena de fin de jeugo
        }
    }
}
