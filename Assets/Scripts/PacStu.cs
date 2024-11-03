using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementManager))]
public class PacStu : MonoBehaviour
{
    [SerializeField]
    // private AnimatedSprite deathSequence;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    public MovementManager movement{
        get;
        private set;
    }

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        this.movement = GetComponent<MovementManager>();
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            movement.SetDirection(Vector2.up);
        }else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            movement.SetDirection(Vector2.down);
        }else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            movement.SetDirection(Vector2.left);
        }else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    // public void ResetState()
    // {
    //     enabled = true;
    //     spriteRenderer.enabled = true;
    //     circleCollider.enabled = true;
    //     deathSequence.enabled = false;
    //     movement.ResetState();
    //     gameObject.SetActive(true);
    // }

    // public void DeathSequence()
    // {
    //     enabled = false;
    //     spriteRenderer.enabled = false;
    //     circleCollider.enabled = false;
    //     movement.enabled = false;
    //     deathSequence.enabled = true;
    //     deathSequence.Restart();
    // }

}

