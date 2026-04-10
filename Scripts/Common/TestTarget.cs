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


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
        MoveControl();
    }
    public override void MoveControl()
    {
        if (!beControled) return;

        float hor =
            (Input.GetKey(KeyCode.D) ? 1 : 0) +
            (Input.GetKey(KeyCode.A) ? -1 : 0);

        rb.velocity = new Vector2(hor * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        Debug.Log($"Horizontal: {hor}, Velocity X: {rb.velocity.x}");
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
        throw new System.NotImplementedException();
    }

    public override void OnDetect()
    {
        throw new System.NotImplementedException();
    }
}
