using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donation;

namespace Donation_attack_into_VRC
{   
    public partial class addparameterform : Form
    {
        public addparameterform()
        {
            InitializeComponent();
        }

        /*
        1. Mainform에서 사용하기위한 프로퍼티 설정
        2. 상황에 따른 콤보박스 아이템설정
        3. userid 도움말창 설정
        4. addparameterform 컨트롤 설정
        5. 창 초기화를 위한 함수설정
        6. 창을 움직이기 위한 설정
        */

        //1. Mainform에서 사용하기위한 프로퍼티 설정
        public string donationmin
        { get; set; }
        public string donationmax
        { get; set; }
        public string parametername
        { get; set; }
        public string parametersendtype
        { get; set; }
        public string value1
        { get; set; }
        public string value2
        { get; set; }
        public string value3
        { get; set; }
        public string parametertype
        { get; set; }

        //2. 상황에 따른 콤보박스 아이템설정
        private void parameter_combo_SelectedIndexChanged(object sender, EventArgs e)
        {   
            try
            {
                var a = para[avartname_combo.SelectedItem.ToString()];
                parametertype_text.Text = a[parameter_combo.SelectedIndex][1];
                if (parametertype_text.Text == "Bool")
                {
                    setparameter_combo.Items.Clear();
                    setparameter_combo.Items.Add("값변경");
                    setparameter_combo.Items.Add("값변경후복귀");
                }
                else if (parametertype_text.Text == "Int")
                {
                    setparameter_combo.Items.Clear();
                    setparameter_combo.Items.Add("랜덤");
                    setparameter_combo.Items.Add("값변경");
                    setparameter_combo.Items.Add("값변경후복귀");
                }
                else if (parameter_combo.SelectedItem == null)
                {

                }
            }
            catch
            {
                
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (donation_combo.SelectedItem == null)
                {

                }
                else if(donation_combo.SelectedIndex == 0)
                {
                    donationmin_text.Visible = true;
                    donationmax_text.Visible = true;
                    donation_label.Visible = true;
                    donationsame_text.Visible = false;
                }
                else if (donation_combo.SelectedIndex == 1)
                {
                    donationmin_text.Visible = false;
                    donationmax_text.Visible = false;
                    donation_label.Visible = false;
                    donationsame_text.Visible = true;
                }
            }
            catch
            {
                
            }
            
        }
        private void setparameter_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (setparameter_combo.SelectedItem == null)
                {
                    
                }
                else if(setparameter_combo.SelectedItem.ToString() == "랜덤")
                {
                    randommax_text.Visible = true;
                    randommin_text.Visible = true;
                    random_lable.Visible = true;
                    settime1st_text.Visible = false;
                    settime2nd_text.Visible = false;
                    settimetime_text.Visible = false;
                    settime_lable.Visible = false;
                    set_text.Visible = false;
                }
                else if (setparameter_combo.SelectedItem.ToString() == "값변경")
                {
                    randommax_text.Visible = false;
                    randommin_text.Visible = false;
                    random_lable.Visible = false;
                    settime1st_text.Visible = false;
                    settime2nd_text.Visible = false;
                    settimetime_text.Visible = false;
                    settime_lable.Visible = false;
                    set_text.Visible = true;
                }
                else if (setparameter_combo.SelectedItem.ToString() == "값변경후복귀")
                {
                    randommax_text.Visible = false;
                    randommin_text.Visible = false;
                    random_lable.Visible = false;
                    settime1st_text.Visible = true;
                    settime2nd_text.Visible = true;
                    settimetime_text.Visible = true;
                    settime_lable.Visible = true;
                    set_text.Visible = false;
                }

            }
            catch
            {
                
            }
            
        }
        private void avartname_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                if (avartname_combo.SelectedItem == null)
                {
                    
                }
                else
                {
                    parameter_combo.Items.Clear();
                    var a = para[avartname_combo.SelectedItem.ToString()];
                    for (int j = 0; j < a.Count; j++)
                    {
                        parameter_combo.Items.Add(a[j][0]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("오류가 발생하였습니다.\n창초기화버튼을 눌러주세요!");
            }
        }

        //3. userid 도움말창 설정
        useridform dialog2 = new useridform();
        private void whatisuserid_bt_Click(object sender, EventArgs e)
        {
            dialog2.StartPosition = FormStartPosition.Manual;
            dialog2.Location = new Point(this.Location.X + 10, this.Location.Y + 50);
            dialog2.ShowDialog();
        }

        //4. addparameterform 컨트롤 설정
        private void exit_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void addparameter_bt_Click(object sender, EventArgs e)
        {
            if(checkdata())
            {
                senddata();
            }           
        }
        private void reset_bt_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        private void userid_text_MouseUp(object sender, MouseEventArgs e)
        {
            if (userid_text.Text == "usr_********-****-****-****-************")
            {
                userid_text.Clear();
            }
            else
            {
            }
            opencompleted_label.Text = "";
        }      
        private void exit_bt_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#F816A9");
            btn.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }
        private void exit_bt_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        //5. 창 초기화를 위한 함수설정
        private void cleartext()
        {
            parameter_combo.Items.Clear();
            avartname_combo.Items.Clear();
            userid_text.Text = "usr_********-****-****-****-************";
            parametertype_text.Clear();
            donation_combo.Items.Clear();
            donation_combo.Items.Add("범위");
            donation_combo.Items.Add("일치");
            setparameter_combo.Items.Clear();
            setparameter_combo.Items.Add("랜덤");
            setparameter_combo.Items.Add("값변경");
            setparameter_combo.Items.Add("값변경후복귀");
            donationmin_text.Clear();
            donationmax_text.Clear();
            donationsame_text.Clear();
            settime1st_text.Clear();
            settime2nd_text.Clear();
            settimetime_text.Clear();
            randommax_text.Clear();
            randommin_text.Clear();
            set_text.Clear();
            donationmax_text.Visible = false;
            donationmin_text.Visible=false;
            donationsame_text.Visible=false;
            donation_label.Visible=false;
            randommin_text.Clear();
            randommax_text.Clear();
            random_lable.Visible = false;
            randommin_text.Visible = false;
            randommax_text.Visible = false;
            set_text.Clear();
            set_text.Visible = false;
            settime1st_text.Clear();
            settime1st_text.Visible = false;
            settime2nd_text.Clear();
            settime2nd_text.Visible = false;
            settimetime_text.Clear();
            settimetime_text.Visible = false;
            settime_lable.Visible = false;          
        }        

        //6. 창을 움직이기 위한 설정
        private bool TagMove;
        private int MValX, MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        private void donationmin_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                donationmin_text.Text = String.Format("{0:#,##0}", int.Parse(donationmin_text.Text.Replace(",","")));
                donationmin_text.Select(donationmin_text.Text.Length, 0);
            }
            catch
            {

            }
        }

        private void donationmax_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                donationmax_text.Text = String.Format("{0:#,##0}", int.Parse(donationmax_text.Text.Replace(",","")));
                donationmax_text.Select(donationmax_text.Text.Length, 0);
            }
            catch
            {

            }
        }

        private void donationsame_text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                donationsame_text.Text = String.Format("{0:#,##0}", int.Parse(donationsame_text.Text.Replace(",","")));
                donationsame_text.Select(donationsame_text.Text.Length, 0);
            }
            catch
            {

            }
        }

                                     
    }
}
