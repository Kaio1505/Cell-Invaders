using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AbstractInimigo
{   
    bool movimento = true;
    bool praCima = false;
    public List<Transform> gatilhos;
    public AbstractTiro projetilPrefab;
    public float tempoDeTiroBasico;

    float tempTimeTiroBasico = -1f;

    public override void UpdateInimigo()
    {
        
    }

    public override void Movimento()
    {
        if(movimento)
        {
            var velocity = new Vector2(0 , 0.5f);
            rb.velocity = praCima ? velocity : -1*velocity;

            if((!praCima && gameObject.transform.position.y <=  0.6f) || (praCima && gameObject.transform.position.y >= 2.1f))
            {
                praCima = !praCima;
                movimento = false;
                rb.velocity = new Vector2(0, 0);
            }
        }

    }

    public override void Atirar()
    {
        tempTimeTiroBasico -= Time.deltaTime;
        if(tempTimeTiroBasico <= 0)
        {
            var tiro = Instantiate(projetilPrefab, gatilhos[Random.Range(0,gatilhos.Count)].position, transform.rotation);
            tiro.player = player;
            tiro.Movimento();
            tempTimeTiroBasico = tempoDeTiroBasico;
        }
    }

    public override void DroparItem()
    {

    }
}
