using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

class QuickNoteForm : Form
{
    static readonly string NotesFile = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "QuickNote",
        "notas.txt"
    );

    private TextBox txtNota;
    private TextBox txtHistorial;
    private Button btnGuardar;
    private Button btnLimpiar;

    public QuickNoteForm()
    {
        this.Text = "QuickNote";
        this.Size = new Size(460, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Font = new Font("Segoe UI", 9.5f);

        Label lblNueva = new Label();
        lblNueva.Text = "Escribe una nota rápida:";
        lblNueva.Location = new Point(15, 15);
        lblNueva.AutoSize = true;

        txtNota = new TextBox();
        txtNota.Location = new Point(15, 38);
        txtNota.Size = new Size(315, 26);

        btnGuardar = new Button();
        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(340, 37);
        btnGuardar.Size = new Size(90, 28);
        btnGuardar.Click += BtnGuardar_Click;

        Label lblHistorial = new Label();
        lblHistorial.Text = "Notas guardadas (Documentos\\QuickNote\\notas.txt):";
        lblHistorial.Location = new Point(15, 80);
        lblHistorial.AutoSize = true;

        txtHistorial = new TextBox();
        txtHistorial.Location = new Point(15, 103);
        txtHistorial.Size = new Size(415, 205);
        txtHistorial.Multiline = true;
        txtHistorial.ReadOnly = true;
        txtHistorial.ScrollBars = ScrollBars.Vertical;
        txtHistorial.BackColor = Color.White;

        btnLimpiar = new Button();
        btnLimpiar.Text = "Borrar historial";
        btnLimpiar.Location = new Point(315, 318);
        btnLimpiar.Size = new Size(115, 28);
        btnLimpiar.Click += BtnLimpiar_Click;

        this.Controls.Add(lblNueva);
        this.Controls.Add(txtNota);
        this.Controls.Add(btnGuardar);
        this.Controls.Add(lblHistorial);
        this.Controls.Add(txtHistorial);
        this.Controls.Add(btnLimpiar);

        this.AcceptButton = btnGuardar;

        CargarNotas();
    }

    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        string texto = txtNota.Text.Trim();
        if (string.IsNullOrEmpty(texto))
        {
            MessageBox.Show("Escribe algo antes de guardar.", "QuickNote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string folder = Path.GetDirectoryName(NotesFile);
        if (!string.IsNullOrEmpty(folder))
            Directory.CreateDirectory(folder);

        string linea = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "] " + texto + Environment.NewLine;
        File.AppendAllText(NotesFile, linea);

        txtNota.Clear();
        txtNota.Focus();
        CargarNotas();
    }

    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
        if (!File.Exists(NotesFile))
            return;

        DialogResult r = MessageBox.Show("¿Seguro que deseas borrar todas las notas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (r == DialogResult.Yes)
        {
            File.Delete(NotesFile);
            CargarNotas();
        }
    }

    private void CargarNotas()
    {
        if (File.Exists(NotesFile))
            txtHistorial.Text = File.ReadAllText(NotesFile);
        else
            txtHistorial.Text = "(Aún no hay notas guardadas)";
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new QuickNoteForm());
    }
}