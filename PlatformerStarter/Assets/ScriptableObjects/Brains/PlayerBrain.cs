using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Brains/Player")]
public class PlayerBrain : CharacterBrain
{
    public float movementSpeed = 20f;
    public float jumpVelocity = 20f;

    private bool isJumping;
    private bool isGrounded;

    public void OnEnable()
    {

    }

    public override void Think(CharacterBase character)
    {
        Move(character);
        Jump(character);
        UseAbility(character);
    }

    private void UseAbility(CharacterBase character)
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            if(character.ability == null){
                Debug.LogWarning("No abillity assigned to " + character.gameObject.name);
                return;
            }

            character.ability.Act(character);
        }
    }

    private void CheckIfGrounded(CharacterBase character)
    {
        isGrounded = Physics2D.Raycast(character.groundCheck.position, Vector2.down, 0.1f, character.groundLayer);
        
        if(isGrounded){
            if(isJumping){
                isJumping = false;
                // Todo: set animation
            }
        }
    }
    
    private void Jump(CharacterBase character)
    {
        CheckIfGrounded(character);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded){
                isJumping = true;
                character.rigidbody.velocity = new Vector2 (character.rigidbody.velocity.x, jumpVelocity);
                // Todo: set animation
            }

        }

    }

    private void Move(CharacterBase character)
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

        character.rigidbody.velocity += velocity * (movementSpeed * Time.deltaTime);
        character.transform.localScale = scale;        
    }
}
