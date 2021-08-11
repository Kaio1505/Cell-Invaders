using UnityEngine;

public class TiroBasico : AbstractTiro
{

    public override void Movimento()
    {
        var velocity = DirecaoMouse();
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }

    Vector2 DirecaoMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            ColliderInimigo(collision);
            Destruir();
        }
    }
}
