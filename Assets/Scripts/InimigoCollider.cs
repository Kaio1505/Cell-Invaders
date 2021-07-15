using UnityEngine;

public class InimigoCollider : AbstractInimigo
{
    public override void Movimento()
    {
        var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }
}
