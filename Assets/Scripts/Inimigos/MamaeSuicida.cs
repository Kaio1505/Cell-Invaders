using UnityEngine;

public class MamaeSuicida : AbstractInimigo
{
    public int filhos;
    public AbstractInimigo filhoPrefab;

    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }

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
    
    public override void DroparItem()
    {
        if(mortoPorTiro)
        {
            if(Random.Range(0, 3) == 1)
            {
                var item = Instantiate(itensDrop[0], transform.position, transform.rotation);
            }
        }
    }
}
