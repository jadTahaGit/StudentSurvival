using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootatmovement : MonoBehaviour
{
    public Rigidbody2D Pencil;
    public Transform Playertransform;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float timeuntilshot = 1.25f;
    private float timer = 0;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeuntilshot)
        {
            timer = 0;
        

        
            Rigidbody2D pencilclone = Instantiate(Pencil, Playertransform.position, Playertransform.rotation);
            if (controller.lvl > 1)
            {
                pencilclone.GetComponent<Pencilshootbehaviour>().owndamage.damage = 15;
                timeuntilshot = 0.75f;
            }
                /*Set the projectile moving.*/
                if (rb2d.velocity.magnitude < 1)
            {

                pencilclone.velocity = Vector2.right * 3;
            }
            else
            {
                pencilclone.velocity = rb2d.velocity * 3;
            }
            if (controller.lvl > 3)
            {
                Rigidbody2D pencilclone2 = Instantiate(Pencil, Playertransform.position, Playertransform.rotation);
                pencilclone2.GetComponent<Pencilshootbehaviour>().owndamage.damage = 15;
                if (rb2d.velocity.magnitude < 1)
                {

                    pencilclone2.velocity = Vector2.left * 3;
                }
                else
                {
                    pencilclone2.velocity = -rb2d.velocity * 3;
                }
            }

        } 
    }
}
