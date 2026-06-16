using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Threading;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    private BattleState currentState;
    private CancellationTokenSource cts = new();
    public int count = 0;
    public List<CombatUnit> combatUnits = new();
    public Queue<CombatUnit> turnOrder = new();
    [SerializeField]
    private CharacterProperty player;
    [SerializeField]
    private CharacterProperty enemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        BattleLoopAsync().Forget();
        if(player == null || enemy == null)
        {
            Debug.LogError("Player or Enemy is not assigned in the BattleManager.");
        }
    }
    async UniTask BattleStart()
    {
        InitTurnOrder();
        await UniTask.Delay(1000, cancellationToken: cts.Token);
    }
    async UniTask PlayerTurnAsync()
    {
        await UniTask.Delay(1000, cancellationToken: cts.Token);
    }
    async UniTask EnemyTurnAsync()
    {
        await UniTask.Delay(1000, cancellationToken: cts.Token);
    }
    async UniTask BattleRoundEndAsync()
    {
        await UniTask.Delay(1000, cancellationToken: cts.Token);
    }
    async UniTask BattleLoopAsync()
    {
        count++;
        currentState = BattleState.Start;
        if (currentState == BattleState.Start)
            await BattleStart();
        while (currentState != BattleState.End)
        {
            if (currentState == BattleState.PlayerTurn)
                await PlayerTurnAsync();
            else if (currentState == BattleState.EnemyTurn)
                await EnemyTurnAsync();
            else if (currentState == BattleState.ActionExecute)
                await BattleRoundEndAsync();
        }
        await BattleEnd();
    }
    async UniTask BattleEnd()
    {
        await UniTask.Delay(1000, cancellationToken: cts.Token);
    }
    public void ChangeState(int newState)
    {
        currentState = (BattleState)newState;
    }
     private void OnDestroy()
     {
        cts.Cancel();
        cts.Dispose();
        count = 0;
        currentState = BattleState.Start;
     }
    public void InitTurnOrder()
    {
        turnOrder.Clear();
        var sortorder=combatUnits.OrderByDescending(combatUnits => combatUnits.property.speed);
        foreach (var unit in sortorder)
        {
            turnOrder.Enqueue(unit);
        }
    }

}
