using UnityEngine;

public class MamaeSuicida : Suicida
{
    public int filhos;
    public AbstractInimigo filhoPrefab;

    public override void Destruir()
    {
        if(mortoPorTiro)
        {
            for(int i = 0; i < filhos; i++)
            {
                var inimigo = Instantiate(filhoPrefab, gameObject.transform.position, Quaternion.identity);
                var velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                velocity.Normalize();
                inimigo.rb.velocity = velocity*speed;
                inimigo.GetComponent<Collider2D>().isTrigger = false;
                inimigo.player = player;
                inimigo.startTime = i+1;
            }
        }

        
        base.Destruir();
    }
}
