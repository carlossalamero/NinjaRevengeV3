using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 10f;
    public bool tocaSuelo;
    float dirx;
    public SpriteRenderer renderer;
    public Animator animatronix;
    Rigidbody2D rBody;
    public GameManager gameManager;
    public Transform attackHitBox;
    public float attackRange;
    public LayerMask enemylayer;
    public SFXmanager sfxmanager;
    void Awake()
    {
        animatronix = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxmanager = GameObject.Find("SFXmanager").GetComponent<SFXmanager>();

    }

    void FixedUpdate()
    {

        rBody.velocity = new Vector2(dirx * speed, rBody.velocity.y);

    }

     void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        
        Debug.Log(dirx);

         if(dirx == -1)
        {
            //renderer.flipX = true;
            transform.rotation = Quaternion.Euler(0,180,0);
            animatronix.SetBool("Andar", true);
        }
        else if(dirx == 1)
        {
            //renderer.flipX = false;
            transform.rotation = Quaternion.Euler(0,0,0);
            animatronix.SetBool("Andar", true);
        }
        else
        {
            animatronix.SetBool("Andar", false);
        }
        
        if(Input.GetButtonDown("Salto") && tocaSuelo) 
        {

            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); 
            animatronix.SetBool("Salto", true);

        }
        if(Input.GetButtonDown("Fire1"))
        {

             Attack();
             animatronix.SetTrigger("Atacar");
        }

    }

     public void Attack()
    {

        Collider2D[] attackedEnemies = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemylayer);

        foreach(Collider2D enemy in attackedEnemies)
        {

            Destroy(enemy.gameObject);
            gameManager.Muerteninja();
        

        }

    }

    void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);

    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.CompareTag("Antorcha"))
        {

            Debug.Log("Nivel completado");
            gameManager.Win();
            SceneManager.LoadScene(0);
           

            
            
                  
        }

        if(collider.gameObject.CompareTag("DeathZone"))
        {

            Debug.Log("Has muerto");
            gameManager.Muerte();
            Destroy(gameObject);
            
            

        }

    }

}
