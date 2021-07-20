using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    public int tempoDeVida;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruir", tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            Efeito(player);
        }
    }

    public virtual void Efeito(Player player)
    {
        Destruir();
    }

    public virtual void Destruir()
    {
        Destroy(gameObject);
    }
}
