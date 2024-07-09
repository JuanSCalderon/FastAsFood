using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoints : MonoBehaviour
{
    public int valor = 1;
    // Start is called before the first frame update
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
            Destroy(food.gameObject);
        }
        else if(food.gameObject.CompareTag("BadFood")){
            
            GameManager.Instance.PlusBadPoints(valor);
            Destroy(food.gameObject);
        }
        
    }
}
