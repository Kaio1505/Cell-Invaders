using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public Player playerPrefab;
    public Vidas prefabVida;
    int vida_atual;
    public Vidas[] vetor_vidas;
    // Start is called before the first frame update
    void Start()
    {
        vida_atual = playerPrefab.vida;
        float espacamento = 0.2f;
        for(int i=0;i<playerPrefab.vida;i++)
        {
            vetor_vidas[i]=Instantiate(prefabVida,new Vector3(-1.3f+ espacamento, 0.88f,0),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPrefab.vida<vida_atual)
        {
            Destroy(vetor_vidas[vida_atual]);
            vida_atual--;
        }
    }
}
