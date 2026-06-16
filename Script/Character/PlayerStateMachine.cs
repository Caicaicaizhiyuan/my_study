using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayState current;

    public PlayerStateMachine(PlayState initialState)
    {
        current = initialState;
        current?.Enter();
    }

    public void Update() => current?.Update();
    public void FixedUpdate() => current?.FixedUpdate();
    public void ChangeState(PlayState newState)
    {
        if (current != null)
        {
            current.Exit();
        }
        current = newState;
        current.Enter();
    }

}
