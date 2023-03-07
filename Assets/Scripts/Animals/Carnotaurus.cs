using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnotaurus : BaseDinosaur
{
    protected override void Damage(float damage)
    {
        hp -= damage * 0.7f;
    }
    protected override void AccelerateSpeed()
    {
        nav.speed = 13;
    }
}
