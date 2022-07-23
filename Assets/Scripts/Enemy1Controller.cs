using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{

    private SpriteRenderer renderer;

    [SerializeField]
    private float speed = 1.0f;
    private Rigidbody2D rb2d;
    public float health = 10;
    public Vector2 targetvec; 
    [SerializeField]
    Vector2 target;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        target = new Vector2(player.transform.position.x,player.transform.position.y);
        GameObject timer = GameObject.FindWithTag("Timer");
        int phase = timer.GetComponent<Timer>().phase;
        health = 10 + 5 * phase;
        if (phase == 3)
        {
            speed = speed * 1.25f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {//took the players coordinate meaning it only flipped if players position related to the center of the map was + or - not in relation to the enemy himself
        //if(target.x > 0 ){
       //     Debug.Log("+ve");
        //    renderer.flipX = false;
       // } else{
       //     renderer.flipX = true;
       //    Debug.Log("-ve");
       // }

        float step = speed * Time.deltaTime;
         Vector2 vectorTo = Vector2.MoveTowards(transform.position,target,step);
        targetvec = vectorTo;
         rb2d.MovePosition(vectorTo);
         target = new Vector2(player.transform.position.x,player.transform.position.y);

        if (vectorTo.x > rb2d.position.x)
        {
            Debug.Log("+ve");
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
            Debug.Log("-ve");
        }
    }
}
