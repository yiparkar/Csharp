using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() => ChangeText() );
        }

        private void ChangeText()
        {
            Thread.Sleep(2000);
            updateText("New World");
        }

        private void updateText(string v)
        {
            //txtMessage.Text = v; //System.InvalidOperationException: 
                                 //'The calling thread cannot access this object 
                                  //because a different thread owns it.'
            Dispatcher.Invoke(() => txtMessage.Text = v);
        }
    }
}
