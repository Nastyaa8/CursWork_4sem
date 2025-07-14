namespace BookShop.Personal.Command;

public interface IUndoableCommand
{
    /// <summary>
    /// Выполняет операцию.
    /// </summary>
    void Execute();

    /// <summary>
    /// Отменяет операцию.
    /// </summary>
    void Unexecute();
}