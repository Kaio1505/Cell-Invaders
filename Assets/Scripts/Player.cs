using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int vida;
    public int max;
    public Rigidbody2D rb;
    public AbstractTiro projetilPrefab;
    public Transform gatilho;
    Text numVidas;

    void Start() 
    {
        numVidas = GameObject.Find("NumVidas").GetComponent<Text>();
    }

    void Update() 
    {
        Atirar();
    }

    void FixedUpdate()
    {
        Movimento();
    }

    void LateUpdate() 
    {
        numVidas.text = $"{vida}";

        if(vida == max)
        {
            numVidas.text = $"{vida} (MAX)";
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Inimigo"))
        {
            var inimigo = collision.GetComponent<AbstractInimigo>();
            vida -= inimigo.dano;
            inimigo.mortoPorTiro = false;
            inimigo.Destruir();
        }

        if(vida <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
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
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            var tiro = Instantiate(projetilPrefab, gatilho.position, transform.rotation);
            tiro.Movimento();
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
