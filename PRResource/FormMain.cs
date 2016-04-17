using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace PRResource
{
  public partial class FormMain : Form
  {
    static public string m_tempPath;
    static public string m_strDownloadedFolderUrl;
    private readonly string m_strAppName = "RabbitPlayer";
    private const int m_nTopBarButtonsMargin = 20;
    private const int m_nTopBarButtonsWidth = 13;
    private bool m_bMainFormMouseDown = false;
    private bool m_bTopBarAreaMouseDown = false;
    private bool m_bTopEdge_MouseDown = false;
    private bool m_bLeftEdge_MouseDown = false;
    private bool m_bBottomEdge_MouseDown = false;
    private bool m_bRightEdge_MouseDown = false;
    private const int m_nEdgeMargin = 1;
    private const int m_nResizeableAreaSize = 10;
    private bool m_bLeftTopCornerMouseDown = false;
    private bool m_bLeftBottomCornerMouseDown = false;
    private bool m_bRightBottomCornerMouseDown = false;
    private bool m_bRightTopCornerMouseDown = false;
    private Point m_TopBarAreaMouseDownPos;
    private int m_nMinMainFormWidth = 1024;
    private int m_nMinMainFormHeight = 720;
    bool m_bFormLoaded = false;
    WebBrowserHandler m_webBrowserHandler;
    readonly int m_nWebCtrlPadding = 7;
    private readonly int m_nWebBroY = 70;
    public bool m_bShowLoading = false;
    private int m_nTimes = -1;
    bool m_bAskShare = false;

    public FormMain(string[] args)
    {
      if (args.Length > 0 && args[0] == "share")
        m_bAskShare = true;

      m_tempPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + m_strAppName;
      Directory.CreateDirectory(m_tempPath);
      m_strDownloadedFolderUrl = m_tempPath + "\\" + GlobalConstants.Common.strDownloadedFolderName;
      Directory.CreateDirectory(m_strDownloadedFolderUrl);

      if (!Archive.Load(m_tempPath))
      {
        MessageBox.Show("Can not find settings xml");
        return;
      }

      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\back.png");
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forward.png");

      if (Archive.mainFormLocX < 0)
        Archive.mainFormLocX = 0;
      if (Archive.mainFormLocY < 0)
        Archive.mainFormLocY = 0;
      this.Location = new Point(Archive.mainFormLocX, Archive.mainFormLocY);
      this.Size = new Size(Archive.mainFormWidth, Archive.mainFormHeight);

      if (Archive.maxed)
        this.WindowState = FormWindowState.Maximized;

      this.Size = new Size(Archive.mainFormWidth, Archive.mainFormHeight);

      m_webBrowserHandler = new WebBrowserHandler(this, new Point(m_nWebCtrlPadding, m_nWebBroY));
      ResizeWebCtrl();

      m_bFormLoaded = true; // OnMove will called before OnLoad when form borderStyle is none.
      this.OnMove(EventArgs.Empty);
      this.OnResize(EventArgs.Empty);

      if (m_bAskShare)
        m_webBrowserHandler.Navigate(false,GlobalConstants.Common.strOfficalWebsite);
      else
        button_dlChina1_Click(this, EventArgs.Empty);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      m_webBrowserHandler.Focus();
    }

    void ResizeWebCtrl()
    {
      int movieLibWidth = this.Width - m_nWebCtrlPadding * 2;
      int movieLibHeight = this.Height - m_nWebCtrlPadding * 2 - m_nWebBroY;
      m_webBrowserHandler.CtlSize = new Size(movieLibWidth, movieLibHeight);
    }

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label_Max_Click(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
    }

    private void label_Max_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\maxFocus.png");
      }
      catch { }
    }

    private void label_Max_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
      }
      catch { }
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
    }

    public void UpdateWebUrl()
    {
      XmlDocument xml = new XmlDocument();
      try
      {
        xml.Load(m_tempPath + "\\" + GlobalConstants.Common.strSetupSelfInfoXmlName);
      }
      catch (Exception e)
      {
        return;
      }

      XmlNode node = xml.SelectSingleNode("/setupSelfInfo/dl1");
      if (node != null)
      {
        GlobalConstants.Common.strChinaDl1 = node.InnerText;
      }
      else
      {
        return;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dl2");
      if (node != null)
      {
        GlobalConstants.Common.strChinaDl2 = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dlOversea");
      if (node != null)
      {
        GlobalConstants.Common.strOverseaDl = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dlSub");
      if (node != null)
      {
        GlobalConstants.Common.strSubtitle = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/onlineTv");
      if (node != null)
      {
        GlobalConstants.Common.strChinaOnline = node.InnerText;
      }
    }

    private void button_dlChina1_Click(object sender, EventArgs e)
    {
      UpdateWebUrl();
      ChangeNavButtonColor(GlobalConstants.Common.strChinaDl1);
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaDl1);
    }

    private void button_dlChina2_Click(object sender, EventArgs e)
    {
      UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaDl2);
      ChangeNavButtonColor(GlobalConstants.Common.strChinaDl2);
    }

    void ChangeNavBtnPos()
    {
      int btnY = button_dlOversea.Location.Y;
      int btnWidth = button_dlOversea.Width;
      int posOverseaX = this.Width / 2 - button_dlOversea.Width / 2;
      button_dlOversea.Location = new Point(posOverseaX, btnY);
      button_subtitle.Location = new Point(posOverseaX + btnWidth, btnY);
      button_onlineVideo.Location = new Point(posOverseaX + btnWidth * 2, btnY);
      button_dlChina2.Location = new Point(posOverseaX - btnWidth, btnY);
      button_dlChina1.Location = new Point(posOverseaX - btnWidth * 2, btnY);
    }

    private void button_onlineVideo_Click(object sender, EventArgs e)
    {
      UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaOnline);
      ChangeNavButtonColor(GlobalConstants.Common.strChinaOnline);
    }

    private void button_dlOversea_Click(object sender, EventArgs e)
    {
      UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strOverseaDl);
      ChangeNavButtonColor(GlobalConstants.Common.strOverseaDl);
    }

    private void button_subtitle_Click(object sender, EventArgs e)
    {
      UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strSubtitle);
      ChangeNavButtonColor(GlobalConstants.Common.strSubtitle);
    }

    private void ResetNavButtonColor()
    {
      button_dlChina1.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_dlChina2.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_onlineVideo.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_dlOversea.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_subtitle.BackColor = GlobalConstants.Common.colorMainBtnBG;
    }

    public void ChangeNavButtonColor(string strWebsite)
    {
      if (strWebsite == GlobalConstants.Common.strChinaDl1)
      {
        ResetNavButtonColor();
        button_dlChina1.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strChinaDl2)
      {
        ResetNavButtonColor();
        button_dlChina2.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strLocalPlay)
      {
        ResetNavButtonColor();
      }
      else if (strWebsite == GlobalConstants.Common.strOverseaDl
              || strWebsite == GlobalConstants.Common.strOverseaDl + "/index8.php")
      {
        ResetNavButtonColor();
        button_dlOversea.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strSubtitle)
      {
        ResetNavButtonColor();
        button_subtitle.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strChinaOnline)
      {
        ResetNavButtonColor();
        button_onlineVideo.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
    }

    private void label_back_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Back();
    }

    private void label_forward_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Forward();
    }

    private void label_back_MouseEnter(object sender, EventArgs e)
    {
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\backFocus.png");

    }

    private void label_back_MouseLeave(object sender, EventArgs e)
    {
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\back.png");
    }

    private void label_forward_MouseEnter(object sender, EventArgs e)
    {
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forwardFocus.png");
    }

    private void label_forward_MouseLeave(object sender, EventArgs e)
    {
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forward.png");
    }

    private void FormMain_Resize(object sender, EventArgs e)
    {
      if (!m_bFormLoaded)
        return;

      if (this.WindowState != FormWindowState.Maximized)
      {
        Archive.mainFormWidth = this.Width;
        Archive.mainFormHeight = this.Height;
      }

      label_Close.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonsWidth,
              label_Close.Location.Y);
      label_Max.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonsWidth * 2,
              label_Close.Location.Y);
      label_Min.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonsWidth * 3,
              label_Close.Location.Y);

      if (m_bMainFormMouseDown || m_bTopEdge_MouseDown || m_bLeftEdge_MouseDown
    || m_bBottomEdge_MouseDown || m_bRightEdge_MouseDown)
      {
        label_TopEdge.Visible = label_LeftEdge.Visible
            = label_BottomEdge.Visible = label_RightEdge.Visible = false;
      }
      else
      {
        UpdateEdge();
      }
      panel_neck.Size = new Size(this.Width - panel_neck.Location.X * 2, panel_neck.Height);
      ResizeWebCtrl();
      ChangeNavBtnPos();
    }

    private void panel_neck_Resize(object sender, EventArgs e)
    {
      int loadingX = panel_neck.Width / 2 - label_loading.Width / 2 + 8;
      int loadingY = label_loading.Location.Y;
      label_loading.Location = new Point(loadingX, loadingY);
      label_back.Location = new Point(loadingX - 48, loadingY);
      label_forward.Location = new Point(loadingX + 73, loadingY);
    }

    private void UpdateEdge()
    {
      label_TopEdge.Visible = label_LeftEdge.Visible
          = label_BottomEdge.Visible = label_RightEdge.Visible = true;

      label_TopEdge.Size
          = new Size(this.Size.Width - m_nEdgeMargin * 2,
              label_TopEdge.Size.Height);
      label_LeftEdge.Size
          = new Size(label_LeftEdge.Width,
              this.Size.Height - m_nEdgeMargin * 2 - label_TopEdge.Size.Height * 2);
      label_BottomEdge.Size
          = new Size(this.Size.Width - m_nEdgeMargin * 2,
              label_BottomEdge.Size.Height);
      label_RightEdge.Size
          = new Size(label_RightEdge.Width,
              this.Size.Height - m_nEdgeMargin * 2 - label_TopEdge.Size.Height * 2);

      label_BottomEdge.Location
          = new Point(label_BottomEdge.Location.X,
              this.Size.Height - m_nEdgeMargin - label_BottomEdge.Size.Height);
      label_RightEdge.Location
          = new Point(this.Size.Width - m_nEdgeMargin - label_RightEdge.Size.Width,
              label_RightEdge.Location.Y);
    }

    private void FormMain_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bRightBottomCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
        m_bLeftTopCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bLeftBottomCornerMouseDown = true;
      else if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
        m_bRightTopCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize)
        m_bLeftEdge_MouseDown = true;
      else if (e.Location.Y < m_nResizeableAreaSize)
        m_bTopEdge_MouseDown = true;
      else if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize)
        m_bRightEdge_MouseDown = true;
      else if (e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bBottomEdge_MouseDown = true;
      else
        m_bTopBarAreaMouseDown = true;

      m_TopBarAreaMouseDownPos = e.Location;
      m_bMainFormMouseDown = true;
    }

    private void FormMain_MouseUp(object sender, MouseEventArgs e)
    {
      m_bMainFormMouseDown = false;
      if (!label_TopEdge.Visible)
        UpdateEdge();

      m_bTopBarAreaMouseDown = m_bRightBottomCornerMouseDown = m_bLeftTopCornerMouseDown
        = m_bLeftBottomCornerMouseDown = m_bRightTopCornerMouseDown = m_bLeftEdge_MouseDown
        = m_bTopEdge_MouseDown = m_bRightEdge_MouseDown = m_bBottomEdge_MouseDown = false;
    }

    private void FormMain_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bTopBarAreaMouseDown)
      {
        int xDiff = e.X - m_TopBarAreaMouseDownPos.X;
        int yDiff = e.Y - m_TopBarAreaMouseDownPos.Y;
        this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
      }
      else
      {
        ShowResizebaleCursor(e);
        ResizeFrom(sender, e);
      }
    }

    private void ResizeFrom(object sender, MouseEventArgs e)
    {
      if (m_bRightBottomCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
        int yDiff = MouseScreenPoint.Y - (this.Location.Y + this.Size.Height);

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
      }
      else if (m_bLeftTopCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        int yDiff = this.Location.Y - MouseScreenPoint.Y;

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
        {
          this.Location = new Point(MouseScreenPoint.X, MouseScreenPoint.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
        }
      }
      else if (m_bLeftBottomCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        int yDiff = MouseScreenPoint.Y - (this.Location.Y + this.Size.Height);

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
        {
          this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
        }
      }
      else if (m_bRightTopCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
        int yDiff = this.Location.Y - MouseScreenPoint.Y;

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
        {
          if (yDiff != 0)
            this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
        }
      }
      else if (m_bLeftEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        if (this.Size.Width + xDiff > m_nMinMainFormWidth)
        {
          this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
        }
      }
      else if (m_bTopEdge_MouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int yDiff = this.Location.Y - MouseScreenPoint.Y;
        if (this.Size.Height + yDiff > m_nMinMainFormHeight)
        {
          this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
          this.Size = new Size(this.Size.Width, this.Size.Height + yDiff);
        }
      }
      else if (m_bRightEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
        if (this.Size.Width + xDiff > m_nMinMainFormWidth)
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
      }
      else if (m_bBottomEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScrrenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int newHeight = MouseScrrenPoint.Y - this.Location.Y;
        if (newHeight > m_nMinMainFormHeight)
          this.Size = new Size(this.Size.Width, newHeight);
      }
    }

    private void ShowResizebaleCursor(MouseEventArgs e)
    {
      if ((e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
      ||
      (e.Location.X < m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
      )
      {
        Cursor = Cursors.SizeNWSE;
      }
      else if ((e.Location.X < m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
          ||
          (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
          )
      {
        Cursor = Cursors.SizeNESW;
      }
      else if (e.Location.X < m_nResizeableAreaSize
        || e.Location.X >= this.Size.Width - m_nResizeableAreaSize)
      {
        Cursor = Cursors.SizeWE;
      }
      else if (e.Location.Y < m_nResizeableAreaSize ||
        e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
      {
        Cursor = Cursors.SizeNS;
      }
      else
      {
        Cursor = Cursors.Arrow;
      }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
        Archive.maxed = true;
      else
        Archive.maxed = false;

      Archive.Save();
    }

    private void FormMain_Move(object sender, EventArgs e)
    {
      if (!m_bFormLoaded)
        return;
      Archive.mainFormLocX = this.Location.X;
      Archive.mainFormLocY = this.Location.Y;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (m_bShowLoading)
      {
        ++m_nTimes;
        switch (m_nTimes)
        {
          case -1:
            label_loading.Text = "加载中";
            break;
          case 0:
            label_loading.Text = "加载中.";
            break;
          case 1:
            label_loading.Text = "加载中..";
            break;
          case 2:
            label_loading.Text = "加载中...";
            m_nTimes = -2;
            break;
        }
      }
      else
      {
        label_loading.Text = "";
        m_nTimes = -1;
      }
    }
  }
}
