namespace Shop.Api.Logger;

public interface IDefaultLogger
{
    public void Info(string message);

    public void Error(string message);

    public void Debug(string message);
}
