using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVidaPlus : AbstractItem
{
    public override void Efeito(Player player)
    {
        if(player.vida != player.max)
        {
            player.vida++;
        }

        player.max++;
        player.vida = player.max;

        base.Efeito(player);
    }
}
