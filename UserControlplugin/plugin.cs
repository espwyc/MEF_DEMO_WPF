using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPluginInterface;

namespace UserControlplugin
{
    [Export(typeof(IPluginInterface.IPlugin))]
    public class plugin : IPluginInterface.IPlugin
    {
        UserControlPlugin1 uc;

        public plugin()
        {
            uc = new UserControlPlugin1();
            uc.TestEvent += (o, e) => { TestEvent(this, e); };
        }

        public string Name {get{return "usercontrol1";} }

        public event TestEventHandler TestEvent;
        public event UserControlEvent UserControl;

        public void Close()
        {
            uc.Visibility = System.Windows.Visibility.Hidden;
        }

        public object GetUserControl()
        {
            return uc;
        }

        public void Open()
        {
            UserControl(this, null);
            uc.Visibility = System.Windows.Visibility.Visible;
        }

        public void SendMsgtoPlugin(string msg)
        {
            uc.lab.Content = msg;
        }
    }
}
