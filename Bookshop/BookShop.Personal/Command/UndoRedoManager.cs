namespace BookShop.Personal.Command;

public class UndoRedoManager
{
    private readonly Stack<IUndoableCommand> _undoStack = new();
    private readonly Stack<IUndoableCommand> _redoStack = new();

    /// <summary>
    /// Выполняет команду, добавляя её в стек отмены и очищая стек повтора.
    /// </summary>
    public void Execute(IUndoableCommand command)
    {
        //command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    /// <summary>
    /// Отменяет последнюю выполненную команду.
    /// </summary>
    public void Undo()
    {
        if (_undoStack.Count == 0) return;
        var command = _undoStack.Pop();
        command.Unexecute();
        _redoStack.Push(command);
    }

    /// <summary>
    /// Повторяет последнюю отменённую команду.
    /// </summary>
    public void Redo()
    {
        if (_redoStack.Count == 0) return;
        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
    }

    public bool CanUndo => _undoStack.Count != 0;
    public bool CanRedo => _redoStack.Count != 0;
}