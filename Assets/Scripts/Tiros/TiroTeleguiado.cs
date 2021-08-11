using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroTeleguiado : TiroBasico
{
    AbstractInimigo inimigo = null;
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            if(inimigo != null)
            {
                ColliderInimigo(collision);
                Destruir();    
            }

            inimigo = collision.GetComponent<AbstractInimigo>(); 
        }
    }

    void Update() 
    {
        if(inimigo != null)
        {
            PersegueInimigo();
        }    
    }

    void PersegueInimigo()
    {
        var velocity = new Vector2((inimigo.transform.position.x - gameObject.transform.position.x),(inimigo.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }
}
