using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Windows.Forms;
using MB.Controls;

namespace RPlayer
{
  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
  public class WebBrowserHandler
  {
    private WebBrowser webBrowser1;
    private Uri m_LastUri = null;
    private MainForm m_formMain;

    public WebBrowserHandler(MainForm formMain, Point startPoint)
    {
      m_formMain = formMain;

      int BrowserVer, RegVal;

      // get the installed IE version
      using (WebBrowser Wb = new WebBrowser())
        BrowserVer = Wb.Version.Major;

      // set the appropriate IE version
      if (BrowserVer >= 11)
        RegVal = 11001;
      else if (BrowserVer == 10)
        RegVal = 10001;
      else if (BrowserVer == 9)
        RegVal = 9999;
      else if (BrowserVer == 8)
        RegVal = 8888;
      else
        RegVal = 7000;

      //if(RegVal > 8888)
      //{
      //  GlobalConstants.Common.strChinaDl1 = "http://www.chdw.org/";
      //  GlobalConstants.Common.strChinaDl2 = "http://www.xiagaoqing.com/";
      //  GlobalConstants.Common.strChinaDl3 = "http://gaoqing.la/";
      //}
      //else
      //{
        GlobalConstants.Common.strChinaDl1 = "http://www.xiagaoqing.com/";
        GlobalConstants.Common.strChinaDl2 = "http://www.chdw.org/";
        GlobalConstants.Common.strChinaDl3 = "http://gaoqing.la/";
      //}

      // set the actual key
      RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
      string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
      object value = Key.GetValue(strProcessName);
      if (value == null || (int)value != RegVal)
        Key.SetValue(strProcessName, RegVal, RegistryValueKind.DWord);
      Key.Close();

      webBrowser1 = new WebBrowser();
      webBrowser1.Location = startPoint;
      webBrowser1.Size = new Size(1010, 590);
      webBrowser1.ScriptErrorsSuppressed = true;
      formMain.Controls.AddRange(new Control[] { webBrowser1 });      
      webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
      webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(ProgressChanged);
      webBrowser1.NewWindow += webBrowser1_NewWindow;
    }

    void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
    {
      WebBrowser wb = (sender as WebBrowser);
      string strStatusText = wb.StatusText;

      if (strStatusText.Contains("rabbitplayer") || strStatusText.Contains("prplayer")// for share
        || strStatusText.Contains("www.chdw.org") || strStatusText.Contains("pan.baidu.com")) // for torrent wei.yuan share
        e.Cancel = false;
      else
        e.Cancel = true;
      
      if (strStatusText.Contains("magnet")
        || strStatusText.Contains("http://sub.makedie.me/"))
      {
        webBrowser1.Navigate(strStatusText);
      }
    }

    public void Focus()
    {
      if (webBrowser1 != null && webBrowser1.Document != null && !webBrowser1.Document.Focused)
      {
        webBrowser1.Document.Focus();
      }
    }

    private void ProgressChanged(Object sender, WebBrowserProgressChangedEventArgs e)
    {
      if (e.CurrentProgress < e.MaximumProgress)
      {
        m_formMain.m_bShowLoading = true;
      }
      else
      {
        m_formMain.m_bShowLoading = false;     
      }
    }

    public void Navigate(bool bLastUri,string url)
    {
      if (m_formMain.m_bNeedShared && !(url.Contains("rabbitplayer") || url.Contains("prplayer")))
      {
        FormAskShare f = new FormAskShare(m_formMain);
        f.ShowDialog();
        return;
      }

      if (bLastUri)
      {
        if (m_LastUri == null)
          m_LastUri = new Uri(GlobalConstants.Common.strChinaDl1);
        webBrowser1.Navigate(m_LastUri);
      }
      else
      {
        webBrowser1.Navigate("about:blank");
        m_LastUri = new Uri(url);
        webBrowser1.Navigate(m_LastUri);
      }
    }

    private bool IsTopPage()
    {
      if (m_LastUri.ToString() == GlobalConstants.Common.strChinaDl1
        || m_LastUri.ToString() == GlobalConstants.Common.strChinaOnline
        || m_LastUri.ToString() == GlobalConstants.Common.strOverseaDl
        || m_LastUri.ToString() == GlobalConstants.Common.strSubtitle)
      { return true; }
      else
        return false;
    }

    public void Forward()
    {
      webBrowser1.GoForward();
    }
    
    public void Back()
    {
      webBrowser1.GoBack();
    }

    public void Stop()
    {
      m_LastUri = webBrowser1.Url;
      webBrowser1.Navigate("about:blank");
    }

    public void Show(bool bShow)
    {
      webBrowser1.Visible = bShow;
    }

    void HideElem(string outerText)
    {
      HtmlElementCollection hc = webBrowser1.Document.Body.Children;

      try
      {
        HtmlElement he = hc[8].Children[0];
        if (he.OuterHtml.Contains(outerText))
        {
          he.Style = "display: none;";
          //he.OuterHtml = "";
        }
      }
      catch{ }
    }

    void HideElemById(string id)
    {
      HtmlElement he1 = webBrowser1.Document.GetElementById(id);
      if (he1 != null)
      {
        he1.Style = "display: none;";
      }
    }

    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (e.Url.ToString() == "about:blank")
        return;

      m_formMain.ChangeWebButtonColor(e.Url.ToString());

      webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);

      if (e.Url.ToString().Contains("http://www.xiagaoqing.com"))
      {
        try
        {// for http://www.xiagaoqing.com/
          HtmlElementCollection hec2 = webBrowser1.Document.Body.Children;
          hec2[5].Children[1].Style = "display: none;";
          hec2[8].Style = "display: none;";
        }
        catch { }
      }

      if (e.Url.ToString().Contains("http://www.chdw.org/"))
      {
        HideElemById("masthead");
        //this.webBrowser1.Document.Body.Style = "zoom:1.4";
        //try
        //{
        //  HtmlElementCollection hec = webBrowser1.Document.GetElementsByTagName("img");
        //  foreach (HtmlElement he in hec)
        //  {
        //    if (he.OuterHtml.Contains("http://www.chdw.org/wp-content/themes/begin/img/logo.png"))
        //    {
        //      he.Style = "display: none;";
        //      break;
        //    }
        //  }
        //}
        //catch { }
      }

      if (!(e.Url.ToString().Contains("rabbitplayer") || e.Url.ToString().Contains("prplayer")))
      {
        HideElemById("advert-1");
        HideElemById("advert-2");
        HideElemById("advert-3");
        HideElemById("advert-4");
        HideElemById("links");
        HideElemById("colophon");
        //HideElemById("social");
        HideElemById("shang");
        HideElemById("respond");
        HideElemById("search-3");
        HideElemById("head");
        HideElemById("footer");

        HtmlElement he1 = webBrowser1.Document.GetElementById("sidebar");
        if (he1 != null)
        {
          if (!e.Url.ToString().Contains("http://www.chdw.org/"))
            he1.Style = "display: none;";
        }

        he1 = webBrowser1.Document.GetElementById("topbar"); 
        if (he1 != null)
        {
          if (he1.Parent != null && he1.Parent.Parent != null)
            he1.Parent.Parent.Style = "display: none;";
        }

        HideElem("站点公告");

        HtmlElementCollection hec = webBrowser1.Document.GetElementsByTagName("iframe");
        foreach (HtmlElement he in hec)
        {
          he.OuterHtml = "";
        }
      }   
    }

    void Document_Click(object sender, HtmlElementEventArgs e)
    {
      HtmlElement ele = webBrowser1.Document.ActiveElement;
      while (ele != null)
      {
        if (ele.TagName.ToLower() == "a")
        {
          //// METHOD-1
          //// Use the url to open a new tab
          //string url = ele.GetAttribute("href");
          //// TODO: open the new tab
          //e.ReturnValue = false;

          //string url = ele.GetAttribute("href");
          //if(url != "")
          //  webBrowser1.Navigate(new Uri(url));

          // METHOD-2
          // Use this to make it navigate to the new URL on the current browser/tab

          if (ele.OuterText != "种子下载") // for http://www.chdw.org/
            ele.SetAttribute("target", "_self");

          string strUrl = ele.Document.Url.ToString();
          if ((strUrl.Contains("rabbitplayer") || strUrl.Contains("prplayer"))
            && !ele.OuterHtml.Contains("downBtn"))
          {
            m_formMain.m_bNeedShared = false;
            AppShare.SetGetShared(MainForm.m_tempPath, true);
          }
        }
        ele = ele.Parent;
      }
    }
  }
}
