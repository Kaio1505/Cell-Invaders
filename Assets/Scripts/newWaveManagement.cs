using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InimigosSpawn
{
    public AbstractInimigo prefab;
    public int quantidade;
    public float intervaloEntreInimigos;

}

public class Instrucoes
{
    public GameObject spriteInimigo;
    public Text prefabTexto;
    public Canvas pai;
    public string text;
    public float tempoDeLeitura;
}

public class Wave
{
    public float tempoDeEspera;
    public List<InimigosSpawn> inimigos = new List<InimigosSpawn>();
    public List<Instrucoes> instrucoes = new List<Instrucoes>();
}

public class newWaveManagement : MonoBehaviour
{
    public Player playerPrefab;
    public List<Wave> waves = new List<Wave>();
    public List<AbstractInimigo> inimigosNaTela = new List<AbstractInimigo>();
    Player player;
    int waveAtual = 0;

    void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        if(!existeInimigos(inimigosNaTela))
        {
            //condicional para verificar se é a ultima wave, se sim levar para a tela de vitoria
            var wave = waves[waveAtual];
            Invoke("BeginWave", wave.tempoDeEspera);
        }
    }

    public IEnumerator BeginWave()
    {
        var wave = waves[waveAtual];
        inimigosNaTela = new List<AbstractInimigo>();

        foreach(var instrucao in wave.instrucoes)
        {
            var telaInstrucao = Instantiate(instrucao.spriteInimigo, new Vector3(0, 0.4f, 0), Quaternion.identity);
            telaInstrucao.transform.position.Set(0, 0.4f, 0);
            var Texto = Instantiate(instrucao.prefabTexto, new Vector3(0, -80, 0), Quaternion.identity);
            Texto.transform.SetParent(instrucao.pai.transform, false);
            Texto.text = instrucao.text;
            yield return new WaitForSeconds(instrucao.tempoDeLeitura);
            Destroy(telaInstrucao);
            Destroy(Texto);
        }

        foreach(var spaw in wave.inimigos)
        {
            for(int i = 0; i < spaw.quantidade; i++)
            {
                var inimigo = Instantiate(spaw.prefab, GetPosition(), Quaternion.identity);
                inimigo.player = player;
                inimigo.startTime = ( i + 1) * spaw.intervaloEntreInimigos;
                inimigosNaTela.Add(inimigo);
            }
        }

        waveAtual++;
    }

    public bool existeInimigos(List<AbstractInimigo> inimigosNaTela)
    {
        foreach (var item in inimigosNaTela)
        {
            if(item != null)
                return true;
        }

        return false;
    }

    Vector3 GetPosition()
    {
        var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
        return new Vector3(x*Random.Range(1.75f, 2.75f), Random.Range(-2.5f, 2.5f), 0);
    }

    //funcao que permite add inimigos na inimigosTela

}
