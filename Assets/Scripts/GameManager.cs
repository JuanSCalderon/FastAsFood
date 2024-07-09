using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int HealthPoints {get {return healthPoints;}}
    public int BadPoints {get {return badPoints;}}
    public int healthPoints, badPoints;
    public int totalPoints = 0;
    
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

    public void PlusHealthPoints(int healthPointsPlus)
    {
        healthPoints += healthPointsPlus;
        totalPoints = totalPoints + healthPointsPlus;
    }

    public void PlusBadPoints(int badPointsPlus)
    {
        badPoints += badPointsPlus;
        totalPoints = totalPoints + badPointsPlus;
    }
}
