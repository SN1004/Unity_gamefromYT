using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D enemybody;

    // Start is called before the first frame update
    void Awake()
    {
        enemybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemybody.velocity = new Vector2(speed, enemybody.velocity.y);    
    }
}
