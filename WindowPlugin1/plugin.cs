using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPluginInterface;
using System.ComponentModel.Composition;

namespace WindowPlugin1
{
    [Export(typeof(IPluginInterface.IPlugin))]
    public class WindowPlugin1 : IPluginInterface.IPlugin
    {
        private MainWindow mwd;

        public WindowPlugin1()
        {
            mwd = new MainWindow();
            InitEvent();
        }

        public string Name { get { return "window插件1"; } }

        public event TestEventHandler TestEvent;
        public event UserControlEvent UserControl;

        public void Close()
        {
            if (mwd == null) return;
            mwd.Close();
        }

        public object GetUserControl()
        {
            return null;
        }

        public void Open()
        {          
            mwd.Show();
        }

        public void SendMsgtoPlugin(string msg)
        {

            mwd.msglab.Content = "receive from host: " + msg;
        }

        private void InitEvent()
        {

            mwd.TestEvent += delegate (object sender, string e) { TestEvent(sender, e); };
        }
    }
}
