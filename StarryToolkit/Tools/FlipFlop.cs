namespace StarryToolkits.Tools;

public enum ActionState
{
    A,
    B
}
public class FlipFlop
{
    private readonly object _lock=new();
    private Action _actionA = new Action(() => { });
    private Action _actionB = new Action(() => { });

    /// <summary>
    /// The flag of which action to be invoked
    /// </summary>
    public ActionState Flag { get; private set; } = ActionState.A;
    
    /// <summary>
    /// 触发
    /// Invoke the flip-flop
    /// </summary>
    /// <param name="isContinue">if isContinue is false, the flip-flop won't continue and will stay in the current state</param>
    public void Invoke(bool isContinue = true)
    {
        lock (_lock)
        {
            var k = Flag;
            if (Flag == ActionState.A)
                _actionA.Invoke();
            else if (Flag == ActionState.B)
                _actionB.Invoke();
            if(isContinue)
                Flag = (ActionState)(1-(int)Flag);
        }
        

    }
    
    /// <summary>
    /// Set the action when invoked
    /// </summary>
    /// <param name="state"></param>
    /// <param name="action"></param>
    public void SetAction(ActionState state,Action action)
    {
        switch (state)
        {
            case ActionState.A:
                _actionA=action;
                break;
            case ActionState.B:
                _actionB=action;
                break;
        }
    }

    public FlipFlop()
    {
        
    }
    public FlipFlop(Action actionA, Action actionB)
    {
        _actionA = actionA;
        _actionB = actionB;
    }
}