using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayState
{
    public IdleState(Player player)
    {
        this.player = player;
    }
    public override void Enter()
    {
        stateCount = 0;
        stateTime = 0;
        stateTimeLimit = 0.1f;
    }
    public override void Exit()
    {
        
    }
    public override void FixedUpdate()
    {
        
    }
    public override void Update()
    {

        stateTime += Time.deltaTime;
        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            player.stateMachine.ChangeState(player.moveState);
        }
        if (Input.GetKey(KeyCode.Space)){
            player.stateMachine.ChangeState(player.jumpState);
        }
    }
}

public class MoveState : PlayState
{
    public MoveState(Player player)
    {
        this.player = player;
    }
    public override void Enter()
    {
        Debug.Log("Move");
        player.animator.SetBool("move", true);
        stateCount = 0;
        stateTime = 0;
        stateTimeLimit = 0.1f;
    }
    public override void Exit()
    {
        player.animator.SetBool("move", false);
    }
    public override void FixedUpdate()
    {
    }
    public override void Update()
    {
        stateTime += Time.deltaTime;
        player.Move();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            player.stateMachine.ChangeState(player.jumpState);
        }
    }

    public class JumpState : PlayState
    {
        public JumpState(Player player)
        {
            this.player = player;
        }
        public override void Enter()
        {
            Debug.Log("Jump");
            player.animator.SetBool("jump", true);
            stateCount = 0;
            stateTime = 0;
            stateTimeLimit = 0.1f;
        }
        public override void Exit()
        {
            stateCount = 0;
            player.animator.SetBool("jump", false);
        }
        public override void FixedUpdate()
        {

        }
        public override void Update()
        {
            stateTime += Time.deltaTime;
            player.Move();
            if (stateCount < 2)
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, player.JumpPower);
                stateCount++;
            }
            if (player.rb.velocity.y <= 0 && player.isGrounded)
            {

                player.stateMachine.ChangeState(player.idleState);
            }
        }
    }

    public class AttackState : PlayState
    {
        public AttackState(Player player)
        {
            this.player = player;
        }
        public override void Enter()
        {
            Debug.Log("Attack");
            player.animator.SetBool("attack", true);
            stateCount = 0;
            stateTime = 0;
            stateTimeLimit = 0.1f;
        }
        public override void Exit()
        {
            stateCount = 0;
            player.animator.SetBool("attack", false);
        }
        public override void FixedUpdate()
        {
        }
        public override void Update()
        {
            stateTime += Time.deltaTime;

        }
    }
}
