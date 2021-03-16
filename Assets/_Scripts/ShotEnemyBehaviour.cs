using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour, IDamageable
{
    GameManager gm;

    private Vector3 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos")) return;
        if (collision.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        } 

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        // Teleguiado
        // Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        // direction =  (posPlayer - transform.position).normalized;
        Thrust(direction.x, direction.y);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
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
