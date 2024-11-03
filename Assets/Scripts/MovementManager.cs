using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementManager : MonoBehaviour{

    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask WallsLayer;
    
    public new Rigidbody2D rigidbody{
        get;
        private set;
    }

    public Vector2 direction{
        get;
        private set;
    }

    public Vector2 nextDirection{
        get;
        private set;
    }

    public Vector3 startingPosition{
        get;
        private set;
    }

    private void Awake(){
        this.rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Start(){
        ReState();
    }

    public void ReState(){

        this.speedMultiplier = 1f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void FixedUpdate(){
        Vector2 position = rigidbody.position;
        Vector2 translation = speed * speedMultiplier * Time.fixedDeltaTime * direction;

        rigidbody.MovePosition(position + translation);
    }
    private void Update(){

        if (this.nextDirection != Vector2.zero) {
            SetDirection(this.nextDirection);
        }
    }


    public void SetDirection(Vector2 direction, bool forced = false){
        if (!Occupied(direction) || forced){

            this.direction = direction;
            this.nextDirection = Vector2.zero;

        }else{

            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction){
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, this.WallsLayer);
        return hit.collider != null;
    }
}
