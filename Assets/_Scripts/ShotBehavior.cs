using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : SteerableBehaviour, IDamageable
{
    GameManager gm;
    Animator animator;

    void Start()
    {
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
    }

    float timer = 0;

    private void Update() {    
        if (gm.gameState != GameManager.GameState.GAME) return;
        timer += Time.deltaTime;

        if (timer > 0.1) {
            animator.SetFloat("Time", 1.0f);
        }

        Thrust(1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;

        animator.SetBool("Col", true);
        StartCoroutine(Example());
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.2f);
        print(Time.time);
        
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
