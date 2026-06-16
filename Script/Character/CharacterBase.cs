using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public int Attack;
    public int Speed;
    public int JumpPower;
    public int nowHealth;
    public int nowAttack;
    public int nowSpeed;
    public int nowJumpPower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void Move();

    public abstract void Reset();
    public abstract int SetHealth(int value);
    public abstract int SetAttack(int value);
    public abstract int SetSpeed(int value);
    public abstract int SetJumpPower(int value);

}
