using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables del spawn
    private float spawnRange = 10.0f;
    public float timeInGame = 5.0f;
    
    void Start() {
        //Ubica un alimento en un espacio de la escena.
        transform.position = GenerateSpawnPosition();
        //Destruye el objeto sino es tomado.
        StartCoroutine(FoodCountDown());
    }
    
    void Update()
    {   
        //Efecto de girar la cómida.
        transform.Rotate(new Vector3(0f, 30f, 0f)*Time.deltaTime);
    }

    //Posición donde aparecen al azar los alimentos
    private Vector3 GenerateSpawnPosition(){

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,1,spawnPosZ);
        return randomPos; 
    }

    //Tiempo en el que esta en el juego la cómida sino se toma
    private IEnumerator FoodCountDown(){
        yield return new WaitForSeconds(timeInGame);
        Destroy(gameObject);
    }
}
