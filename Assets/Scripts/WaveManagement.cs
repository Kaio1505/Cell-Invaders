using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    public Player playerPrefab;
    public AbstractInimigo inimigoPrefab;
    public int numeroDeInimigos;
    public int intervaloEntreInimigos;

    // Start is called before the first frame update
    void Start()
    {
        
        var player = Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        for(int i = 0; i < numeroDeInimigos; i++)
        {
            var inimigo = Instantiate(inimigoPrefab, GetPosition(), Quaternion.identity);
            inimigo.player = player;
            inimigo.startTime = i*intervaloEntreInimigos;
        }
    }

    Vector3 GetPosition()
    {
        var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
        return new Vector3(x*Random.Range(1.75f, 2.75f), Random.Range(-2.5f, 2.5f), 0);
    }
}
