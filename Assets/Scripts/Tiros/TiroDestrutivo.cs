using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDestrutivo : TiroBasico
{
    public int numFilhos;
    public TiroBasico prefab;

    public override void ColliderInimigo(Collider2D collision)
    {
        var matou = collision.GetComponent<AbstractInimigo>().TakeDamage(dano);

        if(matou)
        {
            for(int i = 0; i < numFilhos; i++)
            {   
                var tiro = Instantiate(prefab, gameObject.transform.position, transform.rotation);
                tiro.isFilho = true;
                tiro.x = rb.velocity.x > 0 ? Random.Range(1, 4) : -1*Random.Range(1, 4);
                tiro.y = rb.velocity.y > 0 ? Random.Range(1, 4) : -1*Random.Range(1, 4);
                tiro.Movimento();
            }
        }
    }
}
