using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private float delayTime = 2f;

    [SerializeField]
    private float direction = 0.3f;
    private Animator anim;
    private bool isKickboard = false;
    
 
    [SerializeField]
    private float speed=3;

    private float kickboardSpeed ;
    public int lvl;
    public int exp;
    [SerializeField]
    private bool enableKeyboardControl;
    private Rigidbody2D rb2d;
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    public HealthBarController healthBar;
    private ParticleSystem lvluplights;
    public AudioSource lvlupsound;
    public AudioSource hitsound;
    public AudioSource kickBoardSound;
    [SerializeField]
    private GameObject coffee1;
    [SerializeField]
    private GameObject coffee2;
    private coffeecontroller coffeecontrol1;
    private coffeecontroller coffeecontrol2;
    public bool defaultshootright=true;
    private bool dead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        kickboardSpeed = speed + 4;
        StartCoroutine(KickboardLoader());



        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        lvluplights = GetComponent<ParticleSystem>();
        lvluplights.Stop();
        lvl = 1;
        exp = 0;
       
        coffeecontrol1 = coffee1.GetComponent<coffeecontroller>();
        coffeecontrol2 = coffee2.GetComponent<coffeecontroller>();
        
        coffeecontrol1.owncollider.enabled = false;
        coffeecontrol1.ownrenderer.color = new Color(0f, 0f, 0f, 0f);
        coffeecontrol2.owncollider.enabled = false;
        coffeecontrol2.ownrenderer.color = new Color(0f, 0f, 0f, 0f);

    }

    void KickBoard()
        {
            if (isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if ( !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);

            }
        }
    void FixedUpdate()
    {
        if (enableKeyboardControl)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

             
            
             if (!isKickboard){

                anim.SetBool("isRun", false);
                rb2d.velocity = (movement * speed);

                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.3f;

                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                   
                        anim.SetBool("isRun", true);
                    defaultshootright = false;

                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 0.3f;
                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                    anim.SetBool("isRun", true);
                    defaultshootright = true;

                }
            }

             if (isKickboard)
            {   
                rb2d.velocity = (movement * kickboardSpeed);
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.3f;
                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                    defaultshootright = false;
                }

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 0.3f;
                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                    defaultshootright = true;
                }
            }

        }
        
        
       
    }
  


    IEnumerator KickboardLoader() {
     // reset always when start
     isKickboard = true;
     KickBoard();
     yield return new WaitForSeconds(20f);
     kickBoardSound.Play();
     yield return new WaitForSeconds(1f);
      // added
     yield return new WaitWhile(() => Input.GetKeyDown(KeyCode.Space) == false);
     KickBoard();         
     yield return new WaitForSeconds(5f);
     KickBoard();
     StartCoroutine(KickboardLoader());
    }


    // for the Delay before Loading
    IEnumerator loadGameOverMenu() {
     yield return new WaitForSeconds(delayTime);
     SceneManager.LoadScene("GameOver");
    }

    public void TakeDamage(int damage)
    {
        if (dead == false) { 
        hitsound.Play();
        HurtAni();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            PlayerPrefs.SetInt("score", ScoreManager.instance.score);
            DieAni();
            enableKeyboardControl = false;
            healthBar.SetHealth(currentHealth);
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
            // wait a bit(2s) before Loading
            StartCoroutine(loadGameOverMenu());

        }
        else
        {

            healthBar.SetHealth(currentHealth);
        }
    } 
    }

    void HurtAni()
        {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);

                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb2d.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb2d.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }

    void DieAni()
    {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "EXP")
            {
            
            exp += 1;
              
            Destroy(other.gameObject);
                if (exp >= 20&&lvl<=7)
                {
                lvlupsound.Play();
                lvluplights.Play();
                lvl += 1;
                exp = 0;
                if(lvl==3)
                {
                    coffeecontrol1.owncollider.enabled = true;
                    coffeecontrol1.ownrenderer.color = new Color(1f, 1f, 1f, 1f);
                }
                if(lvl==5)
                {
                    coffee2.SetActive(true);
                    coffeecontrol2.owncollider.enabled = true;
                    coffeecontrol2.ownrenderer.color = new Color(1f, 1f, 1f, 1f);
                    coffeecontrol1.downtime = 0.5f;
                    coffeecontrol2.downtime = 0.5f;
                }
                if(lvl == 6)
                {
                    speed = 3.5F;
                }
                if(lvl ==7)
                {
                    coffeecontrol1.downtime = 0.2f;
                    coffeecontrol2.downtime = 0.2f;

                }
                }

            }
        }


 

}
