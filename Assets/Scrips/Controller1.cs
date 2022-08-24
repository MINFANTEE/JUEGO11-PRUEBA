using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    public float velocity=10, jumpForce=5;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anitor;
    bool puedeSaltar=true;

    const int ANIMACION_QUIETO=0;
    const int ANIMACION_CORRER=1;


    void Start()
    {
        Debug.Log("Iniciando juego");

        rb= GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anitor=GetComponent<Animator>();


    }

    void Update()
    {

        
        puedeSaltar=true;
        Debug.Log("Valor de puede saltar: "+puedeSaltar.ToString());

        // SI SE APLASTO LA TECLA DE LA 
        if (Input.GetKey(KeyCode.RightArrow))
        {            
            //rb.velocity= new Vector2(10, rb.velocity.y);

            rb.velocity= new Vector2(velocity, rb.velocity.y);
            sr.flipX=false;
            CambiarAnimacion(ANIMACION_CORRER);
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {            
            //rb.velocity= new Vector2(-10, rb.velocity.y);

            rb.velocity= new Vector2(-velocity, rb.velocity.y);
            sr.flipX=true;
            CambiarAnimacion(ANIMACION_CORRER);

        }
        // hacer saltar spacio

         else if (Input.GetKeyDown(KeyCode.Space)&& puedeSaltar)
        {            
            //rb.velocity= new Vector2(rb.velocity.x,+AlturaSalto);
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            puedeSaltar=false;
        }

        else{
            rb.velocity=new Vector2(0,rb.velocity.y);
            CambiarAnimacion(ANIMACION_QUIETO);
        }       
    }

    void OnCollisionEnter2D(Collision2D other) {

        puedeSaltar=true;

        if (other.gameObject.tag == "Enemy"){

        Debug.Log("Estas muerto");

        }

    }

    private void CambiarAnimacion(int animation){

        anitor.SetInteger("Estado",animation);
    }


}
