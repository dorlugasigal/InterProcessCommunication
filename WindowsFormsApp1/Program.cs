using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  static class Program
  {
    [STAThread]
    static void Main()
    {

      bool bln;
      Mutex mtx = new Mutex(false, "WindowsFormsApp1", out bln);
      if (bln == false)
      {
        clsManageComunication.TransmitDataToServer(string.Empty); 
      }
      else
      {
        clsManageComunication.GetServerWorker.RunWorkerAsync();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
      }
    }
  }
}
