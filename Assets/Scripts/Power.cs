using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Pellet
{
    public float duration = 8f;

    protected override void Eat(){
        FindObjectOfType<GameManager>().PowerEaten(this);
    }

}