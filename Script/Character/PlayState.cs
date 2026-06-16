using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayState
{
    protected Player player;
    protected int stateCount;
    protected float stateTime;
    protected float stateTimeLimit;
    
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void FixedUpdate();
}
