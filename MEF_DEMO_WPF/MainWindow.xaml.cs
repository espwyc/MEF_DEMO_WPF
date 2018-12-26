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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_DEMO_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        [ImportMany]
        private IEnumerable<IPluginInterface.IPlugin> plugins;

        private CompositionContainer _container;

        public MainWindow()
        {
            InitializeComponent();
            InitPlugins();
        }

        private void InitPlugins()
        {
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "plugins\\"));
            catalog.Catalogs.Add(new DirectoryCatalog("plugins"));


            _container = new CompositionContainer(catalog);

            if (_container == null) return;

            //调用车间的ComposeParts把各个部件组合到一起
            try
            {
                this._container.ComposeParts(this);//这里只需要传入当前应用程序实例就可以了，其它部分会自动发现并组装
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (IPluginInterface.IPlugin plugin in plugins)
            {

                MenuItem item = new MenuItem();
                item.Header = plugin.Name;
                item.Click += (obj, arg) => { plugin.Open(); };

                plugin.TestEvent += (o, arg) => { log.Text += "\nplugin " + plugin.Name + ":" + arg; };
                plugin.UserControl += (o, arg) => { Gr0.Children.Add((UserControl)plugin.GetUserControl()); };
                menulist.Items.Add(item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (IPluginInterface.IPlugin plugin in plugins)
            {
                plugin.SendMsgtoPlugin(box.Text);
            }
        }
    }
}
