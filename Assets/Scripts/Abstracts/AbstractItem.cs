using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    public int tempoDeVida;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruir", tempoDeVida);
    }

    public virtual void Destruir()
    {
        Destroy(gameObject);
    }

    public virtual void Efeito()
    {
        Destruir();
    }
}
