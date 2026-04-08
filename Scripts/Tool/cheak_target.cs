using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//该脚本用于通过层来检测目标，而当检测到目标时调用目标身上的target_reflect函数来反应
public class cheak_target : MonoBehaviour
{
    [SerializeField] private float detectRadius = 10f;
    [SerializeField] private LayerMask targetLayer;

    //目标检测函数
    public void DetectTarget()
    {
        Collider[] hits =Physics.OverlapSphere(transform.position, detectRadius,targetLayer);
        if(hits.Length ==0)
        {
            Debug.Log("没有检测到盐渍");
            return;
        }
        else
        {
            foreach (Collider c in hits)
            {
                var target = c.GetComponent<target_reflect>();
                if (target != null)
                {
                    target.OnDetected();
                }
            }
        }
    }

    //显示检测线
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
