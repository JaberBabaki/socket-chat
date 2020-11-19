using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Threading;
using System.IO;
using System.Messaging.Design;
using ClientChat.Properties;

namespace ClientChat
{
    public partial class frmMain : Form
    {
        Socket SClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ChatRenjer";
        public string strPath = "";
        bool blnSendFile = false;
        private string message = "";
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

        private void btn()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    int count = pnlShowMessage.Controls.OfType<Button>().ToList().Count;
                    Button btn = new Button();
                    btn.Text = message;
                    btn.Name = "btnRec" + (count + 1);
                    btn.BackColor = Color.Aqua;
                    btn.Location = new Point(86, 14 * count + 1);
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackColor = Color.Transparent;
                    btn.TextAlign = ContentAlignment.MiddleRight;
                    btn.Size = new Size(150, 80);
                    btn.BackgroundImage = Resources.left_02;

                    pnlShowMessage.Controls.Add(btn);




                    PictureBox pic = new PictureBox();
                    pic.Text = txtMessage.Text;
                    pic.Name = "picRec" + (count + 1);
                    pic.BackColor = Color.Aqua;
                    pic.Location = new Point(6, 14 * count + 1);
                    pic.BackgroundImageLayout = ImageLayout.Stretch;
                    pic.BackColor = Color.Transparent;
                    pic.Size = new Size(80, 80);
                    pic.BackgroundImage = Resources.left_01;
                    pnlShowMessage.Controls.Add(pic);







                    int count2 = pnlShowMessage.Controls.OfType<Button>().ToList().Count;
                    Button btn2 = new Button();

                    btn2.Name = "btn2" + (count + 1);
                    btn2.BackColor = Color.Aqua;
                    btn2.Location = new Point(330, 14 * count + 1);
                    btn2.FlatAppearance.BorderSize = 0;
                    btn2.FlatStyle = FlatStyle.Flat;
                    btn2.BackgroundImageLayout = ImageLayout.Stretch;
                    btn2.BackColor = Color.Transparent;
                    btn2.TextAlign = ContentAlignment.MiddleRight;
                    btn2.Size = new Size(150, 80);


                    pnlShowMessage.Controls.Add(btn2);




                    PictureBox pic2 = new PictureBox();

                    pic2.Name = "pic2" + (count + 1);
                    pic2.BackColor = Color.Aqua;
                    pic2.Location = new Point(480, 14 * count + 1);
                    pic2.BackgroundImageLayout = ImageLayout.Stretch;
                    pic2.BackColor = Color.Transparent;
                    pic2.Size = new Size(80, 80);

                    pnlShowMessage.Controls.Add(pic2);







                });
            }
        }


        public void getMsg()
        {

            try
            {
                while (true)
                {
                    byte[] b = new byte[1024];
                    int R = SClient.Receive(b);
                    if (R > 0)
                    {
                        int id = 0;


                        message = Encoding.Unicode.GetString(b, 0, R);

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
            catch
            {
                ;
            }

        }


        public void getFile()
        {
            Socket sGetFile = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint IpEPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5051"));
            sGetFile.Bind(IpEPoint);
            sGetFile.Listen(1);
            while (true)
            {
                Socket SC = sGetFile.Accept();
                byte[] b = new byte[1024 * 50000];
                int RB = SC.Receive(b);
                int FileNamelen = BitConverter.ToInt32(b, 0);
                string NamFile = Encoding.ASCII.GetString(b, 4, FileNamelen);
                string strType = Path.GetExtension(FilePath.Trim() + "\\" + NamFile);
                if (OtherFile.Contains(strType))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(FilePath.Trim() + "\\File\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (imagesTypes.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(FilePath.Trim() + "\\Photo\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (sound.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(FilePath.Trim() + "\\Sound\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }
                if (mediaExtensions.Contains(strType.ToUpper()))
                {
                    BinaryWriter Bwriter = new BinaryWriter(File.Open(FilePath.Trim() + "\\Video\\" + NamFile, FileMode.Append));
                    Bwriter.Write(b, 4 + FileNamelen, RB - 4 - FileNamelen);
                    Bwriter.Close();
                }

            }
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
                IPEndPoint IpEPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5052"));
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
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint IpServe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("5050"));
            try
            {
                SClient.Connect(IpServe);

                Thread tr = new Thread(new ThreadStart(getMsg));
                tr.Start();


                Thread trstate = new Thread(new ThreadStart(SendState));
                trstate.Start();


                Thread trgetsate = new Thread(new ThreadStart(getState));
                trgetsate.Start();


                if (SClient != null)
                    lblStat.Text = "آنلاین";
                if (SClient == null)
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
            catch
            {

            }
        }

        private void getState()
        {
            try
            {


                Socket sGetState = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint IpEPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("456"));
                sGetState.Bind(IpEPoint);
                sGetState.Listen(1);
                while (true)
                {
                    Socket SC = sGetState.Accept();
                    byte[] b = new byte[1024];
                    int RB = SC.Receive(b);
                    string state = Encoding.Unicode.GetString(b, 0, RB);
                    if (state != null || state != "" || state == "online")
                    {
                        lblStat.Text = "آنلاین";
                    }
                    if (state == null || state == "" || state != "online")
                    {
                        lblStat.Text = "آفلاین";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SendState()
        {
            try
            {



            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {

            if (blnSendFile == true)
            {
                SendFile(strPath);
            }
            else
            {
                byte[] barray = new byte[1024];
                barray = Encoding.Unicode.GetBytes(txtMessage.Text);
                SClient.Send(barray);


                MessageBoxe msg = new MessageBoxe();
                msg.RTL = true;
                msg.Messagetext = txtMessage.Text;
                msg.BackgroundImage = Resources.bgnsg;
                pnlShowMessage.Controls.Add(msg);



                //int count = pnlShowMessage.Controls.OfType<Button>().ToList().Count;
                //Button btn = new Button();
                //btn.Text = txtMessage.Text;
                //btn.Name = "btn" + (count + 1);
                //btn.BackColor = Color.Aqua;
                //btn.Location = new Point(330, 84 * count + 1);
                //btn.FlatAppearance.BorderSize = 0;
                //btn.FlatStyle = FlatStyle.Flat;
                //btn.BackgroundImageLayout = ImageLayout.Stretch;
                //btn.BackColor = Color.Transparent;
                //btn.TextAlign = ContentAlignment.MiddleRight;
                //btn.Size = new Size(150, 80);
                //btn.BackgroundImage = Resources.bgnsg;

                //pnlShowMessage.Controls.Add(btn);




                //PictureBox pic = new PictureBox();
                //pic.Text = txtMessage.Text;
                //pic.Name = "pic" + (count + 1);
                //pic.BackColor = Color.Aqua;
                //pic.Location = new Point(480, 84 * count + 1);
                //pic.BackgroundImageLayout = ImageLayout.Stretch;
                //pic.BackColor = Color.Transparent;
                //pic.Size = new Size(80, 80);
                //pic.BackgroundImage = Resources.avtr;
                //pnlShowMessage.Controls.Add(pic);



                //int count2 = pnlShowMessage.Controls.OfType<Button>().ToList().Count;
                //Button btn2 = new Button();

                //btn2.Name = "btn2" + (count + 1);
                //btn2.BackColor = Color.Aqua;
                //btn2.Location = new Point(86, 84 * count + 1);
                //btn2.FlatAppearance.BorderSize = 0;
                //btn2.FlatStyle = FlatStyle.Flat;
                //btn2.BackgroundImageLayout = ImageLayout.Stretch;
                //btn2.BackColor = Color.Transparent;
                //btn2.TextAlign = ContentAlignment.MiddleRight;
                //btn2.Size = new Size(150, 80);
                //btn2.Enabled.Equals(false);
                //pnlShowMessage.Controls.Add(btn2);




                //PictureBox pic2 = new PictureBox();

                //pic2.Name = "pic2" + (count + 1);
                //pic2.BackColor = Color.Aqua;
                //pic2.Location = new Point(6, 84 * count + 1);
                //pic2.BackgroundImageLayout = ImageLayout.Stretch;
                //pic2.BackColor = Color.Transparent;
                //pic2.Size = new Size(80, 80);
                //pic2.Enabled.Equals(false);
                //pnlShowMessage.Controls.Add(pic2);

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




    }
}
