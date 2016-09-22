 
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms; 
namespace FileSyncServer
{
  public class settings {
        public string FileSaveDirectory { set; get; }
    }
    class MyApplicationContext : ApplicationContext
    {
        //Component declarations
        private static NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem CloseMenuItem;
  
    
        public MyApplicationContext()
        {
         
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            InitializeComponent();
            TrayIcon.Visible = true;
        }

        private void InitializeComponent()
        {

            
            SN.Controllers.Current.Add(new theController()); 
            new Thread(() => {
                SN.Listener ls = new SN.Listener(utility.GetLocalIPAddress(), 581);
                ls.RsaLength = int.Parse(utility.ini.Read("basic", "rsa_key_length")); 
                ls.Start();
            }).Start();
           // MessageBox.Show(utility.GetLocalIPAddress());

            TrayIcon = new NotifyIcon();

            TrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            TrayIcon.BalloonTipText =
              "I noticed that you double-clicked me! What can I do for you?";
            TrayIcon.BalloonTipTitle = "You called Master?";
            TrayIcon.Text = "File Sync Server";


            //The icon is added to the project resources.
            //Here I assume that the name of the file is 'TrayIcon.ico'
            TrayIcon.Icon = SNAPI_SERVER.Properties.Resources.Esxxi_me_Hdrv_Blue_Sync_W;

            //Optional - handle doubleclicks on the icon:
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;

            //Optional - Add a context menu to the TrayIcon:
            TrayIconContextMenu = new ContextMenuStrip();
            CloseMenuItem = new ToolStripMenuItem(); 
            TrayIconContextMenu.SuspendLayout();

            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {  this.CloseMenuItem});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new Size(152, 22);
            this.CloseMenuItem.Text = "Close";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);
            
            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
   

        } 
      
       
        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            TrayIcon.Visible = false;
        }
 

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close SN server?",
                    "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
         
        }

    }
}
