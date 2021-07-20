using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : AbstractItem
{
    public override void Efeito(Player player)
    {
        if(player.vida != player.max)
        {
            player.vida++;
        }

        base.Efeito(player);
    }
}
