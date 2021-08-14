using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTiro : AbstractItem
{
    public AbstractTiro projetilPrefab;

    public override void Efeito(Player player)
    {
        player.projetilPrefab = projetilPrefab;
        player.Reset(true);
        
        base.Efeito(player);
    }
}
