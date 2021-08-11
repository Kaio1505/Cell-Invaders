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

    void OnBecameInvisible()
    {
        Destruir();    
    }

    public virtual void Destruir()
    {
        Destroy(gameObject);
    }

    public abstract void Movimento();
}
