using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDano : AbstractItem
{
    public override void Efeito(Player player)
    {
        if (player.ItemDano == false)
        {
            player.ItemDano = true;
            player.projetilPrefab.dano += 10;
            base.Efeito(player);
        }

    }
}
