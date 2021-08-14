using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour
{
    public Image Vida;
    public Image Boss;
    public Text numVidas;
    public Text bossVida;
    Player player;
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        Vida.enabled = false;
        Boss.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            numVidas.text = $"{player.vida}";

            if(boss != null)
            {
                bossVida.text = $"{boss.vida}";
            }
            else
            {
                try
                {
                    boss =  GameObject.FindGameObjectsWithTag("Boss").First().GetComponent<Boss>();
                    Boss.enabled = true;
                }
                catch
                {
                    
                }
            }
        }
        else
        {
            try
            {
                player =  GameObject.FindGameObjectsWithTag("Player").First().GetComponent<Player>();
                Vida.enabled = true;
            }
            catch
            {

            }
        }
        
    }
}
