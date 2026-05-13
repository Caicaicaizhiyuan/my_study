//==========================
// - FileName: Target.cs
// - Created: caizhiyuan
// - CreateTime: #CreateTime#
// - Email: 3157521164@qq.com
// - Description:实现任务系统
//==========================
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // 注册纯C#类为单例 (Singleton)
        builder.Register<IQuestCondition, KillTargetCondition>(Lifetime.Singleton);
        builder.Register<IQuestRewardDispatcher, DefaultRewardDispatcher>(Lifetime.Singleton);

        // 注册Unity组件 (从场景中寻找已有的 QuestUI)
        builder.RegisterComponentInHierarchy<QuestUI>();
        builder.Register<IQuestUI>(c => c.Resolve<QuestUI>(), Lifetime.Singleton);

        // 注册任务系统主驱动器
        builder.RegisterEntryPoint<QuestSystemRunner>();
    }
}

// 这个类不需要挂在任何GameObject上，VContainer会自动new它并注入依赖
public class QuestSystemRunner : IStartable, ITickable
{
    private readonly IQuestCondition _condition;
    private readonly IQuestRewardDispatcher _rewardDispatcher;
    private readonly IQuestUI _questUI;

    // 构造函数注入：VContainer 看到这三个参数，会自动去容器里把对应的实例塞进来
    public QuestSystemRunner(IQuestCondition condition, IQuestRewardDispatcher dispatcher, IQuestUI ui)
    {
        _condition = condition;
        _rewardDispatcher = dispatcher;
        _questUI = ui;
    }

    public void Start()
    {
        _condition.RegisterListener(OnQuestCompleted);
        Debug.Log("任务系统已启动，正在监听击杀条件...");
    }

    public void Tick()
    {
        // 每帧刷新UI（实际可用事件驱动代替）
        // _questUI.UpdateProgress(currentKills, 10);
    }

    private void OnQuestCompleted()
    {
        Debug.Log("任务完成！");
        _rewardDispatcher.Dispatch("Gold", 1000);
    }
}