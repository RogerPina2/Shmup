using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehavior : SteerableBehaviour, IDamageable
{
    GameManager gm;

    float angle = 0;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void FixedUpdate() {
        if (gm.gameState != GameManager.GameState.GAME) return;

        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;
        Thrust(0, Mathf.Cos(angle));
    }

    public void TakeDamage()
    {
        Die();
        gm.points += 200;
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
