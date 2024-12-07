using StarryToolkits.Tools.Exception;

namespace StarryToolkits.Tools.Encapsulate;

public class ModificationControlledVariable<T> : EncapsulateVarious<T>
{
    /// <summary>
    /// Return if the value could be modify
    /// </summary>
    protected Func<bool> CanModify = () => false;
    public Action? OnModifyFailed = null;
    
    public ModificationControlledVariable()
    {
        
    }
    
    public ModificationControlledVariable(Func<bool> canModify)
    {
        CanModify = canModify;
    }

    public void Set(T newValue)
    {
        if (CanModify())
        {
            Value = newValue;
        }
        else if(OnModifyFailed!=null)
        {
            OnModifyFailed();
        }
        else
        {
            throw new ModifyFailedException(this.ToString());
        }
    }

    public bool TrySet(T newValue)
    {
        try
        {
            Set(newValue);
        }
        catch (ModifyFailedException)
        {
            return false;
        }
        catch
        {
            throw;
        }

        return true;
    }
}