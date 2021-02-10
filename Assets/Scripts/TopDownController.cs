using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public int movementSpeed;
    public SpriteRenderer sprite;
    public LevelLoader sm;
    private Vector2 direction;
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x == 1)
            sprite.flipX = false;
        else if (direction.x == -1)
            sprite.flipX = true;

    }
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + direction * movementSpeed * Time.fixedDeltaTime);
    }
}
