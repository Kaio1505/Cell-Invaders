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
    public bool tiroTriplo;
    public bool ItemDano = false;
    public float ItemDanoTimer;
    public float ItemDanoTimerBase;

    void Update() 
    {
        Atirar();
    }

    void FixedUpdate()
    {
        Movimento();
        BuffDano();
    }
    public void BuffDano()
    {
        //ItemDano
        if (ItemDano)
        {
            ItemDanoTimer -= Time.deltaTime;
        }


        if (ItemDanoTimer < 0)
        {
            projetilPrefab.dano -= 10;
            ItemDanoTimer = ItemDanoTimerBase;
            ItemDano = false;
            Debug.Log("ItemDano é false!");
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
            var tiro = Instantiate(projetilPrefab, gatilhoCentral.position, transform.rotation);
            tiro.Movimento();

            if(tiroTriplo)
            {
                tiro = Instantiate(projetilPrefab, gatilhoDireito.position, transform.rotation);
                tiro.Movimento();
                tiro = Instantiate(projetilPrefab, gatilhoEsquerdo.position, transform.rotation);
                tiro.Movimento();
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
        vida -= dano;
    }

    public void TakeDamage(int dano, float taxaSpeed, int tempoDeEfeito)
    {
        TakeDamage(dano);
        speed *= taxaSpeed;
        StartCoroutine(ReturnSpeed(taxaSpeed, tempoDeEfeito));
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
}
