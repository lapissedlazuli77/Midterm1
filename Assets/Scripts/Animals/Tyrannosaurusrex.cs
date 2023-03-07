using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyrannosaurusrex : BaseDinosaur
{
    protected override void Chase()
    {
        AccelerateSpeed();
        Debug.Log(player.position);
        nav.destination = player.position;
    }

    protected override void Damage(float damage)
    {
        hp -= damage * 0.3f;
    }
    protected override void AccelerateSpeed()
    {
        nav.speed = 16;
    }
}
