using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //public float movePower = 10f; 
    private float direction = 0.3f;
    private Animator anim; 

    [SerializeField]
    private float speed=2;
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
    [SerializeField]
    private GameObject coffee1;
    [SerializeField]
    private GameObject coffee2;
    private coffeecontroller coffeecontrol1;
    private coffeecontroller coffeecontrol2;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>(); //by Jad

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

    void FixedUpdate()
    {
        if (enableKeyboardControl)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
             Vector2 movement = new Vector2(moveHorizontal, moveVertical);
             rb2d.velocity = (movement * speed);
            
                anim.SetBool("isRun", false);

                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.3f;


                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                   
                        anim.SetBool("isRun", true);
                    
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 0.3f;
                    transform.GetChild(0).localScale = new Vector3(direction, 0.3f, 0.3f);
                    anim.SetBool("isRun", true);

                }
                
              

        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2d.MovePosition(mousePosition);
        }
        
       
    }


    public void TakeDamage(int damage){
        
        hitsound.Play();
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Ded");
            PlayerPrefs.SetInt("score", ScoreManager.instance.score);
            SceneManager.LoadScene("GameOver");
        }else{

            healthBar.SetHealth(currentHealth); 
        }
        
        
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.tag == "EXP")
            {
            
            exp += 1;
              
            Destroy(other.gameObject);
                if (exp >= 20)
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
                }

            }
        }

    
}
