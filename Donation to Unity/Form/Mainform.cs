using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using WebSocketSharp;
using Donation;
using Microsoft.WindowsAPICodePack.Dialogs;
using SharpOSC;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Donation_attack_into_VRC
{
    public partial class Mainform : Form
    {      
        public Mainform()
        {
            InitializeComponent();
            //초기설정
            dialog1.Sendlist += new MyEventHandler(savelist);
            this.BackColor = ColorTranslator.FromHtml("#daa4c4");
            toon_back.BackColor = ColorTranslator.FromHtml("#29b6f6");
            twip_back.BackColor = ColorTranslator.FromHtml("#9400D3");
            labelsetbackforecolor(label4, "#29b6f6", "#FFFFFF");
            labelsetbackforecolor(label5, "#9400D3", "#FFFFFF");
            labelsetbackforecolor(title, "#daa4c4", "#FFFFFF");
            buttonsetbackmouseovercolor(exit_button, "#D9AAFF", "#A02DFF");
            buttonsetbackmouseovercolor(exit_button2, "#D9AAFF", "#A02DFF");
            buttonsetbackmouseovercolor(addparameter_bt, "#D9AAFF", "#A02DFF");
            buttonsetbackmouseovercolor(tap2_button, "#E8C8DB", "#D292B8");
            buttonsetbackmouseovercolor(tap1_button, "#FFFFFF", "#FFFFFF");
            tabControl1.ItemSize = new Size(0, 30);
        }

        /*
        1. 도네연결버튼 눌렀을때 디자인 설정
        2. 도네알림 연동되었을때 또는 해제되었을때의 디자인 설정
        3. 파라메터 추가창 생성
        4. 각종 버튼 클릭했을때 함수 설정
        5. 창을 움직이기 위한 설정
        6. 탭페이지 버튼 디자인 설정
        7. OSC전송규칙 추가
        8. OSC전송규칙 삭제
        9. 컨트롤 색상 바꾸는 함수설정
        10. 컨트롤 생성 함수 설정
        11. 컨트롤 삭제 함수 설정
        12. 프로그램 열때 저장데이터 불러오기
        13. 프로그램 종료할때 데이터 저장

        */

        //1. 도네연결버튼 눌렀을때 디자인 설정
        public void connecttoonation_bt_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                toonation.Conect(keytoonation_text.Text.ToString());
            });
            connecttoonation_bt.Enabled = false;
            disconnecttoonation_bt.Enabled = true;
            keytoonation_text.Enabled = false;
            toonation.toonationmoneycomeevent += new MyEventHandlerint(doAction);
            toonation.toonationconnectedevent += new MyEventHandlerbool(toonationconnect);
        }        
        private async void disconnecttoonation_bt_Click_1(object sender, EventArgs e)
        {
            Task.Run(() => toonation.Disonnect());
            disconnecttoonation_bt.Enabled = false;
            for (int i = 5; i > 0; i-- )
            {
                disconnecttoonation_bt.Text = i.ToString() + "...";
                await Task.Delay(1000);
            }
            disconnecttoonation_bt.Text = "연결끊기";
            connecttoonation_bt.Enabled = true;
            keytoonation_text.Enabled = true;
        }
        private void connecttwip_bt_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                twip.Connect(keytwip_text.Text.ToString());
            });
            connecttwip_bt.Enabled = false;
            disconnecttwip_bt.Enabled = true;
            keytwip_text.Enabled = false;
            twip.twipmoneycomeevent += new MyEventHandlerint(doAction);
            twip.twipconnectedevent += new MyEventHandlerbool(twipconnect);
        }
        private void disconnecttwip_bt_Click(object sender, EventArgs e)
        {
            Task.Run(() => twip.Disconnect());
            connecttwip_bt.Enabled = true;
            disconnecttwip_bt.Enabled = false;
            keytwip_text.Enabled = true;
        }       

        //2. 도네알림 연동되었을때 또는 해제되었을때의 디자인 설정
        private void twipconnect(bool a)
        {
            if(a)
            {
                twipcolor.BackColor = Color.Lime;
            }
            else
            {
                twipcolor.BackColor= Color.Red;
                disconnecttwip_bt.Enabled = false;
                keytwip_text.Enabled = true;
            }
        }
        private void toonationconnect(bool a)
        {
            if(a)
            {
                tooncolor.BackColor = Color.Lime;
            }
            else
            {
                tooncolor.BackColor = Color.Red;
                connecttoonation_bt.Enabled = true;
                keytoonation_text.Enabled = true;
            }
        }

        //3. 파라메터 추가창 생성
        addparameterform dialog1 = new addparameterform();
        private void addparameter_bt_Click(object sender, EventArgs e)
        {
            dialog1.StartPosition = FormStartPosition.Manual;
            dialog1.Location = new Point(this.Location.X + 160, this.Location.Y + 80);
            dialog1.ShowDialog();
        }

        //4. 각종 버튼 클릭했을때 함수 설정
        private void toonsite_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://toon.at/streamer/widget_alertbox");
        }
        private void twipsite_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twip.kr/dashboard/alertbox");
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //5. 창을 움직이기 위한 설정
        private bool TagMove;
        private int MValX, MValY;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        private void exit_button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        //6. 탭페이지 버튼 디자인 설정
        private void tap1_button_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            buttonsetbackmouseovercolor(tap1_button, "#FFFFFF", "#FFFFFF");
            buttonsetbackmouseovercolor(tap2_button, "#E8C8DB", "#D292B8");
        }
        private void tap2_button_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            buttonsetbackmouseovercolor(tap2_button, "#FFFFFF", "#FFFFFF");
            buttonsetbackmouseovercolor(tap1_button, "#E8C8DB", "#D292B8");
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        //7. OSC전송규칙컨트롤 추가
        private void makeoscform(List<string> list)
        {
            deletebutton.Add(new Button());
            testbutton.Add(new Button());
            donationmin.Add(new TextBox());
            donationmax.Add(new TextBox());
            labelfordonationset.Add(new Label());
            labelfordonationrange.Add(new Label());
            parametername.Add(new TextBox());
            parametermin.Add(new TextBox());
            parametermax.Add(new TextBox());
            labelforparameterrange.Add(new Label());
            labelforparameterset.Add(new Label());
            parametertime.Add(new TextBox());
            labelforlocation.Add(new Label());
            int lenght = deletebutton.Count;

            //여기서부터이 함수 끝날때까지 순서 바꾸기 금지
            if (list[0] == list[1])
            {
                addtextboxs(donationmin, list, 0, lenght);
                addlabels(labelfordonationset, 0, lenght, 126, 0, "");
            }
            else
            {
                addtextboxs(donationmin, list, 0, lenght);
                addlabels(labelfordonationrange, 1, lenght, 20, 20, "~");
                addtextboxs(donationmax, list, 1, lenght);
            }
            addtextboxs(parametername, list, 2, lenght);
            switch (int.Parse(list[3]))
            {
                case 1:
                    {
                        addtextboxs(parametermin, list, 4, lenght);
                        addlabels(labelforparameterrange, 0, lenght, 20, 0, "~");
                        addtextboxs(parametermax, list, 5, lenght);
                        addlabels(labelforlocation, 0, lenght, 156, 0, "");
                        break;
                    }
                case 2:
                    {
                        addtextboxs(parametermin, list, 4, lenght);
                        addlabels(labelforparameterset, 0, lenght, 50, 0, "");
                        addlabels(labelforlocation, 0, lenght, 232, 0, "");
                        break;
                    }
                case 3:
                    {
                        addtextboxs(parametermin, list, 4, lenght);
                        addlabels(labelforlocation, 0, lenght, 20, 0, "");
                        addtextboxs(parametertime, list, 5, lenght);
                        addlabels(labelforparameterset, 1, lenght, 50, 20, "초후");
                        addtextboxs(parametermax, list, 6, lenght);
                        break;
                    }
            }
            addbuttons(deletebutton, "삭제", lenght, del_buttonclick);            
            addbuttons(testbutton, "테스트", lenght, test_buttonclick);
        }

        //8. OSC전송규칙 컨트롤 삭제
        void del_buttonclick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int indexnum = -1;
            for (int i = 0; i < deletebutton.Count; i++)
            {
                if (deletebutton[i] == btn)
                {
                    indexnum = i;
                }
            }
            parameterlist.RemoveAt(indexnum);
            deletebuttons(deletebutton, indexnum);
            deletetextboxs(donationmin, indexnum);
            deletetextboxs(donationmax, indexnum);
            deletelabels(labelfordonationset, indexnum);
            deletetextboxs(parametername, indexnum);
            deletetextboxs(parametermin, indexnum);
            deletetextboxs(parametermax, indexnum);
            deletelabels(labelforparameterset, indexnum);
            deletetextboxs(parametertime, indexnum);
            deletelabels(labelfordonationrange, indexnum);
            deletelabels(labelforparameterrange, indexnum);
            deletelabels(labelforlocation, indexnum);
            deletebuttons(testbutton, indexnum);
        }

        //9. 컨트롤 색상 바꾸는 함수설정
        private void labelsetbackforecolor(Label target, string backcolor, string forecolor)
        {
            target.BackColor = ColorTranslator.FromHtml(backcolor);
            target.ForeColor = ColorTranslator.FromHtml(forecolor);

        }
        private void buttonsetbackmouseovercolor(Button target, string backcolor, string forecolor)
        {
            target.BackColor = ColorTranslator.FromHtml(backcolor);
            target.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(forecolor);
        }

        //10. 컨트롤 생성 함수 설정
        private void addlabels(List<Label> target, int type, int lenght, int width, int height, string text)
        {
            target[lenght - 1].Text = text;
            target[lenght - 1].Width = width;
            if (type == 1)
            {
                target[lenght - 1].Height = height;
            }
            target[lenght - 1].TextAlign = ContentAlignment.BottomCenter;
            flowLayoutPanel1.Controls.Add(target[lenght - 1]);
        }
        private void addtextboxs(List<TextBox> target, List<string> data, int indexnum, int lenght)
        {
            try
            {
                target[lenght - 1].Text = string.Format("{0:#,##0}", int.Parse(data[indexnum]));
            }
            catch
            {
                target[lenght - 1].Text = data[indexnum];
            }
            target[lenght - 1].ReadOnly = true;
            target[lenght - 1].BackColor = SystemColors.HighlightText;
            target[lenght - 1].TextAlign = HorizontalAlignment.Center;
            flowLayoutPanel1.Controls.Add(target[lenght - 1]);
        }
        private void addbuttons(List<Button> target, string text, int lenght, EventHandler a)
        {
            target[lenght - 1].Text = text;
            target[lenght - 1].Height = 30;
            target[lenght - 1].BackColor = ColorTranslator.FromHtml("#D9AAFF");
            target[lenght - 1].FlatStyle = FlatStyle.Flat;
            target[lenght - 1].FlatAppearance.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
            target[lenght - 1].FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#A02DFF");
            target[lenght - 1].Click += new EventHandler(a);
            target[lenght - 1].MouseEnter += new EventHandler(exit_button_MouseEnter);
            target[lenght - 1].MouseLeave += new EventHandler(exit_button_MouseLeave);
            flowLayoutPanel1.Controls.Add(target[lenght - 1]);
        }

        //11. 컨트롤 삭제 함수 설정
        private void deletelabels(List<Label> target, int indexnum)
        {
            flowLayoutPanel1.Controls.Remove(target[indexnum]);
            this.Controls.Remove(target[indexnum]);
            target.RemoveAt(indexnum);
        }
        private void deletetextboxs(List<TextBox> target, int indexnum)
        {
            flowLayoutPanel1.Controls.Remove(target[indexnum]);
            this.Controls.Remove(target[indexnum]);
            target.RemoveAt(indexnum);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("몽남#2410으로 연락주세요!");
        }

        private void deletebuttons(List<Button> target, int indexnum)
        {
            flowLayoutPanel1.Controls.Remove(target[indexnum]);
            this.Controls.Remove(target[indexnum]);
            target.RemoveAt(indexnum);
        }

        //12. 프로그램 열때 저장데이터 불러오기
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            keytoonation_text.Text = Properties.Settings.Default.toonationtoken;
            keytwip_text.Text = Properties.Settings.Default.twiptoken;
            try
            {
                parameterlist.Clear();
                Stream rs = new FileStream("C:\\Program Files (x86)\\Donation attack into VRC\\data.xml", FileMode.Open);
                BinaryFormatter deserilizer = new BinaryFormatter();
                parameterlist = (List<List<string>>)deserilizer.Deserialize(rs);       
                rs.Close();
                foreach (List<string> list in parameterlist)
                {
                    makeoscform(list);
                }
            }
            catch
            {

            }
        }

        //13. 프로그램 종료할때 데이터 저장
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.toonationtoken = keytoonation_text.Text;
            Properties.Settings.Default.twiptoken = keytwip_text.Text;
            Properties.Settings.Default.Save();
            Stream ws = new FileStream("C:\\Program Files (x86)\\Donation attack into VRC\\data.xml", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ws, parameterlist);
            ws.Close();
        }
    }
}
