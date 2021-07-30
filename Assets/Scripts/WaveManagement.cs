using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WaveManagement : MonoBehaviour
{
    public Player playerPrefab;
    public AbstractInimigo inimigoPrefab;
    public Atirador inimigoPrefab2;//v
    public int numeroDeInimigos;
    public int intervaloEntreInimigos;
    public GameObject sprite_inimigo;
    GameObject tela_instrucao;
    public Text PrefabTexto;
    public Canvas Pai;
    AbstractInimigo[] inimigos_totais;
    int carregou;
    IEnumerator Start()
    {
        carregou = 0;
        //Criando tela de instru��o para usu�rio
        tela_instrucao = Instantiate(sprite_inimigo, new Vector3(0, 0.4f, 0), Quaternion.identity);
        tela_instrucao.transform.position.Set(0, 0.4f, 0);
        var Texto = Instantiate(PrefabTexto, new Vector3(0, -80, 0), Quaternion.identity);
        Texto.transform.SetParent(Pai.transform, false);
        Texto.text = "Este inimigo � o seu primeiro desafio, ele ir� te seguir at� chegar em voc�, caso encoste voc� perde uma vida, por�m ele � destruido tamb�m.\n" +
            "Atire nele para tentar destru�-lo antes que ele se aproxime.";
        yield return new WaitForSeconds(6f);
        Destroy(tela_instrucao);
        Destroy(Texto);

        //Spawanando inimigos
        inimigos_totais = new AbstractInimigo[numeroDeInimigos];
        var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < numeroDeInimigos; i++)
        {
            inimigos_totais[i] = Instantiate(inimigoPrefab, GetPosition(), Quaternion.identity);
            inimigos_totais[i].player = player;
            inimigos_totais[i].startTime = i * intervaloEntreInimigos;
        }

       
        Atirador inimigo_2 = Instantiate(inimigoPrefab2, GetPosition(), Quaternion.identity);//v
        inimigo_2.player = player;//v
        inimigo_2.startTime = 1;//v
        

        carregou = 1;
    }

    
    private void Update()
    {
        if(carregou==1 && isNull(inimigos_totais) )
        {
            SceneManager.LoadScene("Winner");
        }
    }
    public bool isNull(AbstractInimigo[] inimigos_totais)
    {
        for (int i = 0; i < numeroDeInimigos; i++)
        {
            if (inimigos_totais[i] != null)
            {
                return false;
            }
        }
        return true;
    }
    Vector3 GetPosition()
    {
        var x = Random.Range(0, 10)%2 == 0 ? 1 : -1;
        return new Vector3(x*Random.Range(1.75f, 2.75f), Random.Range(-2.5f, 2.5f), 0);
    }
}
