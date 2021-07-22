using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class Menu : MonoBehaviour
{
    public GameObject iniciar;
    public float timer1 = 1;
    public float timer2 = 0.5f;
    public string cena;
    bool isRunning = false;

    void Start()
    {
        Thread.Sleep(1000);
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        var isShow = false;
        if(isRunning)
        {
            if (isShow)
            {
                timer1 -= Time.deltaTime;
                if (timer1 < 0)
                {
                    isShow = false;
                    timer2 = 0.5f;
                    iniciar.SetActive(true);
                }          
            }
            else
            {
                timer2 -= Time.deltaTime;
                if (timer2 < 0)
                {
                    isShow = true;
                    timer1 = 1;
                    iniciar.SetActive(false);
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
