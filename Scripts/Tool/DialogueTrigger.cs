//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:用于触发对话的组件，当玩家进入触发范围并按下指定按键时，启动对话
//==========================
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string startDialogueId;
    public KeyCode triggerKey = KeyCode.E;

    private bool _playerInRange;

    private void Update()
    {
        DetectPlayer();
        if (_playerInRange && Input.GetKeyDown(triggerKey))
        {
            DialogueManager.Instance.StartDialogue(startDialogueId);
        }
    }

    private void DetectPlayer()
    {
        // 先清空状态
        _playerInRange = false;

        var collider = Physics2D.OverlapCircle(
            transform.position,
            0.5f,
            layerMask: LayerMask.GetMask("target")
        );

        // ✅ 关键点：一定要判空
        if (collider == null) return;
        _playerInRange = true;
    }

    // 可选：在 Scene 视图中显示检测范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}