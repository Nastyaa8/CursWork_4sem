namespace UndoRedoProject.Commands;

public interface ICommandAction
{
    void Execute();  // Выполнить команду
    void Undo();     // Отменить команду
}