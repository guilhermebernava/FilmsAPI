namespace FilmsAPI.Interfaces.Services;

public interface IServiceLocator
{
    T GetService<T>();
}
