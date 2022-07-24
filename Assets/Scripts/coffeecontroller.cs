using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeecontroller : MonoBehaviour
{
    
    public Collider2D owncollider;
    public SpriteRenderer ownrenderer;
    public float downtime = 1;
    // Start is called before the first frame update
    void Awake()
    {
        owncollider = GetComponent<Collider2D>();
        
        ownrenderer = GetComponent<SpriteRenderer>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // player should take damage here

            owncollider.enabled = false;
            ownrenderer.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(downtime);
            owncollider.enabled = true;
            ownrenderer.color = new Color(1f, 1f, 1f, 1f);
        }
       
    }
}
