using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Curandeiro : AbstractInimigo
{
    public float tempoDeCura;
    public float tempTime;
    public int cura;
    bool isEnter = false;
    public List<AbstractInimigo> inimigosDentro = new List<AbstractInimigo>();

    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
        valendo = false;
    }

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

        if(collision.CompareTag("Parede"))
        {
            valendo = true;
        }

        if(collision.CompareTag("Inimigo"))
        {
            var inimigo = collision.GetComponent<AbstractInimigo>();
            if(!inimigosDentro.Contains(inimigo))
            {
                inimigosDentro.Add(inimigo);
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            isEnter = false;
        }

        if(collision.CompareTag("Inimigo"))
        {
            var inimigo = collision.GetComponent<AbstractInimigo>();
            if(Math.Abs(gameObject.transform.position.x - inimigo.transform.position.x) + Math.Abs(gameObject.transform.position.y - inimigo.transform.position.y) > 0.1 )
            {
                inimigosDentro.Remove(collision.GetComponent<AbstractInimigo>());
            }
        }    
    }

    public override void UpdateInimigo()
    {
        tempTime -= Time.deltaTime;
        if(tempTime <= 0)
        {
            foreach (var item in inimigosDentro)
            {
                Debug.Log(item);
                if(item != null)
                {
                    Debug.Log("Curei");
                    item.TakeDamage(-cura);
                }
                else
                {
                    inimigosDentro.Remove(item);
                }
                
            }
            tempTime = tempoDeCura;
        }
    }

    public override void DroparItem()
    {
    }
}
