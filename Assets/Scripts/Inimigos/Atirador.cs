using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : AbstractInimigo
{
    bool isEnter = false;
    public AbstractTiro projetilPrefab;
    public float tempoDeTiro;
    public float tempTime;

    public override void Movimento()
    {
        if(!isEnter)
        {
            var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
            velocity.Normalize();
            rb.velocity = velocity*speed;
        }
    }

    public override void OnTriggerEnterInimigo(Collider2D collision) 
    {
        if(collision.CompareTag("Parede"))
        {
            isEnter = true;
            //TO DO: Randow para mandar no lugar de 0,5 para 1,5
            Invoke("Stop", 1);
        }    
    }

    public override void Atirar()
    {
        if(isEnter)
        {
            tempTime -= Time.deltaTime;
            if(tempTime <= 0)
            {
                var tiro = Instantiate(projetilPrefab, Posicao(), transform.rotation);
                tiro.player = player;
                tiro.Movimento();
                tempTime = tempoDeTiro;
            }
        }
    }

    Vector3 Posicao()
    {
        //TO DO: RETORNAR POSICAO
        return new Vector3(gameObject.transform.position.x + player.transform.position.x/5, gameObject.transform.position.y + player.transform.position.y/5, 0);
        //return gatilho.position;
    }

    void Stop()
    {
        rb.velocity = new Vector2(0, 0);
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
}
