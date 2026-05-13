//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:这里可以实现简单的玩家逻辑
//==========================

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public bool isGrounded;
    public Transform[] groundPoint;
    public LayerMask groundLayerMask = ~0;
    public LayerMask targetLayerMask = ~0;
    public float groundCheckDistance = 1;
    public float activeRange = 8f;
    public float attackRange = 2f;
    public float speed = 3.0f;
    public float jumpForce = 1;
    public float flyspeed = 3.0f;
    public bool isDie=false;
    public bool controlTarget=false;
    private Sprite sprite;
    GameObject newObj;


    private static Player _instance;
        
    public static Player Instance
    {   
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(Player).Name, new[] { typeof(Player) });
                    DontDestroyOnLoad(obj);
                    _instance = obj.GetComponent<Player>();
                }
                else
                {
                    Debug.Log("单例已经存在");
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Logic();
    }

    public void Logic()
    {
        Move();
        IsTarget();
        if (isDie)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Revive();
            }
        }
    }
    public void Move()
    {
        if (controlTarget) return;
        if (isDie)
        {
            float ver=(Input.GetKey(KeyCode.W) ? 1 : 0) +(Input.GetKey(KeyCode.S) ? -1 : 0);
            rb.velocity = new Vector2(rb.velocity.x, ver * flyspeed);
        }

        float hor =
            (Input.GetKey(KeyCode.D) ? 1 : 0) +
            (Input.GetKey(KeyCode.A) ? -1 : 0);

        rb.velocity = new Vector2(hor * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public bool CheckGround()
    {
        return isGrounded = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundCheckDistance,
            groundLayerMask
        );
    }

    public void ImageChange(string spritePath="Image/PlayerSprite",Sprite sprite=null)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(spritePath);

        if (loadedSprite != null)
        {
            sprite = loadedSprite;
        }
    }

    public void CreateDie()
    {
        newObj = new GameObject("NewImage");
        // 2. 设置位置（原地生成）
        newObj.transform.position = transform.position;

        // 3. 添加 SpriteRenderer 组件
        SpriteRenderer sr = newObj.AddComponent<SpriteRenderer>();

        // 4. 加载并赋值图片（确保图片已设为 Sprite 类型）
        ImageChange("Image/Player",sr.sprite);
        ImageChange("Image/PlayerSprite", sprite);
    }

    public void Revive()
    {
        transform.position=newObj.transform.position;
        Destroy(newObj);
        ImageChange("Image/Player", sprite);
        isDie = false;
        controlTarget = false;
    }

    public void OnDetact()
    {
        isDie = true;
    }
    public void IsTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 3.0f,targetLayerMask);
        if(hit==null)
        {
            return;
        }
        TestTarget target = hit.GetComponent<TestTarget>();
        if(target==null)
        {
            return;
        }
        if (target.selfType == TargetType.Enemy&&isDie)
        {
            Debug.Log($"现在可以控制他一下了");
            if (Input.GetKeyDown(KeyCode.E))
            {
                target.ChangeContral();
                controlTarget = true;
                CreateDie();
                Debug.Log($"现在可以控制他了");
            }
        }
    }

}
