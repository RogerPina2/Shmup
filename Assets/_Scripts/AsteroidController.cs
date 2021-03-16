using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : SteerableBehaviour, IDamageable
{
    GameManager gm;
    
    void Start() {
        gm = GameManager.GetInstance();
    }
    
    public void TakeDamage()
    {
        Die();
        gm.points += 100;
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
