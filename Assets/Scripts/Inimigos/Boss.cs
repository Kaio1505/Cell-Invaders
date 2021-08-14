using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AbstractInimigo
{   
    bool movimento = true;
    bool praCima = false;
    public List<Transform> gatilhos;
    public AbstractTiro projetilPrefab;
    public TiroBoss bossPrefab;
    public List<AbstractInimigo> suicidaPrefab;
    public float tempoDeTiroBasico;
    public float tempoSuicida;

    int vidaInicial;
    float tempTimeTiroBasico = -1f;
    float tempTimeSuicida = 5f;
    bool DoisTercoVida = false;
    bool UmTercoVida = false;

    public override void StartInimigo()
    {
        vidaInicial = vida;
    }

    public override void UpdateInimigo()
    {
        if((!DoisTercoVida && (vidaInicial*2)/3 >= vida) || (!UmTercoVida && (vidaInicial)/3 >= vida))
        {
            movimento = true;
            if(DoisTercoVida)
                UmTercoVida = true;
            DoisTercoVida = true;
            StartCoroutine(Special());
        }    
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
        if(!movimento && praCima)
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
    }

    public IEnumerator Special()
    {
        yield return new WaitForSeconds(3f);

        var numTiros = 25;
        if(UmTercoVida)
            numTiros = 50;

        for(int i = 0; i < numTiros; i++)
        {
            var tiro = Instantiate(bossPrefab, GetPosition(), Quaternion.identity);
            tiro.player = player;
            yield return new WaitForSeconds(0.5f);
            tiro.Movimento();
        }

        yield return new WaitForSeconds(3f);
        movimento = true;
    }

    public override void DroparItem()
    {

    }

    Vector3 GetPosition()
    {
        var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
        return new Vector3(x*Random.Range(1.75f, 2.75f), Random.Range(-2.5f, 2.5f), 0);
    }
}
