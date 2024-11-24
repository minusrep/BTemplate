namespace Root.Tools
{
    public interface ILocator<T> 
    {
        U Get<U>() where U : T;
    }
}
