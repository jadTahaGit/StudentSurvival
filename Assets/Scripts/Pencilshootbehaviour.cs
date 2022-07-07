using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencilshootbehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 3f;
    private Rigidbody2D rb2d;
   
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
      
    
    }

    // Update is called once per frame
    void Start()
    {
        rb2d.AddForce(rb2d.transform.forward * speed);
        Destroy(gameObject, duration);
    }
}
