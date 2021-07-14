using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public int dano;
    public float speed;
    public Rigidbody2D rb;
    public Player player;
    public int startTime;

    void Start() 
    {
        rb.simulated = false;
        Invoke("Begin", startTime);   
    }

    void Update()
    {
        if(player == null)
        { 
            Destroy(gameObject);
        }
        else
        {    
            var velocity = new Vector2((player.transform.position.x - gameObject.transform.position.x),(player.transform.position.y - gameObject.transform.position.y));
            velocity.Normalize();
            rb.velocity = velocity*speed;
        }
    }

    public void TakeDamage(int dano)
    {
        vida -= dano;

        if(vida <= 0)
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }

    void Begin()
    {
        rb.simulated = true;
    }
}
