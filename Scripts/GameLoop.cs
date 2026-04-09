//==========================
// - FileName: GameLoop.cs
// - Created: yeyuotc
// - CreateTime: #CreateTime#
// - Email: 1079221637@qq.com
// - Description: 处理游戏的主要循环,包括更新
//==========================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLoop : MonoBehaviour 
{
    //每帧调用
    private void Update()
    {
        //游戏逻辑的更新
        GameLogicUpdate();

    }


    //相机的跟随
    private void LateUpdate()
    {
        CameraFollowUpdate();
    }

    private void FixedUpdate()
    {
        //处理物理更新，固定帧
        PhysicsUpdate();
    }

   
    private void CameraFollowUpdate()
    {

    }


    private void GameLogicUpdate()
    {

    }

    private void PhysicsUpdate()
    {

    }
}