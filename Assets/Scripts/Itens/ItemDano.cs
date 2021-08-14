using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDano : AbstractItem
{
    public int dano;

    public override void Efeito(Player player)
    {
        player.ResetProps();
        player.dano = dano;
        player.Reset(false);
        base.Efeito(player);
    }
}
