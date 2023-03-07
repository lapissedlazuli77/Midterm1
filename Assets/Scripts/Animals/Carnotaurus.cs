using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnotaurus : BaseDinosaur
{
    protected override void AccelerateSpeed()
    {
        nav.speed = 13;
    }
    protected override void SetHealth()
    {
        hp = 200;
    }
}
