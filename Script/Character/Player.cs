using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MoveState;

public class Player : CharacterBase
{
    public static Player Instance;
    public Rigidbody2D rb;
    public bool isGrounded;
    public int jumpCount;
    public PlayerStateMachine stateMachine;
    public Animator animator;

    public IdleState idleState { get; }
    public MoveState moveState { get; }
    public JumpState jumpState { get; }


    public Player()
    {
        idleState = new IdleState(this);
        moveState = new MoveState(this);
        jumpState = new JumpState(this);
        Instance = this;
        stateMachine = new PlayerStateMachine(idleState);
    }
    public override void Move()
    {
        SetAllSpeed();
        rb.velocity = new Vector2(nowSpeed, rb.velocity.y);
    }
    public void SetAllSpeed()
    {
        int isjump = (Input.GetKey(KeyCode.Space) ? 1 : 0);
        float hor = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        SetJumpPower((int)(isjump * JumpPower));
        SetSpeed((int)(hor * Speed));
    }

    public override void Reset()
    {
        nowAttack = Attack;
        nowHealth = Health;
        nowJumpPower = JumpPower;
        nowSpeed = Speed;
    }

    public override int SetAttack(int value)
    {
        nowAttack = value;
        return nowAttack;
    }

    public override int SetHealth(int value)
    {
        nowHealth = value;
        return nowHealth;
    }

    public override int SetJumpPower(int value)
    {
        nowJumpPower = value;
        return nowJumpPower;
    }

    public override int SetSpeed(int value)
    {
        nowSpeed = value;
        return nowSpeed;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        SetAttack(Attack);
        SetHealth(Health);
        SetJumpPower(JumpPower);
        SetSpeed(Speed);
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        stateMachine.Update();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        isGrounded = (TargetDetect(0.5f, LayerMask.GetMask("Ground")) != null);
    }
    public Collider2D TargetDetect(float range, LayerMask layerMask)
    {
        var temp= Physics2D.OverlapCircle(transform.position, range, layerMask);
        {   if (temp != null)
            {
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
