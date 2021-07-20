using UnityEngine;

public class InimigoCollider : AbstractInimigo
{
    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }

    public override void DroparItem()
    {
        if(mortoPorTiro)
        {
            var item = Instantiate(itensDrop[0], transform.position, transform.rotation);
            item.player = player;
        }
    }
}
