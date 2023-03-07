using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothronychus : BaseDinosaur
{
    protected override void Damage(float damage)
    {
        hp -= damage * 0.7f;
    }
}
