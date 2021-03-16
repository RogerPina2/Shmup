using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    
    GameManager gm;
    Animator animator;
    EnemySpawner es;
    
    private void Start() {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }
    
    void FixedUpdate()
    {
        if (gm.gameState == GameManager.GameState.MENU)
        {
            transform.position = new Vector3(-9,0,0);
        }

        if (gm.gameState != GameManager.GameState.GAME) return;

        // To move the ship

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        // To shot
        if (Input.GetAxisRaw("Fire1") != 0) Shoot();
        
        // To pause
        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
           gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Inimigos")) {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        gm.lifes--;
        if (gm.lifes <= 0) Die();
        // throw new System.NotImplementedException();
    }

    public void Die()
    {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        // estDroy(gameObject);
    }
    
    // Tiro do player
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public AudioClip shootSFX;

    public GameObject bullet;
    public Transform arma01;

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;

        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
        
        // throw new System.NotImplementedException();
    }

    
}
