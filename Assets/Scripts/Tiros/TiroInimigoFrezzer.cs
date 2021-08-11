using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigoFrezzer : TiroInimigo
{
    public float taxaSpeed;
    public int tempoDeEfeito;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDamage(dano, taxaSpeed, tempoDeEfeito);
            Destruir();
        }
    }
}
