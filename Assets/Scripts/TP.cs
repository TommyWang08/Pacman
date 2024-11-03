using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TP : MonoBehaviour{
    public Transform tp;

    private void OnTriggerEnter2D(Collider2D other){
        
        Vector3 position = other.transform.position;
        position.x = this.tp.position.x;
        position.y = this.tp.position.y;
        other.transform.position = position;
    }

}
