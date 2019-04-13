using UnityEngine;

public class EnemyState
{
    protected EnemyController enemy;
    public EnemyState(EnemyController e) { enemy = e; }
    public virtual float GetStateTime() { return 0; }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void End() { }
}

public class RandomState : EnemyState
{
    public RandomState(EnemyController e) :base(e) { }
    public override float GetStateTime() { return Random.Range(10,15); }
    public override void Update() { Debug.Log(1); enemy.RandomMove(); }
}

public class ApproachState : EnemyState
{
    public ApproachState(EnemyController e) :base(e) { }
    public override float GetStateTime() { return Random.Range(3, 5); }
    public override void Update() { Debug.Log(2); enemy.Approach(); }
}

public class ShootState : EnemyState
{
    public ShootState(EnemyController e) :base(e) { }
    public override float GetStateTime() { return Random.Range(4, 7); }
    public override void Start() { enemy.StartShooting(); }
    public override void Update() { Debug.Log(3); enemy.Approach(); }
    public override void End() { enemy.StopShooting(); }
}

public class EnemySM : MonoBehaviour
{
    static public float viewRange = 50;
    static public float stopRange = 8f;

    public EnemyController enemy;

    EnemyState[] states;
    EnemyState curState;

    void Start()
    {
        states = new EnemyState[3];
        states[0] = new RandomState(enemy);
        states[1] = new ApproachState(enemy);
        states[2] = new ShootState(enemy);
        curState = states[0];
        ChangeState();
    }

    private void Update()
    {
        curState.Update();
    }

    void ChangeState()
    {
        curState.End();

        float distance = (PlayerController.Position - transform.position).magnitude;
        if (distance < stopRange)
            curState = states[0];
        else curState = states[Random.Range(0, states.Length)];
        
        curState.Start();
        Invoke("ChangeState", curState.GetStateTime());
    }
}
