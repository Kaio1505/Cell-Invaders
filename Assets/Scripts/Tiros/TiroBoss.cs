using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss : TiroInimigo
{
    public IEnumerator MovimentoDelay(float startTime)
    {
        yield return new WaitForSeconds(startTime);
        var direcao = DirecaoPlayer();
        transform.up = direcao;
        direcao.Normalize();
        rb.velocity = direcao*speed;
    }

    Vector2 DirecaoPlayer()
    {
        return new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
    }
    
}
