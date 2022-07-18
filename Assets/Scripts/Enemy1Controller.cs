using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private Rigidbody2D rb2d;
    public float health = 10;
    [SerializeField]
    Vector2 target;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        target = new Vector2(player.transform.position.x,player.transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         float step = speed * Time.deltaTime;
         Vector2 vectorTo = Vector2.MoveTowards(transform.position,target,step);
         rb2d.MovePosition(vectorTo);
         target = new Vector2(player.transform.position.x,player.transform.position.y);


    }
}
