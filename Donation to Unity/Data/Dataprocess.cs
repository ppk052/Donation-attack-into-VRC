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
using Newtonsoft.Json;

namespace Donation_attack_into_VRC
{
    public partial class Mainform
    {
        //도네이션 객체생성
        Toonation toonation = new Toonation();
        Twip twip = new Twip();

        //컨트롤 관리를 위한 객체생성
        static int preprameter = 0;
        static List<List<string>> parameterlist = new List<List<string>>();
        private List<Button> deletebutton = new List<Button>();
        private List<Button> testbutton = new List<Button>();
        private List<TextBox> donationmin = new List<TextBox>();
        private List<TextBox> donationmax = new List<TextBox>();
        private List<Label> labelfordonationset = new List<Label>();
        private List<Label> labelfordonationrange = new List<Label>();
        private List<TextBox> parametername = new List<TextBox>();
        private List<TextBox> parametermin = new List<TextBox>();
        private List<Label> labelforparameterrange = new List<Label>();
        private List<TextBox> parametermax = new List<TextBox>();
        private List<Label> labelforparameterset = new List<Label>();
        private List<TextBox> parametertime = new List<TextBox>();
        private List<Label> labelforlocation = new List<Label>();
        static Random random = new Random();

        //OSC를 통해서 VRC에 파라메터 전송
        static async public void doAction(int A)
        {
            for (int i = 0; i < parameterlist.Count; i++)
            {
                if ((A >= int.Parse(parameterlist[i][0]) && A <= int.Parse(parameterlist[i][1])) || (A == int.Parse(parameterlist[i][0])))
                {
                    switch (int.Parse(parameterlist[i][3]))
                    {
                        case 1:
                            {
                                int a = random.Next(int.Parse(parameterlist[i][4]), int.Parse(parameterlist[i][5]) + 1);
                                while (a == preprameter)
                                {
                                    a = random.Next(int.Parse(parameterlist[i][4]), int.Parse(parameterlist[i][5]) + 1);
                                }
                                var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], a);
                                var sender = new UDPSender("127.0.0.1", 9000);
                                sender.Send(message);
                                preprameter = a;
                                break;
                            }
                        case 2:
                            {
                                if (parameterlist[i][parameterlist[i].Count - 1] == "Bool")
                                {
                                    if (parameterlist[i][4] == "0")
                                    {
                                        var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], false);
                                        var sender = new UDPSender("127.0.0.1", 9000);
                                        sender.Send(message);
                                    }
                                    else
                                    {
                                        var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], true);
                                        var sender = new UDPSender("127.0.0.1", 9000);
                                        sender.Send(message);
                                    }
                                }
                                else
                                {
                                    var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], int.Parse(parameterlist[i][4]));
                                    var sender = new UDPSender("127.0.0.1", 9000);
                                    sender.Send(message);
                                }
                                break;
                            }
                        case 3:
                            {
                                if (parameterlist[i][parameterlist[i].Count - 1] == "Bool")
                                {
                                    bool a = parameterlist[i][4] == "0" ? false : true;
                                    var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], a);
                                    var sender = new UDPSender("127.0.0.1", 9000);
                                    sender.Send(message);
                                    await Task.Delay(int.Parse(parameterlist[i][5]) * 1000);
                                    bool b = parameterlist[i][6] == "0" ? false : true;
                                    var message2 = new OscMessage("/avatar/parameters/" + parameterlist[i][2], b);
                                    sender.Send(message2);
                                }
                                else
                                {
                                    var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], parameterlist[i][4]);
                                    var sender = new UDPSender("127.0.0.1", 9000);
                                    sender.Send(message);
                                    await Task.Delay(int.Parse(parameterlist[i][5]) * 1000);
                                    var message2 = new OscMessage("/avatar/parameters/" + parameterlist[i][2], parameterlist[i][6]);
                                    sender.Send(message2);
                                }
                                break;
                            }
                    }
                }
            }
        }

        //프로그램 열때 저장데이터 불러오기
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            keytoonation_text.Text = Properties.Settings.Default.toonationtoken;
            keytwip_text.Text = Properties.Settings.Default.twiptoken;
            try
            {
                Stream rs = new FileStream("oscdata.dat", FileMode.Open);
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

        //프로그램 종료할때 데이터 저장
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.toonationtoken = keytoonation_text.Text;
            Properties.Settings.Default.twiptoken = keytwip_text.Text;
            Properties.Settings.Default.Save();
            Stream ws = new FileStream("oscdata.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ws, parameterlist);
            ws.Close();
        }

        //OSC설정을 리스트에 저장
        private void savelist()
        {
            List<string> list1 = new List<string>();
            list1.Add(dialog1.donationmin);
            list1.Add(dialog1.donationmax);
            list1.Add(dialog1.parametername);
            list1.Add(dialog1.parametersendtype);
            list1.Add(dialog1.value1);
            if (dialog1.value2 != null)
            {
                list1.Add(dialog1.value2);
            }
            if (dialog1.value3 != null)
            {
                list1.Add(dialog1.value3);
            }
            list1.Add(dialog1.parametertype);
            parameterlist.Add(list1);
            makeoscform(list1);
        }

        //OSC전송테스트
        private async void test_buttonclick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int i = -1;
            for (int j = 0; j < testbutton.Count; j++)
            {
                if (testbutton[j] == btn)
                {
                    i = j;
                }
            }
            switch (int.Parse(parameterlist[i][3]))
            {
                case 1:
                    {
                        int a = random.Next(int.Parse(parameterlist[i][4]), int.Parse(parameterlist[i][5]) + 1);
                        while (a == preprameter)
                        {
                            a = random.Next(int.Parse(parameterlist[i][4]), int.Parse(parameterlist[i][5]) + 1);
                        }
                        var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], a);
                        var sender1 = new UDPSender("127.0.0.1", 9000);
                        sender1.Send(message);
                        preprameter = a;
                        break;
                    }
                case 2:
                    {
                        if (parameterlist[i][parameterlist[i].Count - 1] == "Bool")
                        {
                            if (parameterlist[i][4] == "0")
                            {
                                var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], false);
                                var sender1 = new UDPSender("127.0.0.1", 9000);
                                sender1.Send(message);
                            }
                            else
                            {
                                var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], true);
                                var sender1 = new UDPSender("127.0.0.1", 9000);
                                sender1.Send(message);
                            }
                        }
                        else
                        {
                            var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], int.Parse(parameterlist[i][4]));
                            var sender1 = new UDPSender("127.0.0.1", 9000);
                            sender1.Send(message);
                        }
                        break;
                    }
                case 3:
                    {
                        if (parameterlist[i][parameterlist[i].Count - 1] == "Bool")
                        {
                            bool a = parameterlist[i][4] == "0" ? false : true;
                            var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], a);
                            var sender1 = new UDPSender("127.0.0.1", 9000);
                            sender1.Send(message);
                            await Task.Delay(int.Parse(parameterlist[i][5]) * 1000);
                            bool b = parameterlist[i][6] == "0" ? false : true;
                            var message2 = new OscMessage("/avatar/parameters/" + parameterlist[i][2], b);
                            sender1.Send(message2);
                        }
                        else
                        {
                            var message = new OscMessage("/avatar/parameters/" + parameterlist[i][2], parameterlist[i][4]);
                            var sender1 = new UDPSender("127.0.0.1", 9000);
                            sender1.Send(message);
                            await Task.Delay(int.Parse(parameterlist[i][5]) * 1000);
                            var message2 = new OscMessage("/avatar/parameters/" + parameterlist[i][2], parameterlist[i][6]);
                            sender1.Send(message2);
                        }
                        break;
                    }
            }
        }
    }

    //json파일을 읽기위한 사전작업
    public class foundation
    {
        public string id;
        public string name;
        public List<parameters> parameters;
    }
    public class parameters
    {
        public string name;
        public input input;
        public output output;
    }
    public class input
    {
        public string address;
        public string type;

    }
    public class output
    {
        public string address;
        public string type;

    }

    //아바타에 있는 파라메터 불러오기
    public partial class addparameterform
    {
        Dictionary<string, List<List<string>>> para = new Dictionary<string, List<List<string>>>();
        private async void Openfolder_bt_Click(object sender, EventArgs e)
        {
            if (userid_text.Text.Contains("usr_") && userid_text.Text.Length == 40)
            {
                if (userid_text.Text == "usr_********-****-****-****-************")
                {
                    MessageBox.Show("userid를 입력하세요");
                }
                else
                {
                    userid_text.Enabled = false;
                    para.Clear();
                    string Path = "C:\\Users\\" + (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1] + "\\AppData\\LocalLow\\VRChat\\VRChat\\OSC\\" + userid_text.Text.ToString() + "\\Avatars";
                    try
                    {
                        string[] files = Directory.GetFiles(Path, "*.json");
                        avartname_combo.Items.Clear();
                        avartname_combo.Text = "아바타";
                        parameter_combo.Text = "파라메터";
                        for (int i = 0; i < files.Length; i++)
                        {

                            StreamReader r = new StreamReader(files[i]);
                            List<List<string>> avartar = new List<List<string>>();
                            string jsonstring = r.ReadToEnd();
                            foundation parameters = JsonConvert.DeserializeObject<foundation>(jsonstring);
                            for (int j = 0; j < parameters.parameters.Count; j++)
                            {
                                if (parameters.parameters[j].input != null)
                                {
                                    List<string> parame = new List<string>();
                                    parame.Add(parameters.parameters[j].name);
                                    parame.Add(parameters.parameters[j].input.type);
                                    avartar.Add(parame);
                                }
                            }
                            para.Add(parameters.name, avartar);
                            avartname_combo.Items.Add(parameters.name);

                        }
                        opencompleted_label.Text = "불러오기 완료";
                        await Task.Delay(1000);
                        opencompleted_label.Text = "";
                        userid_text.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("VR챗의 OSC를 켜주세요");
                    }
                }

            }
            else
            {
                MessageBox.Show("올바른 userid형식이 아닙니다");
            }

        }
        
        private void setparameter()
        {
            switch (setparameter_combo.SelectedItem)
            {
                case "랜덤":
                    {
                        parametersendtype = "1";
                        value1 = randommin_text.Text;
                        value2 = randommax_text.Text;
                        break;
                    }
                case "값변경":
                    {
                        parametersendtype = "2";
                        value1 = set_text.Text;
                        break;
                    }
                case "값변경후복귀":
                    {
                        parametersendtype = "3";
                        value1 = settime1st_text.Text;
                        value2 = settimetime_text.Text;
                        value3 = settime2nd_text.Text;
                        break;
                    }
            }
            parametertype = parametertype_text.Text;
        }
        private bool checkdata()
        {
            if (parameter_combo.SelectedItem == null)
            {
                MessageBox.Show("파라메터를 선택하세요");
                return false;
            }
            if (donation_combo.SelectedItem == null)
            {
                MessageBox.Show("금액을 설정하세요");
                return false;
            }
            else if (donation_combo.SelectedItem.ToString() == "범위")
            {
                try
                {
                    if (donationmin_text.Text == "" || donationmin_text == null || donationmax_text.Text == "" || donationmax_text == null)
                    {
                        MessageBox.Show("금액을 입력하세요");
                        return false;
                    }
                    int a = int.Parse(donationmin_text.Text);
                    int b = int.Parse(donationmax_text.Text);
                    if (int.Parse(donationmin_text.Text) >= int.Parse(donationmax_text.Text))
                    {
                        MessageBox.Show("금액의 왼쪽값이 오른쪽값보다 작게 설정하세요");
                        return false;
                    }

                }
                catch
                {
                    MessageBox.Show("숫자만 입력하세요");
                    return false;
                }

            }
            else if (donation_combo.SelectedItem.ToString() == "일치")
            {
                try
                {
                    if (donationsame_text.Text == "" || donationsame_text == null)
                    {
                        MessageBox.Show("금액을 입력하세요");
                        return false;
                    }
                    int a = int.Parse(donationsame_text.Text);
                }
                catch
                {
                    MessageBox.Show("금액에 숫자만 입력하세요");
                    return false;
                }
            }
            if (setparameter_combo.SelectedItem == null)
            {
                MessageBox.Show("파라메터전송방식을 선택하세요");
                return false;
            }
            else if (setparameter_combo.SelectedItem.ToString() == "랜덤")
            {
                try
                {
                    if (randommin_text.Text == "" || randommin_text == null || randommax_text.Text == "" || randommax_text == null)
                    {
                        MessageBox.Show("파라메터값을 입력하세요");
                        return false;
                    }
                    int a = int.Parse(randommin_text.Text);
                    int b = int.Parse(randommax_text.Text);
                    if (int.Parse(randommin_text.Text) >= int.Parse(randommax_text.Text))
                    {
                        MessageBox.Show("파라메터의 왼쪽값이 오른쪽값보다 작게 설정하세요");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("파라메터값에 숫자(정수부분)만 입력하세요");
                    return false;
                }
            }
            else if (setparameter_combo.SelectedItem.ToString() == "값변경")
            {
                try
                {
                    if (set_text == null || set_text.Text == "")
                    {
                        MessageBox.Show("파라메터값을 입력하세요");
                        return false;
                    }
                    int a = int.Parse(set_text.Text);
                }
                catch
                {
                    MessageBox.Show("파라메터값에 숫자(정수부분)만 입력하세요");
                    return false;
                }
                if (parametertype_text.Text == "Bool")
                {
                    if (set_text.Text != "0" && set_text.Text != "1")
                    {
                        MessageBox.Show("파마메터가 Bool 이므로 값을 1(true)또는 0(false)만 입력하세요");
                        return false;
                    }
                }
            }
            else if (setparameter_combo.SelectedItem.ToString() == "값변경후복귀")
            {
                try
                {
                    if (settime1st_text == null || settime1st_text.Text == "" || settime2nd_text == null || settime2nd_text.Text == "" || settimetime_text == null || settimetime_text.Text == "")
                    {
                        MessageBox.Show("파라메터값을 입력하세요");
                        return false;
                    }
                    int a = int.Parse(settime1st_text.Text);
                    int b = int.Parse(settime2nd_text.Text);
                    int c = int.Parse(settimetime_text.Text);
                }
                catch
                {
                    MessageBox.Show("파라메터값에 숫자(정수부분)만 입력하세요");
                    return false;
                }
                if (parametertype_text.Text == "Bool")
                {
                    if (settime1st_text.Text != "0" && settime1st_text.Text != "1")
                    {
                        MessageBox.Show("파마메터가 Bool 이므로 값을 1(true)또는 0(false)만 입력하세요");
                        return false;
                    }
                    else if (settime2nd_text.Text != "0" && settime2nd_text.Text != "1")
                    {
                        MessageBox.Show("파마메터가 Bool 이므로 값을 1(true)또는 0(false)만 입력하세요");
                        return false;
                    }
                }
            }
            return true;
        }
        private void senddata()
        {
            switch (donation_combo.SelectedIndex)
            {
                case 0:
                    {
                        donationmin = donationmin_text.Text;
                        donationmax = donationmax_text.Text;
                        parametername = parameter_combo.Text;
                        setparameter();
                        break;
                    }
                case 1:
                    {
                        donationmin = donationsame_text.Text;
                        donationmax = donationsame_text.Text;
                        parametername = parameter_combo.Text;
                        setparameter();
                        break;
                    }
            }
            Sendlist();
            this.Hide();
        }
    }
}
