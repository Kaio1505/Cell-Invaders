using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : AbstractTiro
{
    //public Player player;

    public override void Movimento()
    {
        var direcao = DirecaoPlayer();
        transform.up = direcao;
        direcao.Normalize();
        rb.velocity = direcao*speed;
    }

    void OnBecameInvisible()
    {
        Destruir();    
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDamage(dano);
            Destruir();
        }
    }

    Vector2 DirecaoPlayer()
    {
        return new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
    }
}
