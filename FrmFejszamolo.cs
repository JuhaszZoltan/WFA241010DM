namespace WFA241010DM;

public partial class FrmFejszamolo : Form
{
    private Label[] lbls;
    private TextBox[] tbs;

    private static Random rnd = new();
    private List<Feladat> feladatok = [];

    public FrmFejszamolo()
    {
        InitializeComponent();

        lbls = [lblF1, lblF2, lblF3, lblF4, lblF5];
        tbs = [tbF1, tbF2, tbF3, tbF4, tbF5];

        btnBezaras.Click += BtnBezaras_Click;
        btnUjFeladatok.Click += BtnUjFeladatok_Click;
        btnEllenorzes.Click += BtnEllenorzes_Click;

        btnUjFeladatok.Select();
    }

    private void BtnEllenorzes_Click(object? sender, EventArgs e)
    {
        if (tbs.Any(t => !int.TryParse(t.Text, out _)))
        {
            lblMsg.Text = "Nem minden beviteli mezõ formátuma megfelelõ.\n" +
                "Ellenõrizd és próbáld újra!";
            return;
        }

        foreach (var f in feladatok)
            f.FLabel.ForeColor = f.IsCorrect
                ? Color.Green
                : Color.Red;
        
        lblMsg.Text = $"{feladatok.Count(f => f.IsCorrect)} helyes megoldásod van!";

        btnEllenorzes.Enabled = false;
        btnUjFeladatok.Enabled = true;
    }

    private void BtnUjFeladatok_Click(object? sender, EventArgs e)
    {
        foreach (var tb in tbs) tb.Enabled = true;

        for (int i = 0; i < 5; i++)
            feladatok.Add(new(
                x: rnd.Next(10, 100),
                y: rnd.Next(10, 100),
                op: rnd.Next(100) < 50 ? '+' : '-',
                fLabel: lbls[i],
                fTextBox: tbs[i]));

        lblMsg.Text = "töltsd ki a bal oldali szövegdobozokat, ha végeztél kattints az 'ellenõrzés'-re!";

        btnEllenorzes.Enabled = true;
    }

    private void BtnBezaras_Click(object? sender, EventArgs e) => Application.Exit();
}

