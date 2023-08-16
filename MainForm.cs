// Decompiled with JetBrains decompiler
// Type: PBEncDec.MainForm
// Assembly: PB IP Editor, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: 2A30B96F-B852-4755-983D-E51DEB5529AA
// Assembly location: D:\GamesServer\PointBlank\PB IP Editor.exe

using PBEncDec.src.core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PBEncDec
{
  public class MainForm : Form
  {
    private IContainer components = (IContainer) null;
    private RichTextBox rtbValue;
    private Button btnOpen;
    private Button btnLoad;
    private Button btnSave;
    private TextBox tbPath;
    private RichTextBox testtext;
    private LinkLabel linkLabel1;

    public MainForm() => this.InitializeComponent();

    private void btnOpen_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == DialogResult.OK)
        this.tbPath.Text = openFileDialog.FileName;
      this.btnLoad_Click(sender, e);
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      if (this.tbPath.Text == null)
        return;
      string text = this.tbPath.Text;
      try
      {
        if (!File.Exists(text))
        {
          int num = (int) MessageBox.Show("Select the file!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          byte[] numArray = File.ReadAllBytes(text);
          string str1 = "";
          for (int index = 0; index < numArray.Length; ++index)
            str1 = str1 + (object) numArray[index] + " ";
          RichTextBox testtext = this.testtext;
          testtext.Text = testtext.Text + str1 + "\n\n";
          string str2 = "";
          Crypt.decrypt2(numArray, numArray.Length, 7);
          for (int index = 0; index < numArray.Length; ++index)
            str2 = str2 + (object) numArray[index] + " ";
          this.testtext.Text += str2;
          this.rtbValue.Text = Encoding.UTF8.GetString(numArray);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (this.tbPath.Text == null)
        return;
      string text = this.tbPath.Text;
      try
      {
        byte[] bytes = Encoding.UTF8.GetBytes(this.rtbValue.Text);
        Crypt.encrypt2(bytes, bytes.Length, 7);
        this.rtbValue.Text = Encoding.UTF8.GetString(bytes);
        File.WriteAllBytes(text, bytes);
        int num = (int) MessageBox.Show("File : " + text + " Saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.rtbValue = new RichTextBox();
      this.btnOpen = new Button();
      this.btnLoad = new Button();
      this.btnSave = new Button();
      this.tbPath = new TextBox();
      this.testtext = new RichTextBox();
      this.linkLabel1 = new LinkLabel();
      this.SuspendLayout();
      this.rtbValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.rtbValue.Location = new Point(12, 38);
      this.rtbValue.Name = "rtbValue";
      this.rtbValue.Size = new Size(666, 400);
      this.rtbValue.TabIndex = 0;
      this.rtbValue.Text = "";
      this.btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnOpen.Location = new Point(738, 10);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new Size(25, 23);
      this.btnOpen.TabIndex = 1;
      this.btnOpen.Text = "...";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
      this.btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnLoad.Location = new Point(684, 68);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new Size(79, 23);
      this.btnLoad.TabIndex = 2;
      this.btnLoad.Text = "Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
      this.btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.Location = new Point(684, 39);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(79, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.tbPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tbPath.Location = new Point(12, 12);
      this.tbPath.Name = "tbPath";
      this.tbPath.ReadOnly = true;
      this.tbPath.Size = new Size(720, 20);
      this.tbPath.TabIndex = 4;
      this.tbPath.Text = "lwsi_En.sif";
      this.testtext.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.testtext.Location = new Point(877, 207);
      this.testtext.Name = "testtext";
      this.testtext.Size = new Size(666, 397);
      this.testtext.TabIndex = 5;
      this.testtext.Text = "";
      this.testtext.Visible = false;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new Point(696, 425);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(67, 13);
      this.linkLabel1.TabIndex = 6;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "@FarisFreak";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(775, 447);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.testtext);
      this.Controls.Add((Control) this.tbPath);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnLoad);
      this.Controls.Add((Control) this.btnOpen);
      this.Controls.Add((Control) this.rtbValue);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "IP Editor";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
