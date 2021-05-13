using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Task15 {
    class TextBoxViewModel {

        TextBox _textbox { get; set; }
        string _filetext { get; set; }
        string _filepath { get; set; }
        string _filename { get; set; }
        bool _isEdited = false;

        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand TextWrapCommand { get; private set; }
        public RelayCommand SpellCheckCommand { get; private set; }
        public RelayCommand UndoCommand { get; private set; }
        public RelayCommand RedoCommand { get; private set; }
        public RelayCommand CopyCommand { get; private set; }
        public RelayCommand CutCommand { get; private set; }
        public RelayCommand PasteCommand { get; private set; }
        public RelayCommand SelectAllCommand { get; private set; }
        public RelayCommand AboutCommand { get; private set; }

        public TextBoxViewModel(TextBox textbox) {
            _textbox = textbox;
            _textbox.TextChanged += TextChanged;

            _filepath = "";
            _filename = "";
            _filetext = "";

            Application.Current.MainWindow.Closing += Closing;

            OpenCommand = new RelayCommand(_ => Open());
            SaveCommand = new RelayCommand(_ => Save());
            SaveAsCommand = new RelayCommand(_ => SaveAs());
            ExitCommand = new RelayCommand(_ => Exit());
            TextWrapCommand = new RelayCommand(_ => ChangeTextWrap());
            SpellCheckCommand = new RelayCommand(_ => ChangeSpellCheck());
            UndoCommand = new RelayCommand(_ => Undo());
            RedoCommand = new RelayCommand(_ => Redo());
            CopyCommand = new RelayCommand(_ => Copy());
            CutCommand = new RelayCommand(_ => Cut());
            PasteCommand = new RelayCommand(_ => Paste());
            SelectAllCommand = new RelayCommand(_ => SelectAll(), _ => _filetext != "");
            AboutCommand = new RelayCommand(_ => About());
        }

        public void TextChanged(object sender, EventArgs e) {
            if (_filetext == _textbox.Text) return;
            _filetext = _textbox.Text;
            _isEdited = true;
        }

        private void Open() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*|Text Files (*.txt)|*.txt"; ;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true) {
                _filepath = openFileDialog.FileName;
                _filename = openFileDialog.SafeFileName;
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader file = new StreamReader(fileStream)) {
                    _filetext = file.ReadToEnd();
                }
                _isEdited = false;
                _textbox.Text = _filetext;
            }
        }

        private void Save() {
            if (_filepath != "") {
                using (StreamWriter file = new StreamWriter(_filepath)) {
                    file.Write(_textbox.Text);
                }
                _isEdited = false;
            } else {
                SaveAs();
            }
        }

        private void SaveAs() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = (_filename == "") ? "text" : _filename;
            saveFileDialog.Filter = "All files (*.*)|*.*|Text Files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true) {
                _filepath = saveFileDialog.FileName;
                _filename = saveFileDialog.SafeFileName;
                using (StreamWriter file = new StreamWriter(_filepath)) {
                    file.Write(_textbox.Text);
                }
                _isEdited = false;
            }            
        }

        private void Exit() {
            if (_isEdited) {
                MessageBoxResult mbResult = MessageBox.Show("Сохранить изменения?", "Внимание", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (mbResult) {
                    case MessageBoxResult.Yes:
                        Save();
                        _isEdited = false;
                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            } else {
                Application.Current.Shutdown();
            }
        }

        private void Closing(object sender, CancelEventArgs e) {
            if (_isEdited) {
                MessageBoxResult mbResult = MessageBox.Show("Остались несохранённые изменения,\nВы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mbResult == MessageBoxResult.No) {
                        e.Cancel = true;
                }
            }
        }

        private void ChangeTextWrap() {
            _textbox.TextWrapping = _textbox.TextWrapping == TextWrapping.NoWrap ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void ChangeSpellCheck() {
            bool isEnabled = SpellCheck.GetIsEnabled(_textbox);
            SpellCheck.SetIsEnabled(_textbox, !isEnabled);
        }

        private void Undo() {
            _textbox.Undo();
        }
        private void Redo() {
            _textbox.Redo();
        }
        private void Copy() {
            _textbox.Copy();
        }
        private void Cut() {
            _textbox.Cut();
        }
        private void Paste() {
            _textbox.Paste();
        }
        private void SelectAll() {
            _textbox.SelectAll();
        }

        private void About() {
            MessageBox.Show("Notepad Application\nby Mishukov Konstantin, 2021","About Notepad");
        }
    }
}

  
