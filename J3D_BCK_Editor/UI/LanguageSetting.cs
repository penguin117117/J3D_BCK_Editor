using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J3D_BCK_Editor.UI
{
    public partial class LanguageSettingForm : Form
    {
        public readonly Dictionary<string, int> Language = new Dictionary<string, int>()
        {
            { "日本語" , 0 },
            { "English", 1 }
        };

        public LanguageSettingForm()
        {
            InitializeComponent();

            foreach (var lang in Language) 
            {
                LanguageComboBox.Items.Add(lang.Key);
            }

            LanguageComboBox.SelectedIndex = Language[Properties.Settings.Default.language];
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.language = LanguageComboBox.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
