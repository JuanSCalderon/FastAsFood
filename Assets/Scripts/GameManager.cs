using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float HealthPoints {get {return healthPoints=0;}}
    public float BadPoints {get {return badPoints=0;}}
    public float healthPoints = 0, badPoints = 0, gamePoints;
    public float weightPoints = 50;
    public float normalizedWeight; 
    
    public List<GameObject> food; 
    private float spawnTime = 2.0f, hungerTime = 3.0f;
    public float timepPoints = 3.0f; 
    void Awake() {
        if(Instance == null){
            Instance = this;
        }
        else {
            Destroy(gameObject);
            DontDestroyOnLoad(this);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {   
        //Selecciona la comida que va a aparecer
        StartCoroutine(SpawnFood());
        //Mide el nivel de hambre
        StartCoroutine(Hunger());
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Va otorgandole puntos al jugador por estar en un punto medio entre el hambre y la llenura.
        timepPoints -= Time.deltaTime;

        if(weightPoints >= 45 && weightPoints <= 55 && timepPoints <= 0)
        {
            gamePoints = gamePoints + 10;
        }

        if(timepPoints <= 0)
        {
            timepPoints = 3.0f; 
        }

        normalizedWeight = NormalizedWeight(weightPoints);

        //Condición para terminar el juego por peso
        /*if(weightPoints <= 0)
        {
            //Se acaba el juego por bajo peso
        }
        else if(weightPoints >= 100)
        {
            //Se acaba el juego por mucho peso
        }*/
        
    }

    //Alimento que debe aparecer en la escena
    private IEnumerator SpawnFood(){
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, food.Count);
            Instantiate(food[index]);
        }
    }

    //Corutina para el hambre
    private IEnumerator Hunger()
    {
        while(true){
        yield return new WaitForSeconds(hungerTime);
        weightPoints = weightPoints - 1;
    }

    }

    //Calcula la cantidad de alimentación sana
    public void PlusHealthPoints(float healthPointsPlus)
    {
        healthPoints += healthPointsPlus*5;
        weightPoints = weightPoints + healthPoints;
        healthPoints = 0;
    }

    //Calcula la cantidad de alimentación chatarra
    public void PlusBadPoints(float badPointsPlus)
    {
        badPoints += badPointsPlus*8;
        weightPoints = weightPoints - badPoints;
        badPoints = 0;
    }

    //Nomaiza los datos dando un valor entre 0 y 1
    public float NormalizedWeight(float weighToNormalized){
        
        float normalWeight = weighToNormalized/100;
        return normalWeight; 
    }
}
