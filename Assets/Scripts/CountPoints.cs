using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoints : MonoBehaviour
{
    public float valor = 1.0f;
    // Start is called before the first frame update
    public ParticleSystem badFoodParticle;
    public ParticleSystem healthFoodParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Conteo de puntos.
    private void OnTriggerEnter(Collider food) {

        if(food.gameObject.CompareTag("HealthFood"))
        {
            GameManager.Instance.PlusHealthPoints(valor);
            healthFoodParticle.Play();
            Destroy(food.gameObject);
        }
        else if(food.gameObject.CompareTag("BadFood")){

            GameManager.Instance.PlusBadPoints(valor);
            badFoodParticle.Play();
            Destroy(food.gameObject);
        }
        
    }
}
