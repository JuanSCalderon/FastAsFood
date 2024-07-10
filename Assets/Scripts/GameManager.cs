using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float HealthPoints {get {return healthPoints=0;}}
    public float BadPoints {get {return badPoints=0;}}
    public float healthPoints = 0, badPoints = 0;
    public float totalPoints = 0;
    
    public List<GameObject> food; 
    private float spawnTime = 2.0f;
    
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
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Alimento que debe aparecer
    private IEnumerator SpawnFood(){
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, food.Count);
            Instantiate(food[index]);
        }
    }

    public void PlusHealthPoints(float healthPointsPlus)
    {
        healthPoints += healthPointsPlus*2;
        totalPoints = totalPoints + healthPointsPlus;
    }

    public void PlusBadPoints(float badPointsPlus)
    {
        badPoints += badPointsPlus*4;
        totalPoints = totalPoints + badPointsPlus;
    }
}
