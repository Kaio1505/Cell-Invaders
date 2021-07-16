using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    public Player playerPrefab;
    public AbstractInimigo inimigoPrefab;
    public int numeroDeInimigos;
    public int intervaloEntreInimigos;
    public GameObject prefabVida;
    int vida_atual;
    public GameObject[] vetor_vidas;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
        player = Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        for(int i = 0; i < numeroDeInimigos; i++)
        {
            var inimigo = Instantiate(inimigoPrefab, GetPosition(), Quaternion.identity);
            inimigo.player = player;
            inimigo.startTime = i*intervaloEntreInimigos;
        }
        vida_atual = player.vida;
        vetor_vidas = new GameObject[vida_atual];
        float espacamento = 0.2f;
        for (int i = 0; i < player.vida; i++)
        {
            vetor_vidas[i] = Instantiate(prefabVida, new Vector3(-1.5f + espacamento, 0.88f, 0), Quaternion.identity);
            espacamento += 0.2f;
        }
    }
    void Update()
    {
        if (player.vida < vida_atual)
        {
            Destroy(vetor_vidas[vida_atual-1]);
            vida_atual=player.vida;
        }
    }

    Vector3 GetPosition()
    {
        var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
        return new Vector3(x*Random.Range(1.5f, 2.5f), Random.Range(-2.0f, 2.0f), 0);
    }
}
