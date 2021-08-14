using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTiroTriplo : AbstractItem
{
    public override void Efeito(Player player)
    {
        player.tiroTriplo = true;
        player.Reset(false);

        base.Efeito(player);
    }
}
