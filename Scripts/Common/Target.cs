//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:该脚本用于定义一些目标的基本属性
//==========================

using UnityEngine;

public abstract class Target : MonoBehaviour
{
    public bool beControled;
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 1;
    public bool isGrounded;
    public Transform[] groundPoint;
    public LayerMask groundLayerMask = ~0;
    public LayerMask wallLayerMask;
    public float jumpForce=1;
    public float groundCheckDistance=1;
    public abstract void OnDetect();

    public abstract void MoveLogic();

    public abstract void MoveControl();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void CheckGround()
    {
        isGrounded = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundCheckDistance,
            groundLayerMask
        );
    }
}
