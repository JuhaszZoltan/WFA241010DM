namespace WFA241010DM;

public class Feladat
{
    public int X { get; set; }
    public int Y { get; set; }
    public char OP { get; set; }
    public Label FLabel { get; set; }
    public TextBox FTextBox { get; set; }
    public bool IsCorrect =>
        OP == '+' && X + Y == int.Parse(FTextBox.Text)
        || OP == '-' && X - Y == int.Parse(FTextBox.Text);

    public Feladat(int x, int y, char op, Label fLabel, TextBox fTextBox)
    {
        X = x;
        Y = y;
        OP = op;
        FLabel = fLabel;
        FTextBox = fTextBox;

        FLabel.Text = $"{X} {OP} {Y} =";
        FLabel.ForeColor = Color.Black;
        fTextBox.Text = string.Empty;
    }
}
