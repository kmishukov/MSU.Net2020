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

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }

        public TextBoxViewModel(TextBox textbox) {
            _textbox = textbox;
            _textbox.TextChanged += TextChanged;

            _filepath = "";
            _filename = "";

            Application.Current.MainWindow.Closing += Closing;

            OpenCommand = new RelayCommand(_ => Open());
            SaveCommand = new RelayCommand(_ => Save());
            SaveAsCommand = new RelayCommand(_ => SaveAs());
            ExitCommand = new RelayCommand(_ => Exit());

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
                MessageBoxResult mbResult = MessageBox.Show("Сохранить изменения?", "Несохранённые изменения", MessageBoxButton.YesNoCancel);
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

        public void Closing(object sender, CancelEventArgs e) {
            if (_isEdited) {
                MessageBoxResult mbResult = MessageBox.Show("Остались несохранённые изменения, продолжить выход?", "Несохранённые изменения", MessageBoxButton.YesNo);
                if (mbResult == MessageBoxResult.No) {
                        e.Cancel = true;
                }
            }
        }

    }
}

  
