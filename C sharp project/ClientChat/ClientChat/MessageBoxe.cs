using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientChat.Properties;

namespace ClientChat
{
    public partial class MessageBoxe : UserControl
    {
        public MessageBoxe()
        {
            InitializeComponent();
        }


        public bool RTL
        {

            set
            {
                try
                {
                    if (value.Equals(true))
                    {

                        // picAvatar.Location=new Point(169,8);
                        picAvatar.BackgroundImage = Resources.left_01;
                        //btnMaddage.Location = new Point(7, 9);
                        btnMaddage.BackgroundImage = Resources.left_02;
                        pnlImage.Dock = DockStyle.Right;
                        panelMSG.Dock = DockStyle.Right;
                        btnMaddage.TextAlign = ContentAlignment.MiddleRight;
                    }
                    if (value.Equals(false))
                    {

                        // picAvatar.Location = new Point(3,5);
                        picAvatar.BackgroundImage = Resources.avtr;
                        //btnMaddage.Location = new Point(159, 64);
                        btnMaddage.BackgroundImage = Resources.bgnsg;
                        pnlImage.Dock = DockStyle.Left;
                        panelMSG.Dock = DockStyle.Left;
                        btnMaddage.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public string Messagetext
        {
            set { btnMaddage.Text = value; }
        }

    }
}
