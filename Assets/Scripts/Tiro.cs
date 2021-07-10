using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int dano;
    public float speed;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.IsTouchingLayers(3))
        {
            if(collision.CompareTag("Inimigo"))
            {
                collision.GetComponent<Inimigo>().TakeDamage(dano);    
            }

            Destroy(gameObject);
        }
    }
}
