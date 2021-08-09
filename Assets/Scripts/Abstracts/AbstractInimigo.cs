using UnityEngine;

public abstract class AbstractInimigo : MonoBehaviour
{
    public int vida;
    public int dano;
    public float speed;
    public Rigidbody2D rb;
    public Player player;
    public int startTime;
    public bool mortoPorTiro;
    public AbstractItem[] itensDrop = new AbstractItem[1];

    void Start() 
    {
        rb.simulated = false;
        Invoke("Begin", startTime);
    }

    void Update()
    {  
        Movimento();
        Atirar();
    }

    public virtual void TakeDamage(int dano)
    {
        vida -= dano;

        if(vida <= 0)
        {
            Destruir();
        }
    }

    public virtual void Destruir()
    {
        DroparItem();
        Destroy(gameObject);
    }

    public virtual void Begin()
    {
        rb.simulated = true;
    }

    public virtual void Atirar()
    {

    }
    
    public abstract void Movimento();
    public abstract void DroparItem();
}
