using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour
{
    Text numVidas;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        numVidas = GameObject.Find("NumVidas").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            numVidas.text = $"{player.vida}";
        }
        else
        {
            try
            {
                player =  GameObject.FindGameObjectsWithTag("Player").First().GetComponent<Player>();
            }
            catch
            {

            }
        }
        
    }
}
