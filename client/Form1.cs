using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
  public partial class Form1 : Form
  {
    BackgroundWorker c;
    public Form1()
    {
      InitializeComponent();
      c = new BackgroundWorker();
      c.DoWork += C_DoWork;
      c.RunWorkerAsync();
    
    }
    private void C_DoWork(object sender, DoWorkEventArgs e)
    {
      client();
    }

    private void client()
    {
      var pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut, PipeOptions.Asynchronous);

      if (pipeClient.IsConnected != true) { pipeClient.Connect(); }

      StreamReader sr = new StreamReader(pipeClient);
      StreamWriter sw = new StreamWriter(pipeClient);

      string temp;
      temp = sr.ReadLine();

      if (temp == "Waiting")
      {
        try
        {
          int x = 1;
          while (true)
          {
            sw.WriteLine(x++.ToString());
            sw.Flush();
            pipeClient.Close(); 
          }
        }
        catch (Exception ex) { throw ex; }
      }
    }
  }
}
