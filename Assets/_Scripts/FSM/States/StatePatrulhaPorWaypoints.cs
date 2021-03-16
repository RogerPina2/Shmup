using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaPorWaypoints : State
{
    public Transform[] waypoints;
    SteerableBehaviour steerable;
    GameManager gm;

    public override void Awake()
    {
        base.Awake();
        gm = GameManager.GetInstance();

        // Criamos e populamos uma nova transição
        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 4.0f);
        ToAtacando.target = GetComponent<StateAtaque>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAtacando);
        
        // Configure a transição para outro estado aqui.
        steerable = GetComponent<SteerableBehaviour>();
    }

    public void Start()
    {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    }

    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if(Vector3.Distance(transform.position, waypoints[1].position) > 0.1f) 
        {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            steerable.Thrust(direction.x, direction.y);
        } else { 
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }
    }

}
