namespace Donation_attack_into_VRC
{
    partial class Mainform
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.keytoonation_text = new System.Windows.Forms.TextBox();
            this.connecttoonation_bt = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.keytwip_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.twip_back = new System.Windows.Forms.Panel();
            this.connecttwip_bt = new System.Windows.Forms.Button();
            this.twipsite_button = new System.Windows.Forms.Button();
            this.disconnecttwip_bt = new System.Windows.Forms.Button();
            this.toonsite_button = new System.Windows.Forms.Button();
            this.disconnecttoonation_bt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toon_back = new System.Windows.Forms.Panel();
            this.exit_button = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exit_button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addparameter_bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tooncolor = new System.Windows.Forms.Label();
            this.twipcolor = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tap2_button = new System.Windows.Forms.Button();
            this.tap1_button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.twip_back.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // keytoonation_text
            // 
            this.keytoonation_text.BackColor = System.Drawing.SystemColors.HighlightText;
            this.keytoonation_text.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.keytoonation_text.Location = new System.Drawing.Point(269, 22);
            this.keytoonation_text.Multiline = true;
            this.keytoonation_text.Name = "keytoonation_text";
            this.keytoonation_text.Size = new System.Drawing.Size(391, 40);
            this.keytoonation_text.TabIndex = 1;
            this.keytoonation_text.TabStop = false;
            // 
            // connecttoonation_bt
            // 
            this.connecttoonation_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.connecttoonation_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connecttoonation_bt.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connecttoonation_bt.Location = new System.Drawing.Point(664, 22);
            this.connecttoonation_bt.Margin = new System.Windows.Forms.Padding(0);
            this.connecttoonation_bt.Name = "connecttoonation_bt";
            this.connecttoonation_bt.Size = new System.Drawing.Size(64, 40);
            this.connecttoonation_bt.TabIndex = 4;
            this.connecttoonation_bt.TabStop = false;
            this.connecttoonation_bt.Text = "연결";
            this.connecttoonation_bt.UseVisualStyleBackColor = true;
            this.connecttoonation_bt.Click += new System.EventHandler(this.connecttoonation_bt_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 50);
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 513);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.keytwip_text);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.twip_back);
            this.tabPage1.Controls.Add(this.toonsite_button);
            this.tabPage1.Controls.Add(this.disconnecttoonation_bt);
            this.tabPage1.Controls.Add(this.connecttoonation_bt);
            this.tabPage1.Controls.Add(this.keytoonation_text);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.toon_back);
            this.tabPage1.Controls.Add(this.exit_button);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Font = new System.Drawing.Font("굴림", 15F);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "도네연동";
            // 
            // keytwip_text
            // 
            this.keytwip_text.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.keytwip_text.Location = new System.Drawing.Point(269, 113);
            this.keytwip_text.Multiline = true;
            this.keytwip_text.Name = "keytwip_text";
            this.keytwip_text.Size = new System.Drawing.Size(391, 40);
            this.keytwip_text.TabIndex = 7;
            this.keytwip_text.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(4, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "twip.kr/widgets/alertbox/";
            // 
            // twip_back
            // 
            this.twip_back.AllowDrop = true;
            this.twip_back.Controls.Add(this.connecttwip_bt);
            this.twip_back.Controls.Add(this.twipsite_button);
            this.twip_back.Controls.Add(this.disconnecttwip_bt);
            this.twip_back.Location = new System.Drawing.Point(3, 92);
            this.twip_back.Name = "twip_back";
            this.twip_back.Size = new System.Drawing.Size(927, 83);
            this.twip_back.TabIndex = 18;
            // 
            // connecttwip_bt
            // 
            this.connecttwip_bt.BackColor = System.Drawing.Color.White;
            this.connecttwip_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.connecttwip_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connecttwip_bt.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connecttwip_bt.Location = new System.Drawing.Point(661, 21);
            this.connecttwip_bt.Name = "connecttwip_bt";
            this.connecttwip_bt.Size = new System.Drawing.Size(64, 40);
            this.connecttwip_bt.TabIndex = 9;
            this.connecttwip_bt.TabStop = false;
            this.connecttwip_bt.Text = "연결";
            this.connecttwip_bt.UseVisualStyleBackColor = false;
            this.connecttwip_bt.Click += new System.EventHandler(this.connecttwip_bt_Click);
            // 
            // twipsite_button
            // 
            this.twipsite_button.BackColor = System.Drawing.Color.White;
            this.twipsite_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.twipsite_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twipsite_button.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.twipsite_button.Location = new System.Drawing.Point(838, 21);
            this.twipsite_button.Name = "twipsite_button";
            this.twipsite_button.Size = new System.Drawing.Size(84, 41);
            this.twipsite_button.TabIndex = 15;
            this.twipsite_button.TabStop = false;
            this.twipsite_button.Text = "사이트";
            this.twipsite_button.UseVisualStyleBackColor = false;
            this.twipsite_button.Click += new System.EventHandler(this.twipsite_button_Click);
            // 
            // disconnecttwip_bt
            // 
            this.disconnecttwip_bt.BackColor = System.Drawing.Color.White;
            this.disconnecttwip_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.disconnecttwip_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnecttwip_bt.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.disconnecttwip_bt.Location = new System.Drawing.Point(730, 21);
            this.disconnecttwip_bt.Name = "disconnecttwip_bt";
            this.disconnecttwip_bt.Size = new System.Drawing.Size(102, 41);
            this.disconnecttwip_bt.TabIndex = 10;
            this.disconnecttwip_bt.TabStop = false;
            this.disconnecttwip_bt.Text = "연결끊기";
            this.disconnecttwip_bt.UseVisualStyleBackColor = false;
            this.disconnecttwip_bt.Click += new System.EventHandler(this.disconnecttwip_bt_Click);
            // 
            // toonsite_button
            // 
            this.toonsite_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.toonsite_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toonsite_button.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toonsite_button.Location = new System.Drawing.Point(841, 22);
            this.toonsite_button.Name = "toonsite_button";
            this.toonsite_button.Size = new System.Drawing.Size(84, 39);
            this.toonsite_button.TabIndex = 14;
            this.toonsite_button.TabStop = false;
            this.toonsite_button.Text = "사이트";
            this.toonsite_button.UseVisualStyleBackColor = true;
            this.toonsite_button.Click += new System.EventHandler(this.toonsite_button_Click);
            // 
            // disconnecttoonation_bt
            // 
            this.disconnecttoonation_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.disconnecttoonation_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnecttoonation_bt.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.disconnecttoonation_bt.Location = new System.Drawing.Point(733, 22);
            this.disconnecttoonation_bt.Name = "disconnecttoonation_bt";
            this.disconnecttoonation_bt.Size = new System.Drawing.Size(102, 40);
            this.disconnecttoonation_bt.TabIndex = 7;
            this.disconnecttoonation_bt.TabStop = false;
            this.disconnecttoonation_bt.Text = "연결끊기";
            this.disconnecttoonation_bt.UseVisualStyleBackColor = true;
            this.disconnecttoonation_bt.Click += new System.EventHandler(this.disconnecttoonation_bt_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "toon.at/widget/alertbox/";
            // 
            // toon_back
            // 
            this.toon_back.AllowDrop = true;
            this.toon_back.Location = new System.Drawing.Point(3, 6);
            this.toon_back.Name = "toon_back";
            this.toon_back.Size = new System.Drawing.Size(927, 75);
            this.toon_back.TabIndex = 17;
            // 
            // exit_button
            // 
            this.exit_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exit_button.Location = new System.Drawing.Point(7, 424);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(84, 39);
            this.exit_button.TabIndex = 16;
            this.exit_button.TabStop = false;
            this.exit_button.Text = "종료";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            this.exit_button.MouseEnter += new System.EventHandler(this.exit_button_MouseEnter);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.exit_button2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.addparameter_bt);
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(936, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VR챗연동";
            // 
            // exit_button2
            // 
            this.exit_button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exit_button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exit_button2.Location = new System.Drawing.Point(90, 423);
            this.exit_button2.Name = "exit_button2";
            this.exit_button2.Size = new System.Drawing.Size(84, 39);
            this.exit_button2.TabIndex = 17;
            this.exit_button2.TabStop = false;
            this.exit_button2.Text = "종료";
            this.exit_button2.UseVisualStyleBackColor = true;
            this.exit_button2.Click += new System.EventHandler(this.exit_button_Click);
            this.exit_button2.MouseEnter += new System.EventHandler(this.exit_button_MouseEnter);
            this.exit_button2.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "파라메터값";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "파라메터이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "금액범위";
            // 
            // addparameter_bt
            // 
            this.addparameter_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addparameter_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addparameter_bt.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addparameter_bt.Location = new System.Drawing.Point(6, 422);
            this.addparameter_bt.Name = "addparameter_bt";
            this.addparameter_bt.Size = new System.Drawing.Size(84, 41);
            this.addparameter_bt.TabIndex = 13;
            this.addparameter_bt.Text = "추가";
            this.addparameter_bt.UseVisualStyleBackColor = true;
            this.addparameter_bt.Click += new System.EventHandler(this.addparameter_bt_Click);
            this.addparameter_bt.MouseEnter += new System.EventHandler(this.exit_button_MouseEnter);
            this.addparameter_bt.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(924, 370);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("CookieRun Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(728, -5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 33);
            this.label6.TabIndex = 6;
            this.label6.Text = "투네이션";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("CookieRun Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(873, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "트윕";
            // 
            // tooncolor
            // 
            this.tooncolor.AutoSize = true;
            this.tooncolor.BackColor = System.Drawing.Color.Red;
            this.tooncolor.Font = new System.Drawing.Font("굴림", 15F);
            this.tooncolor.Location = new System.Drawing.Point(699, 2);
            this.tooncolor.Name = "tooncolor";
            this.tooncolor.Size = new System.Drawing.Size(23, 20);
            this.tooncolor.TabIndex = 8;
            this.tooncolor.Text = "  ";
            // 
            // twipcolor
            // 
            this.twipcolor.AutoSize = true;
            this.twipcolor.BackColor = System.Drawing.Color.Red;
            this.twipcolor.Font = new System.Drawing.Font("굴림", 15F);
            this.twipcolor.Location = new System.Drawing.Point(839, 4);
            this.twipcolor.Name = "twipcolor";
            this.twipcolor.Size = new System.Drawing.Size(23, 20);
            this.twipcolor.TabIndex = 9;
            this.twipcolor.Text = "  ";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("CookieRun Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(9, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(354, 37);
            this.title.TabIndex = 10;
            this.title.Text = "Donation attack into VRC";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tap2_button);
            this.panel1.Controls.Add(this.tap1_button);
            this.panel1.Controls.Add(this.twipcolor);
            this.panel1.Controls.Add(this.tooncolor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(5, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 36);
            this.panel1.TabIndex = 11;
            // 
            // tap2_button
            // 
            this.tap2_button.BackColor = System.Drawing.Color.White;
            this.tap2_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.tap2_button.FlatAppearance.BorderSize = 0;
            this.tap2_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tap2_button.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tap2_button.Location = new System.Drawing.Point(118, 0);
            this.tap2_button.Name = "tap2_button";
            this.tap2_button.Size = new System.Drawing.Size(111, 37);
            this.tap2_button.TabIndex = 11;
            this.tap2_button.Text = "VRC연동";
            this.tap2_button.UseVisualStyleBackColor = false;
            this.tap2_button.Click += new System.EventHandler(this.tap2_button_Click);
            // 
            // tap1_button
            // 
            this.tap1_button.BackColor = System.Drawing.Color.White;
            this.tap1_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.tap1_button.FlatAppearance.BorderSize = 0;
            this.tap1_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tap1_button.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tap1_button.Location = new System.Drawing.Point(7, 0);
            this.tap1_button.Name = "tap1_button";
            this.tap1_button.Size = new System.Drawing.Size(111, 37);
            this.tap1_button.TabIndex = 10;
            this.tap1_button.Text = "도네연동";
            this.tap1_button.UseVisualStyleBackColor = false;
            this.tap1_button.Click += new System.EventHandler(this.tap1_button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Donation_attack_into_VRC.Properties.Resources.디스코드;
            this.pictureBox2.Location = new System.Drawing.Point(9, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Donation_attack_into_VRC.Properties.Resources.머니건콩나물;
            this.pictureBox1.Location = new System.Drawing.Point(656, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 250);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(968, 573);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donation to Unity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.twip_back.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox keytoonation_text;
        private System.Windows.Forms.Button connecttoonation_bt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button disconnecttoonation_bt;
        private System.Windows.Forms.Button disconnecttwip_bt;
        private System.Windows.Forms.Button connecttwip_bt;
        private System.Windows.Forms.TextBox keytwip_text;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addparameter_bt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tooncolor;
        private System.Windows.Forms.Label twipcolor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button twipsite_button;
        private System.Windows.Forms.Button toonsite_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Panel toon_back;
        private System.Windows.Forms.Panel twip_back;
        private System.Windows.Forms.Button exit_button2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button tap2_button;
        private System.Windows.Forms.Button tap1_button;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

