using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    Text iniciar;
    public float timer1 = 0.5f;
    public float timer2 = 1;
    public string cena;
    bool isRunning = false;
    public Text PrefabText;
    public Font contagion;
    public Canvas Pai;
    public bool subiu=false;
    Text logo;
    public GameObject[] inimigos;
    float height;
    float width;
    public Camera camera_dimensao;
    void Start()
    {
        //pega a altura e largura da camera
        height = 2f * camera_dimensao.orthographicSize;
        width = height * camera_dimensao.aspect;
        //Cria as sprites que apareceram de plano de fundo
        criarSprites();

        //Instancia o texto "Cell Invaders" que irá subir
        logo = Instantiate(PrefabText, new Vector3(10, -300, 0), Quaternion.identity);
        logo.transform.SetParent(Pai.transform, false);
        logo.font = contagion;
        logo.fontSize = 50;
        logo.resizeTextForBestFit = true;
        logo.text = "Cell Invaders";

        //Instancia o texto para poder jogar
        iniciar = Instantiate(PrefabText, new Vector3(10, -126, 0), Quaternion.identity);
        iniciar.transform.SetParent(Pai.transform, false);
        iniciar.font = contagion;
        iniciar.fontSize = 37;
        iniciar.resizeTextForBestFit=true;
        iniciar.text = "Clique na tela para iniciar o jogo";
        iniciar.enabled = false;
        isRunning = true;
    }

    public void criarSprites()
    {
        for(int i=0;i<inimigos.Length;i++)
        {
            inimigos[i]=Instantiate(inimigos[i], new Vector3((Screen.width/2), (Screen.height/2), 0),Quaternion.identity);
            Rigidbody2D rb = inimigos[i].GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(Random.Range(-10,10), Random.Range(-10, 10),0)*4;
            inimigos[i].transform.SetParent(Pai.transform, true);
        }
    }
    public void movimentarSprite()
    {
        for (int i = 0; i < inimigos.Length; i++)
        {
            Rigidbody2D rb = inimigos[i].GetComponent<Rigidbody2D>();
            if(inimigos[i].transform.position.x> Screen.width/2 || inimigos[i].transform.position.x <0)
            {
                rb.velocity.Set(-rb.velocity.x, rb.velocity.y);
            }
            if(inimigos[i].transform.position.y> Screen.height / 2 || inimigos[i].transform.position.y<0)
            {
                rb.velocity.Set(rb.velocity.x, -rb.velocity.y);
            }
        }
    }
    public void descerLogo()
    {
        var translaction = 20 * Time.deltaTime;
        logo.transform.Translate(new Vector3(0,10,0)*translaction);
        if(logo.rectTransform.position.y>=Screen.height/2)
        {
            subiu = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        movimentarSprite();
        if (!subiu)
        {
            descerLogo();
        }
        else
        {
            if (isRunning)
            {
                timer1 -= Time.deltaTime;
                if (timer1 < 0)
                {
                    isRunning = false;
                    timer2 = 1;
                    iniciar.enabled = true;
                }
            }
            else
            {
                timer2 -= Time.deltaTime;
                if (timer2 < 0)
                {
                    isRunning = true;
                    timer1 = 0.5f;
                    iniciar.enabled = false;
                }
            }
            //if(Input.anyKey)
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(cena);
            }
        }
        
    }
}

