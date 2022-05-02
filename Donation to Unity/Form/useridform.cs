using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donation_attack_into_VRC
{
    public partial class useridform : Form
    {
        public useridform()
        {
            InitializeComponent();
            //초기설정
            this.BackColor = ColorTranslator.FromHtml("#B5498A");
            panel6.BackColor = ColorTranslator.FromHtml("#B5498A");
        }

        //버튼클릭했을때의 함수 설정
        private void Linkopen_bt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vrchat.com/home");
        }

        //컨트롤 디자인 설정
        private void Linkopen_bt_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#F816A9");
            btn.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void Linkopen_bt_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = ColorTranslator.FromHtml("#000000");
        }
        
        //창을 움직이기 위한 설정
        bool TagMove;
        int MValX, MValY;
        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel6_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        private void exit_bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
