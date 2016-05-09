<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.infol = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Custumbottom1 = New custumbuttom.custumbottom()
        Me.settingBt = New custumbuttom.custumbottom()
        Me.searchBt = New custumbuttom.custumbottom()
        Me.connectBt = New custumbuttom.custumbottom()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.disconnectBt = New custumbuttom.custumbottom()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.searchbackground = New System.ComponentModel.BackgroundWorker()
        Me.searchLoader = New System.Windows.Forms.PictureBox()
        Me.connectBackground = New System.ComponentModel.BackgroundWorker()
        Me.connectLoader = New System.Windows.Forms.PictureBox()
        Me.stopConnect = New custumbuttom.custumbottom()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.loaderBackground = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.getIPbackground = New System.ComponentModel.BackgroundWorker()
        CType(Me.searchLoader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.connectLoader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'infol
        '
        resources.ApplyResources(Me.infol, "infol")
        Me.infol.BackColor = System.Drawing.Color.Transparent
        Me.infol.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.infol.Name = "infol"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Name = "Label1"
        '
        'Custumbottom1
        '
        Me.Custumbottom1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Custumbottom1, "Custumbottom1")
        Me.Custumbottom1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Custumbottom1.FlatAppearance.BorderSize = 0
        Me.Custumbottom1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Custumbottom1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Custumbottom1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Custumbottom1.Name = "Custumbottom1"
        Me.Custumbottom1.UseVisualStyleBackColor = False
        '
        'settingBt
        '
        Me.settingBt.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.settingBt, "settingBt")
        Me.settingBt.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.settingBt.FlatAppearance.BorderSize = 0
        Me.settingBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.settingBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.settingBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.settingBt.Name = "settingBt"
        Me.settingBt.UseVisualStyleBackColor = False
        '
        'searchBt
        '
        resources.ApplyResources(Me.searchBt, "searchBt")
        Me.searchBt.BackColor = System.Drawing.Color.Transparent
        Me.searchBt.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.searchBt.FlatAppearance.BorderSize = 0
        Me.searchBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.searchBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.searchBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.searchBt.Name = "searchBt"
        Me.searchBt.UseVisualStyleBackColor = False
        '
        'connectBt
        '
        Me.connectBt.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.connectBt, "connectBt")
        Me.connectBt.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.connectBt.FlatAppearance.BorderSize = 0
        Me.connectBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.connectBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.connectBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.connectBt.Name = "connectBt"
        Me.connectBt.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Gainsboro
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Gainsboro
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'disconnectBt
        '
        Me.disconnectBt.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.disconnectBt, "disconnectBt")
        Me.disconnectBt.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.disconnectBt.FlatAppearance.BorderSize = 0
        Me.disconnectBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.disconnectBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.disconnectBt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.disconnectBt.Name = "disconnectBt"
        Me.disconnectBt.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 10
        '
        'ComboBox1
        '
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2"), resources.GetString("ComboBox1.Items3"), resources.GetString("ComboBox1.Items4"), resources.GetString("ComboBox1.Items5"), resources.GetString("ComboBox1.Items6"), resources.GetString("ComboBox1.Items7"), resources.GetString("ComboBox1.Items8"), resources.GetString("ComboBox1.Items9"), resources.GetString("ComboBox1.Items10"), resources.GetString("ComboBox1.Items11"), resources.GetString("ComboBox1.Items12"), resources.GetString("ComboBox1.Items13"), resources.GetString("ComboBox1.Items14")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'searchbackground
        '
        Me.searchbackground.WorkerReportsProgress = True
        Me.searchbackground.WorkerSupportsCancellation = True
        '
        'searchLoader
        '
        resources.ApplyResources(Me.searchLoader, "searchLoader")
        Me.searchLoader.BackColor = System.Drawing.Color.Transparent
        Me.searchLoader.Image = Global.unblockDoom.My.Resources.Resources.ajax_loader
        Me.searchLoader.Name = "searchLoader"
        Me.searchLoader.TabStop = False
        '
        'connectBackground
        '
        Me.connectBackground.WorkerReportsProgress = True
        Me.connectBackground.WorkerSupportsCancellation = True
        '
        'connectLoader
        '
        resources.ApplyResources(Me.connectLoader, "connectLoader")
        Me.connectLoader.BackColor = System.Drawing.Color.Transparent
        Me.connectLoader.Image = Global.unblockDoom.My.Resources.Resources.ajax_loader
        Me.connectLoader.Name = "connectLoader"
        Me.connectLoader.TabStop = False
        '
        'stopConnect
        '
        Me.stopConnect.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.stopConnect, "stopConnect")
        Me.stopConnect.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.stopConnect.FlatAppearance.BorderSize = 0
        Me.stopConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.stopConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.stopConnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.stopConnect.Name = "stopConnect"
        Me.stopConnect.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.unblockDoom.My.Resources.Resources.form
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'loaderBackground
        '
        Me.loaderBackground.WorkerReportsProgress = True
        Me.loaderBackground.WorkerSupportsCancellation = True
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Name = "Label6"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.unblockDoom.My.Resources.Resources.ajax_loader
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Name = "Label7"
        '
        'getIPbackground
        '
        Me.getIPbackground.WorkerReportsProgress = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.stopConnect)
        Me.Controls.Add(Me.connectLoader)
        Me.Controls.Add(Me.searchLoader)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.disconnectBt)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.connectBt)
        Me.Controls.Add(Me.searchBt)
        Me.Controls.Add(Me.settingBt)
        Me.Controls.Add(Me.Custumbottom1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.infol)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.TransparencyKey = System.Drawing.Color.Red
        CType(Me.searchLoader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.connectLoader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents infol As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Custumbottom1 As custumbuttom.custumbottom
    Friend WithEvents settingBt As custumbuttom.custumbottom
    Friend WithEvents searchBt As custumbuttom.custumbottom
    Friend WithEvents connectBt As custumbuttom.custumbottom
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents disconnectBt As custumbuttom.custumbottom
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents searchbackground As System.ComponentModel.BackgroundWorker
    Friend WithEvents searchLoader As System.Windows.Forms.PictureBox
    Friend WithEvents connectBackground As System.ComponentModel.BackgroundWorker
    Friend WithEvents connectLoader As System.Windows.Forms.PictureBox
    Friend WithEvents stopConnect As custumbuttom.custumbottom
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents loaderBackground As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents getIPbackground As System.ComponentModel.BackgroundWorker

End Class
