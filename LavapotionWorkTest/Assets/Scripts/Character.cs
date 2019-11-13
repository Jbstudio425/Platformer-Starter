using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float _movementSpeed = 20;
    float _jumpVelocity = 40;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        var velocity = Vector2.zero;
        var scale = transform.localScale;
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
            velocity.y += _jumpVelocity;
        }


        _rigidbody.velocity += velocity * (_movementSpeed * Time.deltaTime);
        transform.localScale = scale;
    }
}
