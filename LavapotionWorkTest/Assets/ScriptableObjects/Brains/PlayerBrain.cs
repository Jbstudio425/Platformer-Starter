using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Brains/Player")]
public class PlayerBrain : CharacterBrain
{
    public float _movementSpeed = 20;
    public float _jumpVelocity = 40;

    //private bool _isJumping = false;

    public void OnEnable()
    {

    }

    public override void Think(CharacterBase character)
    {
        Vector2 velocity = Vector2.zero;
        Vector3 scale = character.transform.localScale;
        
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x += -1;
            scale.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
            scale.x = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_isJumping = true;
            velocity.y += _jumpVelocity;
        }


        character.rigidbody.velocity += velocity * (_movementSpeed * Time.deltaTime);
        character.transform.localScale = scale;        
    }
}
