using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    public float Velocidad;
    private Rigidbody2D rb;
    public float AlturaSalto;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();


    }

    void Update()
    {

        // SI SE APLASTO LA TECLA DE LA 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            //rb.velocity= new Vector2(10, rb.velocity.y);

            rb.velocity= new Vector2(+Velocidad, rb.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            //rb.velocity= new Vector2(-10, rb.velocity.y);

            rb.velocity= new Vector2(-Velocidad, rb.velocity.y);
        }


        // hacer saltar spacio
         if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity= new Vector2(rb.velocity.x,+AlturaSalto);
        }

        
    }
}
