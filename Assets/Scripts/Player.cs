using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    public float speed;
    public int vida;
    public Rigidbody2D rb;
    public Tiro projetilPrefab;
    public Transform gatilho;

    void Start() 
    {
        Task.Delay(250);    
    }

    void Update() 
    {
        Atirar();
    }

    void FixedUpdate()
    {
        Movimento();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            var inimigo = collision.GetComponent<Inimigo>();
            vida -= inimigo.dano;
            inimigo.Destruir();
        }
<<<<<<< HEAD
=======
        
>>>>>>> 4477c3658ea528aa155dc83230c9e331f5b2322f
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Movimento()
    {
        //movimento usando força
        // Movimento no eixo X e Y da nave
        /*x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(x, y,0);
        force.Normalize();
        force *= 1;
        rb.AddForce(force);*/

        //velocidade da nave
        var velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = velocity*speed;

        // Rotação da nave de acordo com o mouse
        transform.up = DirecaoMouse();
    }

    void Atirar()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var tiro = Instantiate(projetilPrefab, gatilho.position, transform.rotation);
            var velocity = DirecaoMouse();
            velocity.Normalize();
            tiro.rb.velocity = velocity*tiro.speed;
        }
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
