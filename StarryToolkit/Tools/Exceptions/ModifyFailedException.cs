namespace StarryToolkits.Tools.Exception;

public class ModifyFailedException : System.Exception
{
    public ModifyFailedException(string? message):base(message:"The modification of "+message??"a value"+" is failed")
    {
        
    }
    public ModifyFailedException():base(message:"The modification is failed")
    {
        
    }
}