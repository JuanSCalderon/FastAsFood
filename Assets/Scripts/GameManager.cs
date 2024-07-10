using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Animator Animator;
    public static GameManager Instance { get; private set; }
    public float HealthPoints { get { return healthPoints = 0; } }
    public float BadPoints { get { return badPoints = 0; } }
    public float healthPoints = 0, badPoints = 0, gamePoints;
    public float weightPoints = 50;
    public float normalizedWeight;
    public PlayerController playerController;
    [SerializeField] TextMeshProUGUI textPoints;

    public List<GameObject> food;
    private float spawnTime = 2.0f, hungerTime = 3.0f;
    public float timepPoints = 3.0f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Animator = playerObject.GetComponent<Animator>();
            if (Animator == null)
            {
                Debug.LogWarning("Animator no encontrado en el objeto con tag 'Player'.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto con tag 'Player' no encontrado.");
        }
        //Selecciona la comida que va a aparecer
        StartCoroutine(SpawnFood());
        //Mide el nivel de hambre
        StartCoroutine(Hunger());
    }

    // Update is called once per frame
    void Update()
    {
        //Muestra el puntaje que lleva el jugador
        textPoints.text = gamePoints.ToString();

        //Va otorgandole puntos al jugador por estar en un punto medio entre el hambre y la llenura.
        timepPoints -= Time.deltaTime;

        if (weightPoints >= 45 && weightPoints <= 55 && timepPoints <= 0)
        {
            gamePoints = gamePoints + 10;
        }

        //Reinicia el timer
        if (timepPoints <= 0)
        {
            timepPoints = 3.0f;
        }

        normalizedWeight = NormalizedWeight(weightPoints);

        //Condición para terminar el juego por peso
        if (weightPoints <= 0)
        {
            playerController.enabled = false;
            Animator.SetBool("still", true);
            //Inicio de corutina para terminar el juego por bajo peso
            StartCoroutine(WaitAndLoadScene("GameOverMenu", 6f));
        }
        else if (weightPoints >= 100)
        {
            playerController.enabled = false;
            Animator.SetBool("still", true);
            //Inicio de corutina para terminar el juego por sobrepeso
            StartCoroutine(WaitAndLoadScene("GameOverMenu", 6f));
        }

    }
    // Corutina que espera un tiempo antes de cargar la escena
    IEnumerator WaitAndLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOverMenu");
    }

    //Alimento que debe aparecer en la escena
    private IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, food.Count);
            Instantiate(food[index]);
        }
    }

    //Corutina para el hambre
    private IEnumerator Hunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerTime);
            weightPoints = weightPoints - 1;
        }

    }

    //Calcula la cantidad de alimentación sana
    public void PlusHealthPoints(float healthPointsPlus)
    {
        healthPoints += healthPointsPlus * 5;
        weightPoints = weightPoints + healthPoints;
        healthPoints = 0;
    }

    //Calcula la cantidad de alimentación chatarra
    public void PlusBadPoints(float badPointsPlus)
    {
        badPoints += badPointsPlus * 8;
        weightPoints = weightPoints - badPoints;
        badPoints = 0;
    }

    //Nomaiza los datos dando un valor entre 0 y 1
    public float NormalizedWeight(float weighToNormalized)
    {

        float normalWeight = weighToNormalized / 100;
        return normalWeight;
    }
}
