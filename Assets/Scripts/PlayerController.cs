using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigibody;
    float movX, movZ;
    public float degrees; 
    public float speed = 10, speedWeight;
    Vector3 move; 
    // Start is called before the first frame update
    void Start()
    {
        //Señala el Rigybody del objeto. 
        playerRigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Lectura de la entrada de mando.
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        move = transform.forward * movZ;
    }

    private void FixedUpdate() {
        if(GameManager.Instance.weightPoints >= 0 && GameManager.Instance.weightPoints < 25)
        {
            speedWeight = 2.0f;
        }
        if(GameManager.Instance.weightPoints >= 25 && GameManager.Instance.weightPoints < 40)
        {
            speedWeight = 1.5f;
        }
        if(GameManager.Instance.weightPoints >= 40 && GameManager.Instance.weightPoints < 60)
        {
            speedWeight = 1f;
        }
        if(GameManager.Instance.weightPoints >= 60 && GameManager.Instance.weightPoints < 75)
        {
            speedWeight = 0.5f;
        }
        if(GameManager.Instance.weightPoints >= 75 && GameManager.Instance.weightPoints < 100)
        {
            speedWeight = 0.3f;
        }

        if(movX != 0 || movZ != 0)
        {
        //Traslación del personaje en el campo de juego
        playerRigibody.MovePosition(transform.position + move * Time.deltaTime * (speed * speedWeight));
        //Rotación del personaje
        transform.Rotate(0, movX * degrees, 0); 
        }
    }

}