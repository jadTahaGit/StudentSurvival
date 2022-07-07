using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootatmovement : MonoBehaviour
{
    public Rigidbody2D Pencil;
    public Transform Playertransform;
    private Rigidbody2D rb2d;
    private float nextActionTime = 0.5f;
    public float period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
        

        //pencilclone= Instantiate(Pencil, Playertransform.position, Playertransform.rotation);
            Rigidbody2D pencilclone = Instantiate(Pencil, Playertransform.position, Playertransform.rotation);
            /*Set the projectile moving.*/
            pencilclone.velocity= rb2d.velocity*3;

        } 
    }
}
