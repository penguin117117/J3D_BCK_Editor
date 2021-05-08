
namespace J3D_BCK_Editor
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Roop_Mode = new System.Windows.Forms.TextBox();
            this.Txt_Rot_Frac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Total_Frame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Bone_Num = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BoneDelete = new System.Windows.Forms.Button();
            this.Add_Bone = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XYZ_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frame_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tangent_Mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ScaleDelete = new System.Windows.Forms.Button();
            this.ScaleAdd = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Table_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RotationDelete = new System.Windows.Forms.Button();
            this.RotatinAdd = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Rotation_Table_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rotation_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TranslationDelete = new System.Windows.Forms.Button();
            this.TranslationAdd = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Translation_Table_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Translation_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.デバッグ = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "状態：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel2.Text = "　　　";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_Roop_Mode);
            this.groupBox1.Controls.Add(this.Txt_Rot_Frac);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Total_Frame);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Bone_Num);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 178);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "チャンクヘッダー設定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "ジョイント数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "フレーム数";
            // 
            // Txt_Roop_Mode
            // 
            this.Txt_Roop_Mode.Location = new System.Drawing.Point(8, 31);
            this.Txt_Roop_Mode.Name = "Txt_Roop_Mode";
            this.Txt_Roop_Mode.Size = new System.Drawing.Size(100, 19);
            this.Txt_Roop_Mode.TabIndex = 1;
            this.Txt_Roop_Mode.Text = "0";
            // 
            // Txt_Rot_Frac
            // 
            this.Txt_Rot_Frac.Location = new System.Drawing.Point(8, 68);
            this.Txt_Rot_Frac.Name = "Txt_Rot_Frac";
            this.Txt_Rot_Frac.Size = new System.Drawing.Size(100, 19);
            this.Txt_Rot_Frac.TabIndex = 1;
            this.Txt_Rot_Frac.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "回転倍率";
            // 
            // Total_Frame
            // 
            this.Total_Frame.Location = new System.Drawing.Point(8, 105);
            this.Total_Frame.Name = "Total_Frame";
            this.Total_Frame.Size = new System.Drawing.Size(100, 19);
            this.Total_Frame.TabIndex = 1;
            this.Total_Frame.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ループモード";
            // 
            // Bone_Num
            // 
            this.Bone_Num.Location = new System.Drawing.Point(8, 142);
            this.Bone_Num.Name = "Bone_Num";
            this.Bone_Num.Size = new System.Drawing.Size(100, 19);
            this.Bone_Num.TabIndex = 1;
            this.Bone_Num.Text = "1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(176, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 492);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BoneDelete);
            this.tabPage1.Controls.Add(this.Add_Bone);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "アニメーションテーブル";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BoneDelete
            // 
            this.BoneDelete.Location = new System.Drawing.Point(143, 412);
            this.BoneDelete.Name = "BoneDelete";
            this.BoneDelete.Size = new System.Drawing.Size(131, 48);
            this.BoneDelete.TabIndex = 2;
            this.BoneDelete.Text = "ボーン削除";
            this.BoneDelete.UseVisualStyleBackColor = true;
            this.BoneDelete.Click += new System.EventHandler(this.BoneDelete_Click);
            // 
            // Add_Bone
            // 
            this.Add_Bone.Location = new System.Drawing.Point(6, 412);
            this.Add_Bone.Name = "Add_Bone";
            this.Add_Bone.Size = new System.Drawing.Size(131, 48);
            this.Add_Bone.TabIndex = 1;
            this.Add_Bone.Text = "ボーン追加";
            this.Add_Bone.UseVisualStyleBackColor = true;
            this.Add_Bone.Click += new System.EventHandler(this.Add_Bone_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BoneNum,
            this.XYZ_State,
            this.Frame_Num,
            this.Start_Frame,
            this.Tangent_Mode});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(720, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // BoneNum
            // 
            this.BoneNum.HeaderText = "ボーン数";
            this.BoneNum.Name = "BoneNum";
            // 
            // XYZ_State
            // 
            this.XYZ_State.HeaderText = "XYZステータス";
            this.XYZ_State.Name = "XYZ_State";
            // 
            // Frame_Num
            // 
            this.Frame_Num.HeaderText = "フレーム数";
            this.Frame_Num.Name = "Frame_Num";
            // 
            // Start_Frame
            // 
            this.Start_Frame.HeaderText = "開始テーブル番号";
            this.Start_Frame.Name = "Start_Frame";
            // 
            // Tangent_Mode
            // 
            this.Tangent_Mode.HeaderText = "タンジェントモード";
            this.Tangent_Mode.Name = "Tangent_Mode";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ScaleDelete);
            this.tabPage2.Controls.Add(this.ScaleAdd);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(720, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "スケールテーブル";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ScaleDelete
            // 
            this.ScaleDelete.Location = new System.Drawing.Point(143, 412);
            this.ScaleDelete.Name = "ScaleDelete";
            this.ScaleDelete.Size = new System.Drawing.Size(131, 48);
            this.ScaleDelete.TabIndex = 4;
            this.ScaleDelete.Text = "スケール削除";
            this.ScaleDelete.UseVisualStyleBackColor = true;
            this.ScaleDelete.Click += new System.EventHandler(this.ScaleDelete_Click);
            // 
            // ScaleAdd
            // 
            this.ScaleAdd.Location = new System.Drawing.Point(6, 412);
            this.ScaleAdd.Name = "ScaleAdd";
            this.ScaleAdd.Size = new System.Drawing.Size(131, 48);
            this.ScaleAdd.TabIndex = 3;
            this.ScaleAdd.Text = "スケール追加";
            this.ScaleAdd.UseVisualStyleBackColor = true;
            this.ScaleAdd.Click += new System.EventHandler(this.ScaleAdd_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Table_Num,
            this.Scale_Value});
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(720, 406);
            this.dataGridView2.TabIndex = 0;
            // 
            // Table_Num
            // 
            this.Table_Num.HeaderText = "テーブル番号";
            this.Table_Num.Name = "Table_Num";
            // 
            // Scale_Value
            // 
            this.Scale_Value.HeaderText = "数値";
            this.Scale_Value.Name = "Scale_Value";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RotationDelete);
            this.tabPage3.Controls.Add(this.RotatinAdd);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(720, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ローテートテーブル";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RotationDelete
            // 
            this.RotationDelete.Location = new System.Drawing.Point(143, 412);
            this.RotationDelete.Name = "RotationDelete";
            this.RotationDelete.Size = new System.Drawing.Size(131, 48);
            this.RotationDelete.TabIndex = 6;
            this.RotationDelete.Text = "ﾛｰﾃｰｼｮﾝ削除";
            this.RotationDelete.UseVisualStyleBackColor = true;
            this.RotationDelete.Click += new System.EventHandler(this.RotationDelete_Click);
            // 
            // RotatinAdd
            // 
            this.RotatinAdd.Location = new System.Drawing.Point(6, 412);
            this.RotatinAdd.Name = "RotatinAdd";
            this.RotatinAdd.Size = new System.Drawing.Size(131, 48);
            this.RotatinAdd.TabIndex = 5;
            this.RotatinAdd.Text = "ﾛｰﾃｰｼｮﾝ追加";
            this.RotatinAdd.UseVisualStyleBackColor = true;
            this.RotatinAdd.Click += new System.EventHandler(this.RotatinAdd_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rotation_Table_Num,
            this.Rotation_Value});
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 21;
            this.dataGridView3.Size = new System.Drawing.Size(720, 406);
            this.dataGridView3.TabIndex = 0;
            // 
            // Rotation_Table_Num
            // 
            this.Rotation_Table_Num.HeaderText = "テーブル番号";
            this.Rotation_Table_Num.Name = "Rotation_Table_Num";
            this.Rotation_Table_Num.ToolTipText = "1";
            // 
            // Rotation_Value
            // 
            this.Rotation_Value.HeaderText = "数値";
            this.Rotation_Value.Name = "Rotation_Value";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.TranslationDelete);
            this.tabPage4.Controls.Add(this.TranslationAdd);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(720, 466);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "トランスレートテーブル";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // TranslationDelete
            // 
            this.TranslationDelete.Location = new System.Drawing.Point(143, 412);
            this.TranslationDelete.Name = "TranslationDelete";
            this.TranslationDelete.Size = new System.Drawing.Size(131, 48);
            this.TranslationDelete.TabIndex = 8;
            this.TranslationDelete.Text = "ﾄﾗﾝｽﾚｰｼｮﾝ削除";
            this.TranslationDelete.UseVisualStyleBackColor = true;
            this.TranslationDelete.Click += new System.EventHandler(this.TranslationDelete_Click);
            // 
            // TranslationAdd
            // 
            this.TranslationAdd.Location = new System.Drawing.Point(6, 412);
            this.TranslationAdd.Name = "TranslationAdd";
            this.TranslationAdd.Size = new System.Drawing.Size(131, 48);
            this.TranslationAdd.TabIndex = 7;
            this.TranslationAdd.Text = "ﾄﾗﾝｽﾚｰｼｮﾝ追加";
            this.TranslationAdd.UseVisualStyleBackColor = true;
            this.TranslationAdd.Click += new System.EventHandler(this.TranslationAdd_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Translation_Table_Num,
            this.Translation_Value});
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 21;
            this.dataGridView4.Size = new System.Drawing.Size(720, 406);
            this.dataGridView4.TabIndex = 0;
            // 
            // Translation_Table_Num
            // 
            this.Translation_Table_Num.HeaderText = "テーブル番号";
            this.Translation_Table_Num.Name = "Translation_Table_Num";
            // 
            // Translation_Value
            // 
            this.Translation_Value.HeaderText = "値";
            this.Translation_Value.Name = "Translation_Value";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.comboBox3);
            this.tabPage5.Controls.Add(this.comboBox2);
            this.tabPage5.Controls.Add(this.textBox2);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Controls.Add(this.comboBox1);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(720, 466);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "グラフ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(271, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(271, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "回転";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(271, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "倍率";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(329, 425);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(221, 35);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.Text = "選択してください";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(329, 386);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(221, 35);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "選択してください";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(115, 352);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 34);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(6, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "グラフの拡大倍率X,Y";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(9, 352);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 34);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "1";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 319);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 297);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(329, 345);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 35);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "選択してください";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "値変更時に押す";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.デバッグ);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(720, 466);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Option";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // デバッグ
            // 
            this.デバッグ.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.デバッグ.ForeColor = System.Drawing.SystemColors.WindowText;
            this.デバッグ.Location = new System.Drawing.Point(6, 68);
            this.デバッグ.Multiline = true;
            this.デバッグ.Name = "デバッグ";
            this.デバッグ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.デバッグ.Size = new System.Drawing.Size(708, 392);
            this.デバッグ.TabIndex = 0;
            this.デバッグ.Text = "開発者専用です\r\nDebuggerクラスを参照";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 234);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(158, 281);
            this.textBox3.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "グラフ値";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "デバッガー";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 549);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BCK_Editor Byぺんぐいん";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn XYZ_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frame_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tangent_Mode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TextBox デバッグ;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale_Value;
        public System.Windows.Forms.DataGridView dataGridView3;
        public System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Translation_Table_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Translation_Value;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Bone_Num;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox Txt_Roop_Mode;
        public System.Windows.Forms.TextBox Txt_Rot_Frac;
        public System.Windows.Forms.TextBox Total_Frame;
        private System.Windows.Forms.Button Add_Bone;
        private System.Windows.Forms.Button BoneDelete;
        private System.Windows.Forms.Button ScaleAdd;
        private System.Windows.Forms.Button ScaleDelete;
        private System.Windows.Forms.Button RotationDelete;
        private System.Windows.Forms.Button RotatinAdd;
        private System.Windows.Forms.Button TranslationDelete;
        private System.Windows.Forms.Button TranslationAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotation_Table_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotation_Value;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label10;
    }
}

