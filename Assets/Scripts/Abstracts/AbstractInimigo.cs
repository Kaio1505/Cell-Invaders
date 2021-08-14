using UnityEngine;

public abstract class AbstractInimigo : MonoBehaviour
{
    public int vida;
    public int dano;
    public float speed;
    public Rigidbody2D rb;
    public Player player;
    public float startTime;
    public bool mortoPorTiro;
    public AbstractItem[] itensDrop = new AbstractItem[1];
    public bool valendo = false;
    public int num_drops;
    void Start() 
    {
        Invoke("Begin", startTime);
        StartInimigo();
    }

    void Update()
    {  
        if(valendo)
        {
            Movimento();
            Atirar();
        }

        if(vida <= 0)
        {
            Destruir();
        }
        
        UpdateInimigo();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDamage(dano);
            mortoPorTiro = false;
            Destruir();
        }
        OnTriggerEnterInimigo(collision);
    }

    public virtual bool TakeDamage(int dano)
    {
        vida -= dano;

        if(vida <= 0)
        {
            return true;
        }

        return false;
    }

    public virtual void Destruir()
    {
        DroparItem();
        Destroy(gameObject);
    }

    public virtual void Begin()
    {
        valendo = true;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    public virtual void Atirar()
    {

    }

    public virtual void OnTriggerEnterInimigo(Collider2D collision)
    {

    }

    public virtual void UpdateInimigo()
    {

    }

    public virtual void StartInimigo()
    {

    }
    public virtual void Girar()
    {

    }
    public abstract void Movimento();
    public abstract void DroparItem();
}
