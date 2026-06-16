using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject throwPrefab;
    public Player player;

    public bool ThrowJavelin()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            //2D游戏要把z轴设置为0，否则会在3D空间中生成物体
            Vector2 direction = (mousePos - player.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rot= Quaternion.Euler(0, 0, angle);
            Instantiate(throwPrefab, player.transform.position, rot);
            Debug.DrawLine(player.transform.position, mousePos, Color.red, 2f);
            Debug.Log($"direction={direction}, angle={angle}");
            return true;
        }
        return false;
    }

}
