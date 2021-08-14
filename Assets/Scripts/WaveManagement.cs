using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

[System.Serializable]
public class InimigosSpawn
{
    public AbstractInimigo prefab;
    public int quantidade;
    public float intervaloEntreInimigos;

}

[System.Serializable]
public class Instrucoes 
{
    public GameObject spriteInimigo;
    public Text prefabTexto;
    public string text;
    public float tempoDeLeitura;
}

[System.Serializable]
public class Wave
{
    public float tempoDeEspera;
    public List<InimigosSpawn> inimigos = new List<InimigosSpawn>();
    public List<Instrucoes> instrucoes = new List<Instrucoes>();
}

public class WaveManagement : MonoBehaviour
{
    public Player playerPrefab;
    public Canvas pai;
    public List<Wave> waves = new List<Wave>();
    public List<AbstractInimigo> inimigosNaTela = new List<AbstractInimigo>();
    public Boss bossPrefab;

    bool fightBoss = false;
    bool comecou = false;
    Player player;
    int waveAtual = 0;

    void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        if(!existeInimigos(inimigosNaTela) && !comecou)
        {
            if(waves.Count == waveAtual && fightBoss)
            {
                StartCoroutine(MudaCena("Winner"));
            }
            else if(waves.Count == waveAtual)
            {
                var inimigo = Instantiate(bossPrefab, new Vector3(0.06f, 2.1f, 0f), Quaternion.identity);
                inimigosNaTela = new List<AbstractInimigo>();
                inimigo.player = player;
                inimigosNaTela.Add(inimigo);
                fightBoss = true;
            }
            else
            {
                var wave = waves[waveAtual];
                comecou = true;
                StartCoroutine(BeginWave());
            }
        }

        if(player.vida <= 0 || player == null)
        {
            StartCoroutine(MudaCena("GameOver"));
        }
    }

    public IEnumerator BeginWave()
    {
        var wave = waves[waveAtual];
        inimigosNaTela = new List<AbstractInimigo>();

        player.SetActivePlayer(false);
        yield return new WaitForSeconds(wave.tempoDeEspera);
        foreach(var instrucao in wave.instrucoes)
        {
            var telaInstrucao = Instantiate(instrucao.spriteInimigo, new Vector3(0, 0.4f, 0), Quaternion.identity);
            telaInstrucao.transform.position.Set(0, 0.4f, 0);
            var Texto = Instantiate(instrucao.prefabTexto, new Vector3(0, -80, 0), Quaternion.identity);
            Texto.transform.SetParent(pai.transform, false);
            Texto.text = instrucao.text;
            yield return new WaitForSeconds(instrucao.tempoDeLeitura);
            Destroy(telaInstrucao);
            Destroy(Texto);
        }

        player.SetActivePlayer(true);
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

        comecou = false;
        waveAtual++;
    }

    public bool existeInimigos(List<AbstractInimigo> inimigosNaTela)
    {
        var array = inimigosNaTela.ToArray();
        var numArray = inimigosNaTela.Count;

        for (int i = 0; i < numArray; i++)
        {
            if (array[i] != null)
            {
                return true;
            }
        }

        return false;
    }

    Vector3 GetPosition()
    {
        if(Random.Range(0,2) == 0)
        {
            var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
            return new Vector3(x*Random.Range(1.75f, 2.75f), Random.Range(-2.5f, 2.5f), 0);
        }
        else
        {
            var y = Random.Range(0, 10)%2 == 0 ? 1 : -1;
            return new Vector3(Random.Range(-1.75f, 1.75f), y*Random.Range(1.2f, 2.0f), 0);
        }
        
    }

    IEnumerator MudaCena(string name)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }

    public void AddInimigosTela(AbstractInimigo inimigo)
    {
        inimigosNaTela.Add(inimigo);
    }

}
