using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Aboba : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private string groundLayerName = "Ground";
    private Rigidbody2D enemyRigidBody;
    private bool isFacingRight;
    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(isFacingRight ? speed : -speed, enemyRigidBody.velocity.y);
        enemyRigidBody.velocity = velocity;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer !=LayerMask.NameToLayer(groundLayerName)) { return; }
        Flip();
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
         
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
