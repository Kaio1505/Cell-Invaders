using UnityEngine;

public class TiroBasico : AbstractTiro
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.IsTouchingLayers(3))
        {
            if(collision.CompareTag("Inimigo"))
            {
                ColliderInimigo(collision);
            }

            Destruir();
        }
    }

}
