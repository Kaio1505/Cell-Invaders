using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject iniciar;
    public float timer1;
    public float timer2;
    float oldTimer;
    bool isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = 1;
        timer2 = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timer1 -= Time.deltaTime;
            if (timer1 < 0)
            {
                isRunning = false;
                timer2 = 0.5f;
                iniciar.SetActive(false);
            }          
        }
        else
        {
            timer2 -= Time.deltaTime;
            if (timer2 < 0)
            {
                isRunning = true;
                timer1 = 1;
                iniciar.SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("CellInvaders");
        }
    }
}
