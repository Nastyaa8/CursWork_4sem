using UndoRedoProject.Commands;

namespace UndoRedoProject.CommandManager;

public class CommandUIManager
{
    public Stack<ICommandAction> UndoStack { get; } = new();
    public Stack<ICommandAction> RedoStack { get; } = new();

    public void ExecuteCommand(ICommandAction command)
    {
        command.Execute();
        UndoStack.Push(command);
        RedoStack.Clear(); // Очистка redo после нового действия
    }

    public void Undo()
    {
        if (UndoStack.Count > 0)
        {
            var command = UndoStack.Pop();
            command.Undo();
            RedoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (RedoStack.Count > 0)
        {
            var command = RedoStack.Pop();
            command.Execute();
            UndoStack.Push(command);
        }
    }
}