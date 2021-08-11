using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : Suicida
{
    public int danoExplosao;
    bool isEnter = false;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            if(isEnter)
            {
                player.TakeDamage(dano);
                mortoPorTiro = false;
                Destruir();
            }
            isEnter = true;
        }
        OnTriggerEnterInimigo(collision);
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
       if(collision.CompareTag("Player"))
        {
            isEnter = false;
        }    
    }

    public override void Destruir()
    {
        if(isEnter && mortoPorTiro)
        {
            player.TakeDamage(danoExplosao);
        }

        base.Destruir();
    }
}
