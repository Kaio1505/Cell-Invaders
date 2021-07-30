using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : AbstractInimigo
{
   public TiroInimigo2 projetilPrefab;
   public Transform gatilho;
   public float tempoDisparo;
   public float tempTime = 0;

   void FixedUpdate()
    {
        DirecaoPlayer();
        
    }

    public void Update()
    {
        Atirar();
        Movimento();
    }


    void DirecaoPlayer()
    {
        
        Vector2 direction = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
            //player.transform.position - transform;
        transform.up = direction;
        
    }

    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x 
        - gameObject.transform.position.x),(player.transform.position.y 
        - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed/5;
    }

    

    public override void DroparItem()
    {
        if(mortoPorTiro)
        {
            if(Random.Range(0, 3) == 1)
            {
                var item = Instantiate(itensDrop[0], transform.position, transform.rotation);
            }
        }
    }

    void Atirar()
    {
        
        tempTime -= Time.deltaTime;
        if(tempTime <= 0)
        {
            var tiro = Instantiate(projetilPrefab, transform.position, transform.rotation);
            tempTime = tempoDisparo;
            var velocity = new Vector2((player.transform.position.x 
            - gameObject.transform.position.x),(player.transform.position.y 
            - gameObject.transform.position.y));
            velocity.Normalize();
            tiro.rb.velocity = velocity*6;
        }
    }
}
