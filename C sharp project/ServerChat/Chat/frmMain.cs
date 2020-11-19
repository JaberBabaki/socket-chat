using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Threading;
using Chat.Properties;


namespace Chat
{
    public partial class frmMain : Form
    {
        Socket socServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket socClient = null;

        public string strPath = "";
        bool blnSendFile = false;

        private int i = 0;
        private string message = "";

        string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer";

        public const string Png = "PNG Portable Network Graphics (*.png)|" + "*.png";
        public const string Jpg = "JPEG File Interchange Format (*.jpg *.jpeg *jfif)|" + "*.jpg;*.jpeg;*.jfif";
        public const string Bmp = "BMP Windows Bitmap (*.bmp)|" + "*.bmp";
        public const string Tif = "TIF Tagged Imaged File Format (*.tif *.tiff)|" + "*.tif;*.tiff";
        public const string Gif = "GIF Graphics Interchange Format (*.gif)|" + "*.gif";
        public const string AllImages = "Image file|" + "*.png; *.jpg; *.jpeg; *.jfif; *.bmp;*.tif; *.tiff; *.gif";

        List<string> imagesTypes = new List<string>();
        public void FilesFilters()
        {
            imagesTypes.Add(Png);
            imagesTypes.Add(Jpg);
            imagesTypes.Add(Bmp);
            imagesTypes.Add(Tif);
            imagesTypes.Add(Gif);



        }

        static string[] mediaExtensions = {
    
    ".AVI", ".MP4", //etc
     ".BIK", ".DAT", ".3GP", ".FLV",
      ".MPG", ".WMV"
};

        static string[] sound = {
    
    ".MP4", ".AMR", ".APE", ".FLAC", ".MP3", ".Mid ", ".MP3", //etc
    ".MPC", ".OGG", ".TTA", ".WAV", //etc
};



        static string[] OtherFile = {
    
    ".rar", ".zip", ".exe", ".php", ".xml", ".html ", ".doc", //etc
    ".ppt", ".docx", ".chtml", ".asp", //etc
    ".aspx", ".mmb", ".chtml", ".asp"
};




        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        public void StartServer()
        {
            try
            {
                IPEndPoint ipEndPointServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5050"));
                socServer.Bind(ipEndPointServer);
                socServer.Listen(1);
                socClient = socServer.Accept();
                Thread trGetMSG = new Thread(new ThreadStart(GetMessage));
                trGetMSG.Start();

                if (socClient != null)
                    lblStat.Text = "آنلاین";
                if (socClient == null)
                    lblStat.Text = "آفلاین";

            }
            catch { }
        }

        public void GetMessage()
        {
            try
            {

                while (true)
                {
                    
                    byte[] bArray = new byte[1024];
                    int intRec = socClient.Receive(bArray);
                  
                    if (intRec > 0)
                    {
                        i++;
                       // MessageBox.Show("Client: " + Encoding.Unicode.GetString(bArray, 0, intRec));

                        message=Encoding.Unicode.GetString(bArray, 0, intRec);
                        //Thread btntrd = new Thread(new ThreadStart(btn));
                        //btntrd.Start();
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke((MethodInvoker)delegate()
                            {
                                MessageBoxe msg = new MessageBoxe();
                                msg.RTL = false;
                                msg.Messagetext = message;
                                msg.BackgroundImage = Resources.left_02;
                                pnlShowMessage.Controls.Add(msg);



                            });
                        }

                    }
                }
            }
            catch { ;}
        }

     

        public void getFile()
        {
            Socket sGetFile = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint IpEPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5052"));
            sGetFile.Bind(IpEPoint);
            sGetFile.Listen(1);
            while (true)
            {
                Socket SC = sGetFile.Accept();
                byte[] b = new byte[1024 * 50000];
                int RB = SC.Receive(b);
                int FileNamelen = BitConverter.ToInt32(b, 0);
                string NamFile = Encoding.ASCII.GetString(b, 4, FileNamelen);
                string strType = Path.GetExtension(SavePath.Trim() + "\\" + NamFile);
                if (OtherFile.Contains(strType))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(SavePath.Trim() + "\\File\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (imagesTypes.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(SavePath.Trim() + "\\Photo\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (sound.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(SavePath.Trim() + "\\Sound\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (mediaExtensions.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(SavePath.Trim() + "\\Video\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }

            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            int b = 0;
            try
            {
                if (blnSendFile == true)
                {
                    SendFile(strPath);
                }
                else
                {

                    byte[] bArray = new byte[1024];
                    bArray = Encoding.Unicode.GetBytes(txtMessage.Text);
                    socClient.Send(bArray);


                    MessageBoxe msg = new MessageBoxe();
                    msg.RTL = true;
                    msg.Messagetext = txtMessage.Text;
                    msg.BackgroundImage = Resources.bgnsg;
                    pnlShowMessage.Controls.Add(msg);
  
                }
            }
            catch { }
        }

        private void CheckState()
        {
            StartServer();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (socClient != null)
                    socClient.Shutdown(SocketShutdown.Both);

                if (socServer != null)
                    socServer.Shutdown(SocketShutdown.Both);

                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
            catch (Exception ex)
            {

                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
            finally
            {
                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread trStart = new Thread(new ThreadStart(StartServer));
            trStart.Start();

             Thread trchech = new Thread(new ThreadStart(CheckState));
            trchech.Start();

          




            if (socClient != null)
                lblStat.Text = "آنلاین";
            if (socClient == null)
                lblStat.Text = "آفلاین";


            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer";
            string rootImg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer\Photo";
            string rootSound = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer\Sound";
            string rootVideo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer\Video";
            string rootFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer\File";

            // If directory does not exist, create it.

            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            if (!Directory.Exists(rootImg))
                Directory.CreateDirectory(rootImg);

            if (!Directory.Exists(rootSound))
                Directory.CreateDirectory(rootSound);

            if (!Directory.Exists(rootVideo))
                Directory.CreateDirectory(rootVideo);

            if (!Directory.Exists(rootFile))
                Directory.CreateDirectory(rootFile);


            Thread Trgetfile = new Thread(new ThreadStart(getFile));
            Trgetfile.Start();

        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }



        

        


        public void SendFile(string FileName)
        {

            FileInfo flinfo = new FileInfo(FileName);
            byte[] btFileName = Encoding.ASCII.GetBytes(flinfo.Name);
            byte[] btFileData = File.ReadAllBytes(FileName);
            byte[] FileNameLen = BitConverter.GetBytes(btFileName.Length);
            byte[] DataSend = new byte[4 + btFileName.Length + btFileData.Length];

            FileNameLen.CopyTo(DataSend, 0);
            btFileName.CopyTo(DataSend, 4);
            btFileData.CopyTo(DataSend, 4 + btFileName.Length);
            //-----------------------
            try
            {
                Socket SSendFile = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint IpEPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5051"));
                SSendFile.Connect(IpEPoint);
                SSendFile.Send(DataSend);
                SSendFile.Close();
                blnSendFile = false;
            }
            catch
            {
                ;
            }

        }

        private void btnAtachfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                strPath = op.FileName;
                blnSendFile = true;
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(null,null);
                txtMessage.Text=String.Empty;
            }
        }

       
    }
}
