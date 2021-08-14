using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEscudo : AbstractItem
{
    public override void Efeito(Player player)
    {
        player.isEscudo = true;
        player.escudo.SetActive(true);
        player.Reset(false);
        base.Efeito(player);
    }
}
