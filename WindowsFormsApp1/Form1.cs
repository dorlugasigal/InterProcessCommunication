using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    BackgroundWorker c;
    public Form1()
    {
      InitializeComponent();
      clsManageComunication.OnSendMessage += ClsManageComunication_OnSendMessage1;

    }

    private void ClsManageComunication_OnSendMessage1(string Message)
    {
      this.Invoke((System.Action)(() =>
      {
        label1.Text = Message;
      }));
    }

  
  }
}

