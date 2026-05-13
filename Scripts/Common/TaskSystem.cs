//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:实现任务系统
//==========================
using System;
using UnityEngine;
using UnityEngine.UI;


public interface IQuestCondition
{
    bool IsMet { get; }
    void RegisterListener(Action onMet);
}

public class KillTargetCondition : IQuestCondition
{
    private int _currentKills;
    public bool IsMet => _currentKills >= 0;
    void IQuestCondition.RegisterListener(Action onMet)
        {
            throw new NotImplementedException();
        }
}

public interface IQuestRewardDispatcher
{
    void Dispatch(string rewardname, int amount);
}

public class DefaultRewardDispatcher : IQuestRewardDispatcher
{
    public void Dispatch(string rewardname, int amount)
    {
        Debug.Log($"发放了{rewardname}");
    }
}

public interface IQuestUI
{
    void UpdatePro(int current, int target);
}

public class QuestUI : IQuestUI
{
    public Text progressText;
    public void UpdatePro(int current, int target)
    {
        progressText.text = $"任务进度{current}/{target}";
    }
}