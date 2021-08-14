using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTempoPlus : AbstractItem
{
    public override void Efeito(Player player)
    {
        player.tempoDeEfeito += 2;

        base.Efeito(player);
    }
}
