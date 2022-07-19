using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
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
    private AudioSource lvlupsound;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        lvluplights = GetComponent<ParticleSystem>();
        lvluplights.Stop();
        lvlupsound = GetComponent<AudioSource>();
        lvl = 1;
        exp = 0;
        
    }

    void FixedUpdate()
    {
        if (enableKeyboardControl)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = (movement * speed);
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2d.MovePosition(mousePosition);
        }
        
       
    }
    public void TakeDamage(int damage){
        
        
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
                if (exp >= 30)
                {
                lvlupsound.Play();
                lvluplights.Play();
                lvl += 1;
                exp = 0;
                }

            }
        }

    
}
