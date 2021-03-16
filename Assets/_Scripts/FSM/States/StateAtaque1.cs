﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaque1 : State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    GameManager gm;
    
    public override void Awake()
    {
        base.Awake();
        gm = GameManager.GetInstance();

        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
    
        if(shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        //TODO: Movimentação quando atacando

        if (Time.time - _lastShootTimestamp < shootDelay) return;

        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
