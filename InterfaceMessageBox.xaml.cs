using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlGeo
{
    /// <summary>
    /// Interaction logic for InterfaceMessageBox.xaml
    /// </summary>
    public partial class InterfaceMessageBox : Window
    {
        private string messageBox;

        public InterfaceMessageBox(string messageBox)
        {
            InitializeComponent();
            this.messageBox = messageBox;
            this.messageBoxLabel.Content = messageBox;
        }

        private void buttonExitMessageBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
