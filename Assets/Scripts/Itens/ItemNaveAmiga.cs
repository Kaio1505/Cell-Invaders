using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNaveAmiga :  AbstractItem
{
    public Player playerPrefab;

    public override void Efeito(Player player)
    {
        var playerAmigo = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        playerAmigo.NaveAmiga = true;
        playerAmigo.tempoDeEfeito = player.tempoDeEfeito;
        playerAmigo.Reset(false);

        base.Efeito(player);
    }
}
