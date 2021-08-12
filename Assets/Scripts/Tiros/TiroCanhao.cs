using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroCanhao : TiroBasico
{
    List<AbstractInimigo> inimigos = new List<AbstractInimigo>();
    public int danoExplosao;
    bool paredeImpact = false;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            var inimigo = collision.GetComponent<AbstractInimigo>();
            if(!inimigos.Contains(inimigo))
            {
                inimigos.Add(inimigo);
            }
            else
            {
                ColliderInimigo(collision);
                Destruir();
            }   
        }
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            inimigos.Remove(collision.GetComponent<AbstractInimigo>());
        }    
    }

    public override void Destruir()
    {
        foreach(var inimigo in inimigos)
        {
            inimigo.TakeDamage(danoExplosao);
        }

        base.Destruir();
    }
}
