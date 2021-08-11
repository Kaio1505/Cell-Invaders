using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public int vida;
    public int max;
    public Rigidbody2D rb;
    public AbstractTiro projetilPrefab;
    public Transform gatilho;
    Text numVidas;
    float _taxaSpeed;

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
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void Movimento()
    {
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

    public void TakeDamage(int dano)
    {
        vida -= dano;
    }

    public void TakeDamage(int dano, float taxaSpeed, int tempoDeEfeito)
    {
        TakeDamage(dano);
        speed *= taxaSpeed;
        _taxaSpeed = taxaSpeed;
        Invoke("ReturnSpeed", tempoDeEfeito);
    }

    public void ReturnSpeed()
    {
        speed /= _taxaSpeed;
    }
}
