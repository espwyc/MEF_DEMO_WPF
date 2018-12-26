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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlplugin
{
    /// <summary>
    /// UserControlPlugin1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlPlugin1 : UserControl
    {
        public delegate void TestEventHandler(object sender, string e);
        public TestEventHandler TestEvent;

        public UserControlPlugin1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("usercontrol1 msgbox");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TestEvent(this, "event from usercontrol1");
        }
    }
}
