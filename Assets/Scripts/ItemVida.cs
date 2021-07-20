using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : AbstractItem
{
    public override void Efeito()
    {
        player.vida++;
        base.Efeito();
    }
}
