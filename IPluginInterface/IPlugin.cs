using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPluginInterface
{
    public delegate void TestEventHandler(object sender, string e);
    public delegate void UserControlEvent(object sender, string e);

    public interface IPlugin
    {
        void Open();
        void Close();

        void SendMsgtoPlugin(string msg);
        string Name { get; }

        object GetUserControl();
        event TestEventHandler TestEvent;
        event UserControlEvent UserControl;
    }
}
