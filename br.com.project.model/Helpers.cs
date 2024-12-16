using System.Windows.Forms;

public class Helpers
{
    // Método para limpar formulário
    public void LimparTela(Control container)
    {
        foreach (Control control in container.Controls)
        {
            // Verifica o tipo do controle e limpa o conteúdo conforme necessário
            switch (control)
            {
                case TextBox textBox:
                    textBox.Clear();
                    break;

                case MaskedTextBox maskedTextBox:
                    maskedTextBox.Clear();
                    break;

                case ComboBox comboBox:
                    comboBox.SelectedIndex = -1; // Define como não selecionado
                    break;

                case TabPage tabPage:
                    LimparTela(tabPage); // Chamada recursiva para os controles dentro do TabPage
                    break;

                default:
                    // Caso o controle tenha filhos, aplica recursão
                    if (control.HasChildren)
                    {
                        LimparTela(control);
                    }
                    break;
            }
        }
    }
}
