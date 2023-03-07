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

    protected override void SetHealth()
    {
        hp = 90000;
    }
    protected override void AccelerateSpeed()
    {
        nav.speed = 16;
    }
}
