using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AbstractInimigo
{   
    bool movimento = true;
    bool praCima = false;
    public List<Transform> gatilhos;
    public AbstractTiro projetilPrefab;
    public List<AbstractInimigo> suicidaPrefab;
    public float tempoDeTiroBasico;
    public float tempoSuicida;

    float tempTimeTiroBasico = -1f;
    float tempTimeSuicida = 5f;

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
        tempTimeSuicida -= Time.deltaTime;

        if(tempTimeTiroBasico <= 0)
        {
            var tiro = Instantiate(projetilPrefab, gatilhos[Random.Range(0,gatilhos.Count)].position, transform.rotation);
            tiro.player = player;
            tiro.Movimento();
            tempTimeTiroBasico = tempoDeTiroBasico;
        }

        if(tempTimeSuicida <= 0)
        {
            var inimigo = Instantiate(suicidaPrefab[0], gatilhos[Random.Range(0,gatilhos.Count)].position, Quaternion.identity);
            inimigo.player = player;
            inimigo.startTime = 0;
            tempTimeSuicida = tempoSuicida;
        }
    }

    public override void DroparItem()
    {

    }
}
