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

        public string Name { get { return "window插件2"; } }

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
            return;
        }

        private void InitEvent()
        {
            if (mwd == null) return;

            mwd.TestEvent += delegate (object sender, string e) { TestEvent(sender, e); };
        }
    }
}
