using UnityEngine;

public abstract class AbstractTiro : MonoBehaviour
{
    public int dano;
    public float speed;
    public Rigidbody2D rb;
    public Player player;

    public virtual void ColliderInimigo(Collider2D collision)
    {
        collision.GetComponent<AbstractInimigo>().TakeDamage(dano); 
    }

    public virtual void Destruir()
    {
        Destroy(gameObject);
    }

    public virtual void Movimento()
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
}
