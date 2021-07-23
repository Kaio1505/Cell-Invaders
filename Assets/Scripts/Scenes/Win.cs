using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
public class Win : MonoBehaviour
{
    Text iniciar;
    public float timer1 = 0.5f;
    public float timer2 = 1;
    public string cena;
    bool isRunning = false;
    public Text PrefabText;
    public Font contagion;
    public Canvas Pai;
    public bool subiu = false;
    Text logo;

    void Start()
    {
        //Instancia o texto "Cell Invaders" que irá subir
        logo = Instantiate(PrefabText, new Vector3(10, -300, 0), Quaternion.identity);
        logo.transform.SetParent(Pai.transform, false);
        logo.font = contagion;
        logo.fontSize = 50;
        logo.resizeTextForBestFit = true;
        logo.text = "Win";

        //Instancia o texto para poder jogar
        iniciar = Instantiate(PrefabText, new Vector3(10, -126, 0), Quaternion.identity);
        iniciar.transform.SetParent(Pai.transform, false);
        iniciar.font = contagion;
        iniciar.fontSize = 37;
        iniciar.resizeTextForBestFit = true;
        iniciar.text = "Clique na tela para iniciar o jogo";
        iniciar.enabled = false;
        isRunning = true;
    }
    public void descerLogo()
    {
        var translaction = 20 * Time.deltaTime;
        logo.transform.Translate(new Vector3(0, 10, 0) * translaction);
        if (logo.rectTransform.position.y >= Screen.height / 2)
        {
            subiu = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
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

