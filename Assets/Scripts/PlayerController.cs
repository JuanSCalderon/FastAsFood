using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody playerRigibody;
    float movX, movZ;
    public float degrees, speed;
    Vector3 move; 
    // Start is called before the first frame update
    void Start()
    {
        //Señala el Rigybody del objeto. 
        playerRigibody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Lectura de la entrada de mando.
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        

        move = transform.forward * movZ;
        Animator.SetBool("running", movX != 0 || movZ != 0);
    }

    private void FixedUpdate() {
        
        if(movX != 0 || movZ != 0)
        {
        //Traslación del personaje en el campo de juego
        playerRigibody.MovePosition(transform.position + move * Time.deltaTime * speed);
        //Rotación del personaje
        transform.Rotate(0, movX * degrees, 0); 
        }
    }
}