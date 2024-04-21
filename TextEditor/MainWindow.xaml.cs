using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TextEditor;

public partial class MainWindow : Window
{
    string? _path;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click_Copy(object sender, RoutedEventArgs e)
    {
        RichTextBox.Copy();
    }

    private void Button_Click_SelectAll(object sender, RoutedEventArgs e)
    {
        RichTextBox.SelectAll();
    }

    private void Button_Click_Paste(object sender, RoutedEventArgs e)
    {
        RichTextBox.Paste();
    }

    private void Button_Click_Cut(object sender, RoutedEventArgs e)
    {
        RichTextBox.Cut();
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if ((textBox.ToString().Length - 31).Equals(0))
            MessageBox.Show("Input file name for autosave");
    }

    private void Button_Click_Save(object sender, RoutedEventArgs e)
    {

        if (!(textBox.ToString().Length - 31).Equals(0))
        {
            string text = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            if(!Directory.Exists("..\\..\\..\\Texts"))
                Directory.CreateDirectory("..\\..\\..\\Texts");

            File.WriteAllText(Path.Combine("..\\..\\..\\Texts", _path), text);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((textBox.ToString().Length - 31).Equals(0))
        {
            OpenFileDialog fileDialog = new();
            fileDialog.ShowDialog();
            string text = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            if (fileDialog.FileName.Length > 0)
                File.WriteAllText(fileDialog.FileName, text);
        }
        else
        {
            string text = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            if (!Directory.Exists("..\\..\\..\\Texts"))
                Directory.CreateDirectory("..\\..\\..\\Texts");

            File.WriteAllText(Path.Combine("..\\..\\..\\Texts", _path), text);
        }
    }

    private void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox? textBox = sender as TextBox;

        if (textBox is not null)
            _path = textBox.Text;
    }

    private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(textBox.ToString().Length - 31).Equals(0) && CheckBox.IsChecked is true)
        {
            string text = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            if (!Directory.Exists("..\\..\\..\\Texts"))
                Directory.CreateDirectory("..\\..\\..\\Texts");

            File.WriteAllText(Path.Combine("..\\..\\..\\Texts", _path), text);
        }
    }
}