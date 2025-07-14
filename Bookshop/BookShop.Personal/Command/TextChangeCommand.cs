using System.Windows.Controls;

namespace BookShop.Personal.Command;

public class TextChangeCommand : IUndoableCommand
{
    private readonly TextBox _textBox;
    private readonly string _newText;
    private readonly string _oldText;

    public TextChangeCommand(TextBox textBox, string oldText, string newText)
    {
        _textBox = textBox;
        _newText = newText;
        _oldText = oldText;
    }

    public void Execute()
    {
        _textBox.Text = _newText;
    }

    public void Unexecute()
    {
        _textBox.Text = _oldText;
    }
}