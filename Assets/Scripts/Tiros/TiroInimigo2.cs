using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo2 : MonoBehaviour
{
    public int dano;
    public float speed;
    public Rigidbody2D rb;
    public Player player;
    //public velocity velo = GetComponent<rb.velocity>;

    /**
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.IsTouchingLayers(3))
        {
            if(collision.CompareTag("Player"))
            {
                ColliderInimigo(collision);
            }

            Destruir();
        }
    }
    */

/**
    void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        Player player = GameObject.FindObjectOfType<Player> ();
        Vector2 moveDirection = DirecaoPlayer() * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
    
    Vector2 DirecaoPlayer()
    {
        
        Vector2 direction = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
            //player.transform.position - transform;
            return direction;
        
    }
    */

    /**
    public void Movimento()
    {
        var velocity = DirecaoPlayer();
        velocity.Normalize();
        rb.velocity = velocity*speed;
    }
    */
    
}
