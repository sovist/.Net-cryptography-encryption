using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using SPS;

namespace NetCryptography
{
    public partial class FormMain : Form
    {
        private string _inputFileName;
        private string _outputFileName;
        private bool _lockTBoxKeyOrIVTextChanged;
        private int _selectedAlgorithmIndex;
        private TextBox[] _textBoxKeys;
        private TextBox[] _textBoxIV;
        private Thread _threadCrypto;
        private Thread _threadCalcEntropyAfterEndCoding;
        private DateTime _dtStart;
        private Entropy _entropyInFile;
        private Entropy _entropyOutFile;
        private readonly Coder _coder = new Coder();
        private const string SaveFileExtension = ".txt";

        private static readonly SymmetricAlgorithm[] SymmetricAlgorithms = 
        {//порядок має значення, порядок такий як на формі
            new AesCryptoServiceProvider(),
            new RijndaelManaged(),
            new DESCryptoServiceProvider(),
            new TripleDESCryptoServiceProvider(),
            new RC2CryptoServiceProvider()         
        };

        public FormMain()
        {
            InitializeComponent();
            checkBoxIVTo0.Checked = true;
            radioButtonAES.Checked = true;
        }

        private SymmetricAlgorithm CurrentAlgorithm 
        {
            get { return SymmetricAlgorithms[_selectedAlgorithmIndex]; }
        }

        private string CurrentAlgotithmName
        {
            get
            {
                switch (_selectedAlgorithmIndex)
                {
                    case 0:
                        return "AES";
                    case 1:
                        return "Rijndael";
                    case 2:
                        return "DES";
                    case 3:
                        return "TripleDES";
                    case 4:
                        return "RC2";
                }
                return "AES";
            } 
            set
            {
                switch (value)
                {
                    case "AES":
                        _selectedAlgorithmIndex = 0;
                        break;
                    case "Rijndael":
                        _selectedAlgorithmIndex = 1;
                        break;
                    case "DES":
                        _selectedAlgorithmIndex = 2;
                        break;
                    case "TripleDES":
                        _selectedAlgorithmIndex = 3;
                        break;
                    case "RC2":
                        _selectedAlgorithmIndex = 4;
                        break;
                }
            }
        }

        private byte[] GetBytesKeyOnForm
        {
            get { return GetBytes(_textBoxKeys); }
        }

        private byte[] GetBytesIVOnForm
        {
            get { return GetBytes(_textBoxIV); }
        }

        private void buttonInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog{ Title = @"Оберіть файл який потрібно шифрувати\розшифрувати" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _inputFileName = textBoxInputFile.Text = openFileDialog.FileName;
                toolTip1.SetToolTip(textBoxInputFile, textBoxInputFile.Text);

                labelFileSize.Text = (new FileSizeInfo(_inputFileName)).ShortForm;

                linkLabelInFileEntropy.Text = @"Ентропія - обрахунок...";
                Application.DoEvents();

                _entropyInFile = new Entropy(_inputFileName);
                linkLabelInFileEntropy.Text = @"Ентропія - " + _entropyInFile.Value;
            }
        }

        private void buttonOutputFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(){Title = @"Введіть ім'я файлу"};
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _outputFileName = textBoxOutputFile.Text = saveFileDialog.FileName;
                toolTip1.SetToolTip(textBoxOutputFile, textBoxOutputFile.Text);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(!(sender is RadioButton))
                throw new Exception("object sender is not RadioButton");

            CurrentAlgotithmName = ((RadioButton) sender).Text;
            AddKeysLengthInComboBox();
            ShowKeyAndIV();
        }

        private bool _lockComboBoxKeyLengthSelectedIndexChanged = false;
        private void comboBoxKeyLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_lockComboBoxKeyLengthSelectedIndexChanged)
                return;
          
            try
            {
                CurrentAlgorithm.KeySize = int.Parse(comboBoxKeyLength.Text);
                CurrentAlgorithm.GenerateKey();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            ShowKeyAndIV();
        }

        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            CurrentAlgorithm.GenerateKey();
            ShowKeyAndIV();
        }

        private void buttonGenerateVI_Click(object sender, EventArgs e)
        {
            CurrentAlgorithm.GenerateIV();
            ShowKeyAndIV();
        }

        private void AddKeysLengthInComboBox()
        {
            _lockComboBoxKeyLengthSelectedIndexChanged = true;
            {
                comboBoxKeyLength.Items.Clear();
                KeySizes[] keySizeses = CurrentAlgorithm.LegalKeySizes;
                comboBoxKeyLength.Items.Add(keySizeses[0].MinSize);

                for (int i = keySizeses[0].MinSize + keySizeses[0].SkipSize;
                    i <= keySizeses[0].MaxSize && keySizeses[0].SkipSize != 0;
                    i += keySizeses[0].SkipSize)
                    comboBoxKeyLength.Items.Add(i);

                //comboBoxKeyLength.SelectedIndex = 0;//comboBoxKeyLength.Items.Count - 1;
            }
            _lockComboBoxKeyLengthSelectedIndexChanged = false;

            comboBoxKeyLength.SelectedIndex = 0;

            comboBoxKeyLength.Enabled = true;
            if (comboBoxKeyLength.Items.Count == 1)
                comboBoxKeyLength.Enabled = false;
        }

        private void ShowKeyAndIV()
        {
            for (int i = 0; i < groupBoxSetings.Controls.Count; i++)
                if (groupBoxSetings.Controls[i] is TextBox)
                    groupBoxSetings.Controls.Remove(groupBoxSetings.Controls[i--]);

            int textBoxKeysTop = labelKey.Top + labelKey.Height + 5;
            const int widthTextBox = 285;
            const int heightTextBox = 20;

            string[] key = (new Key(CurrentAlgorithm.Key)).GetMasStringKey();
            _textBoxKeys = new TextBox[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                groupBoxSetings.Controls.Add(_textBoxKeys[i] = new TextBox
                {
                    Location = new Point(10, textBoxKeysTop + i*heightTextBox),
                    Size = new Size(widthTextBox, heightTextBox),
                    Text = key[i],
                    MaxLength = key[i].Length,
                    Name = "textBoxKey"                
                });
                toolTip1.SetToolTip(_textBoxKeys[i], "Ключ в 16-му форматі");
                _textBoxKeys[i].TextChanged += textBoxKeyOrIV_TextChanged;
            }

            labelVI.Top = key.Length * _textBoxKeys[0].Height + _textBoxKeys[0].Top + 10;
            int textBoxVITop = labelVI.Top + labelVI.Height + 5;

            string[] VI = checkBoxIVTo0.Checked ? 
                (new Key(new byte[CurrentAlgorithm.IV.Length])).GetMasStringKey() : 
                (new Key(CurrentAlgorithm.IV)).GetMasStringKey();
            _textBoxIV = new TextBox[VI.Length];

            for (int i = 0; i < VI.Length; i++)
            {
                groupBoxSetings.Controls.Add(_textBoxIV[i] = new TextBox
                {
                    Location = new Point(10, textBoxVITop + i*heightTextBox),
                    Size = new Size(widthTextBox, heightTextBox),
                    Text = VI[i],
                    MaxLength = VI[i].Length,
                    Name = "textBoxVI",
                    ReadOnly = checkBoxIVTo0.Checked
                });
                toolTip1.SetToolTip(_textBoxIV[i], "Вектор Ініціалізації в 16-му форматі");
                _textBoxIV[i].TextChanged += textBoxKeyOrIV_TextChanged;
            }

            buttonGenerateKey.Top = _textBoxKeys[0].Top - 6;
            buttonGenerateKey.Left = _textBoxKeys[0].Left + widthTextBox + 5;
            buttonGenerateVI.Top = _textBoxIV[0].Top - 6;
            buttonGenerateVI.Left = _textBoxIV[0].Left + widthTextBox + 5;
            checkBoxIVTo0.Left = buttonGenerateVI.Left + buttonGenerateVI.Width + 5;
            checkBoxIVTo0.Top = _textBoxIV[0].Top + 2;
        }
       
        private void textBoxKeyOrIV_TextChanged(object sender, EventArgs e)
        {
            if (_lockTBoxKeyOrIVTextChanged)
                return;

            TextBox textBox = (TextBox) sender;
            string keyString = (textBox.Text.Replace("-", "")).Replace(" ", "");
            const int lenghtKeyBlock = 4;
            string newKey = !(lenghtKeyBlock < keyString.Length) ? keyString : Key.GetMasStringKey(keyString)[0];
            int ofset = (newKey.Length - textBox.TextLength);
            int selectionStart = ofset <= 1 ? textBox.SelectionStart : textBox.SelectionStart + ofset;
            bool formatErr = false;

            if (textBox.Text.Length > 0)
            {
                _lockTBoxKeyOrIVTextChanged = true;
                {
                    int index = StringIsHex(newKey, "- ");
                    if (index != -1)
                    {
                        MessageWindow.Show(
                            "Помилка вводу\n" +
                            "Вводити потрібно значення в 16-й системі \n" +
                            "цифри: [0-9]\n" +
                            "букви: [A-F]",
                            4,
                            textBox.Left + Left + groupBoxSetings.Left + 5*textBox.SelectionStart + 15,
                            textBox.Top + groupBoxSetings.Top + textBox.Height + Top + 31);

                        newKey = newKey.Replace(newKey[index].ToString(), "").Replace("-", "").Replace(" ", ""); 
                        textBox.Text = (newKey.Length > lenghtKeyBlock ? Key.GetMasStringKey(newKey)[0] : newKey).ToUpper();
                        textBox.SelectionStart = selectionStart - 1;
                        formatErr = true;
                    }
                }
                _lockTBoxKeyOrIVTextChanged = false;
            }

            if (!(lenghtKeyBlock <= keyString.Length) || formatErr)
                return;

            _lockTBoxKeyOrIVTextChanged = true;
            {
                textBox.Text = newKey.ToUpper();
                textBox.SelectionStart = selectionStart;
            }
            _lockTBoxKeyOrIVTextChanged = false;
        }

        private int StringIsHex(string line, string denySimbols)
        {
            for (int i = 0; i < line.Length; i++)
                if (!SimbolIsHex(line[i], denySimbols))
                    return i;
            return -1;
        }

        private bool SimbolIsHex(char simbol, string denySimbols)
        {
            simbol = (simbol.ToString()).ToUpper()[0];

            if (denySimbols.Any(t => t == simbol))
                return true;

            if ((simbol >= 'A' && simbol <= 'F') || (simbol >= '0' && simbol <= '9'))
                return true;

            return false;
        }

        private static byte[] GetBytes(IEnumerable<TextBox> textBox)
        {
            if (textBox == null)
                throw new Exception("textBox == null");

            string tempKey = textBox.Aggregate("", (current, t) => current + t.Text);

            return (new Key(tempKey)).GetByteKey();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentAlgorithm.Key = GetBytesKeyOnForm;
                CurrentAlgorithm.IV = GetBytesIVOnForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            StartCrypto(CurrentAlgorithm.CreateEncryptor(CurrentAlgorithm.Key, CurrentAlgorithm.IV));
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentAlgorithm.Key = GetBytesKeyOnForm;
                CurrentAlgorithm.IV = GetBytesIVOnForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            StartCrypto(CurrentAlgorithm.CreateDecryptor(CurrentAlgorithm.Key, CurrentAlgorithm.IV));
        }

        void StartCrypto(ICryptoTransform algorithmCryptoTransform)
        {
            if (_inputFileName == null)
            {
                MessageBox.Show(@"Вкажіть вхідний файл");
                return;
            }

            if (_outputFileName == null)
            {
                MessageBox.Show(@"Вкажіть вихідний файл");
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Visible = true;

            buttonEncrypt.Enabled = false;
            buttonDecrypt.Enabled = false;
            buttonStop.Enabled = true;

            _dtStart = DateTime.Now;
            (_threadCrypto = new Thread(() => _coder.EncryptData(_inputFileName, _outputFileName, algorithmCryptoTransform, update_pogressbar))).Start();
            (_threadCalcEntropyAfterEndCoding = new Thread(CalcEntropiAfterEndCoding)).Start();
        }

        private void CalcEntropiAfterEndCoding()
        {
            _threadCrypto.Join();

            Action showEntropi = () =>
            {
                progressBar1.Visible = false;
                linkLabelOutFileEntropy.Text = @"Ентропія - обрахунок...";
                Application.DoEvents();

                _entropyOutFile = new Entropy(_outputFileName);
                linkLabelOutFileEntropy.Text = @"Ентропія - " + _entropyOutFile.Value;

                buttonEncrypt.Enabled = true;
                buttonDecrypt.Enabled = true;
                buttonStop.Enabled = false;
            };
            Invoke(new MethodInvoker(() => showEntropi()));
        }

        public void update_pogressbar(int value)
        {
            Action<int> progress = (value1 =>
            {
                try
                {
                    labelTime.Text = @"Час розрахунку: " + (DateTime.Now - _dtStart).ToString().Substring(0, 12);
                }
                catch (ArgumentOutOfRangeException) { }

                progressBar1.Value = value1;
            });
            Invoke(new MethodInvoker(() => progress(value)));
        }

        private void toolStripMenuItemAboutProgram_Click(object sender, EventArgs e)
        {
            (new AboutProgramBox {Left = Left + 30, Top = Top + 40}).Show();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_threadCrypto != null)
                _threadCrypto.Abort();

            if(_threadCalcEntropyAfterEndCoding != null)
                _threadCalcEntropyAfterEndCoding.Abort();

            if(_coder != null)
                _coder.Dispose();

            buttonEncrypt.Enabled = true;
            buttonDecrypt.Enabled = true;
            buttonStop.Enabled = false;
            progressBar1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadCrypto != null)
                _threadCrypto.Abort();

            if (_threadCalcEntropyAfterEndCoding != null)
                _threadCalcEntropyAfterEndCoding.Abort();

            if (_coder != null)
                _coder.Dispose();
        }

        private void linkLabelInFileEntropy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_entropyInFile == null) 
                return;

            Clipboard.SetText(_entropyInFile.Value.ToString());
            MessageWindow.Show(String.Format("Текстове значення ентропії: {0} \n" +
                                             "зкопійовано до буферу обміну\n" +
                                             "тепер його можна \"вставити\" в іншій програмі", _entropyInFile.Value));
        }

        private void linkLabelOutFileEntropy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_entropyOutFile == null) 
                return;

            Clipboard.SetText(_entropyOutFile.Value.ToString());
            MessageWindow.Show(String.Format("Текстове значення ентропії: {0} \n" +
                                             "зкопійовано до буферу обміну\n" +
                                             "тепер його можна \"вставити\" в іншій програмі", _entropyOutFile.Value));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = @"Введіть ім'я файлу, для збередення параметрів",
                Filter = String.Format("Файли параметрів (*{0})|*{0}", SaveFileExtension)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, new[]
                    {
                        new Key(GetBytesKeyOnForm).GetStringKey(), //0 ключ
                        new Key(GetBytesIVOnForm).GetStringKey(),  //1 вектор Ініціалізації
                        CurrentAlgorithm.KeySize.ToString(),       //2 розмір ключа
                        CurrentAlgotithmName                       //3 Ім"я алгоритму
                    });

                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    if (fileInfo.Extension != SaveFileExtension)
                        File.Move(saveFileDialog.FileName, saveFileDialog.FileName + SaveFileExtension);
                }
                catch
                {
                    MessageBox.Show(@"Помилка при збереженні параметрів");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = @"Оберіть файл для відновлення параметрів",
                FileName = "*" + SaveFileExtension
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (new FileInfo(openFileDialog.FileName).Extension == SaveFileExtension)
                    {
                        string[] lines =  File.ReadAllLines(openFileDialog.FileName);
                         //0 ключ
                         //1 вектор Ініціалізації
                         //2 розмір ключа
                         //3 Ім"я алгоритму
                        foreach (Control control in groupBoxAlg.Controls)
                            if(control is RadioButton)
                                if (control.Text == lines[3])
                                    ((RadioButton) control).Checked = true;

                        comboBoxKeyLength.Text = lines[2];
                        CurrentAlgorithm.KeySize = int.Parse(lines[2]);

                        CurrentAlgorithm.IV = new Key(lines[1]).GetByteKey();
                        CurrentAlgorithm.Key = new Key(lines[0]).GetByteKey();
                        ShowKeyAndIV();
                    }
                    else
                        MessageBox.Show(@"Розширення файлу має бути *" + SaveFileExtension);
                }
                catch 
                {
                    MessageBox.Show(@"Помилка при відновленні параметрів");
                }
            }
        }

        private void checkBoxIVTo0_CheckedChanged(object sender, EventArgs e)
        {
            buttonGenerateVI.Enabled = !checkBoxIVTo0.Checked;
            ShowKeyAndIV();            
        }
    }
}
