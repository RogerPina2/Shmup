using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    GameManager gm;

    public GameObject tiro;

    void Start() {
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
        // throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        Die();
        gm.points += 500;
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
