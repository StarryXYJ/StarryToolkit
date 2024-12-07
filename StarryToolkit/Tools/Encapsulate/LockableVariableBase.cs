using StarryToolkits.Tools.Exception;

namespace StarryToolkits.Tools.Encapsulate;

public abstract class LockableVariableBase<T> : ModificationControlledVariable<T>
{
    private bool _isLocked=true;


    public LockableVariableBase()
    {
        CanModify = () => !IsLocked;
    }
    
    /// <summary>
    /// This constructor does not have affect in this class
    /// </summary>
    /// <param name="canModify"></param>
    public LockableVariableBase(Func<bool> canModify)
    {
        CanModify = () => !IsLocked;
    }

    public bool IsLocked
    {
        get => _isLocked;
        private set => _isLocked = value;
    }
}