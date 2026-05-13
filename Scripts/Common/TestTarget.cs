//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:该脚本用于测试一些目标的基本逻辑
//==========================

using UnityEngine;

public class TestTarget : Target
{
    public float activeRange = 4f;
    public float attackRange = 1f;
    public float speed = 1.0f;
    public float jumpForce = 1;
    public GameObject target;

    private void Awake()
    {
        target = FindAnyObjectByType<Player>().gameObject;
        selfType =TargetType.Enemy;
        beControled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
        MoveControl();
    }
    public override void MoveControl()
    {
        if (!beControled)
        {
            MoveLogic();
            return;
        }

        float hor =
            (Input.GetKey(KeyCode.D) ? 1 : 0) +
            (Input.GetKey(KeyCode.A) ? -1 : 0);

        rb.velocity = new Vector2(hor * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Debug.Log($"Horizontal: {hor}, Velocity X: {rb.velocity.x}");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            transform.position,
            transform.position + Vector3.down * groundCheckDistance
        );
    }

    public override void MoveLogic()
    {
        bool inActiveRange = IsInActiveRange(target.transform);
        if (inActiveRange)
        {
            if(IsInAttackRange(target.transform))
            {
                //Debug.Log("攻击目标");
            }
            else
            {
                //Debug.Log("接近目标");
                var direction = (target.transform.position.x - transform.position.x) > 0 ? 1 : -1;
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }
        }
    }

    public override void OnDetect()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChangeContral();
        }
        throw new System.NotImplementedException();
    }

    public bool IsInActiveRange(Transform target)
    {
        return Vector2.Distance(transform.position, target.position) <= activeRange;
    }

    public bool IsInAttackRange(Transform target)
    {
            return Vector2.Distance(transform.position, target.position) <= attackRange;
    }
}
