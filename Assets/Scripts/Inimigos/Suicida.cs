using UnityEngine;

public class Suicida : AbstractInimigo
{
    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }

    public override void DroparItem()
    {
        if (mortoPorTiro)
        {
            if (Random.Range(0, 3) == 1)
            {
                var item = Instantiate(itensDrop[Random.Range(0, itensDrop.Length)], transform.position, transform.rotation);
            }
        }
    }
}
