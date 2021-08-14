using UnityEngine;
using System.Threading;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public int vida;
    public int max;
    public Rigidbody2D rb;
    public AbstractTiro projetilPrefab;
    public Transform gatilhoCentral;
    public Transform gatilhoDireito;
    public Transform gatilhoEsquerdo;
    public GameObject escudo;
    public bool tiroTriplo;
    public float tempoDeEfeito;
    public bool NaveAmiga = false;
    public bool isEscudo = true;
    public int dano = 0;

    AbstractTiro _original;

    void Start()
    {
        _original = projetilPrefab;
    }

    void Update() 
    {
        Atirar();
    }

    void FixedUpdate()
    {
        Movimento();
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
            var tiro = Instantiate(projetilPrefab, gatilhoCentral.position, transform.rotation);
            tiro.Movimento();
            tiro.dano += dano;

            if(tiroTriplo)
            {
                tiro = Instantiate(projetilPrefab, gatilhoDireito.position, transform.rotation);
                tiro.Movimento();
                tiro.dano += dano;
                tiro = Instantiate(projetilPrefab, gatilhoEsquerdo.position, transform.rotation);
                tiro.Movimento();
                tiro.dano += dano;
            }
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
        if(!isEscudo) vida -= dano;
    }

    public void TakeDamage(int dano, float taxaSpeed, int tempoDeEfeito)
    {
        if(!isEscudo)
        {
            TakeDamage(dano);
            speed *= taxaSpeed;
            StartCoroutine(ReturnSpeed(taxaSpeed, tempoDeEfeito));
        }
        
    }

    public IEnumerator ReturnSpeed(float taxaSpeed, float tempoDeEfeito)
    {
        yield return new WaitForSeconds(tempoDeEfeito);
        speed /= taxaSpeed;
    }

    public void SetActivePlayer(bool value)
    {
        gameObject.SetActive(value);
    }

    public void Reset(bool isTiroPrefab)
    {
        if(isTiroPrefab) Invoke("ResetTiroPrefab", tempoDeEfeito);
        Invoke("ResetProps", tempoDeEfeito);
    }

    void ResetProps()
    {
        if(NaveAmiga)   Destroy(gameObject);

        tiroTriplo = false;
        escudo.SetActive(false);
        isEscudo = false;
        dano = 0;
    }

    void ResetTiroPrefab()
    {
        projetilPrefab = _original;
    }


}
