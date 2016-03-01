using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RPlayer
{
  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
  class WebBrowserHandler
  {
     private WebBrowser webBrowser1;

    public WebBrowserHandler(MainForm formMain,Point startPoint)
    {
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

      // set the actual key
      RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
      int r = (int)Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
      if (r != RegVal)
        Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
      Key.Close();

      webBrowser1 = new WebBrowser();
      webBrowser1.Location = startPoint;
      webBrowser1.Size = new Size(1022, 600);
      webBrowser1.ScriptErrorsSuppressed = true;
      formMain.Controls.AddRange(new Control[] { webBrowser1 });
      webBrowser1.Navigate(new Uri("http://www.baidu.com/"));
      webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    }

    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);
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
          ele.SetAttribute("target", "_self");

          string strTarget = ele.GetAttribute("target");
          string strCla = ele.GetAttribute("title");

          //if (strTarget == "_self" && strCla == "分享到QQ空间")
          //  m_Shared = true;
        }
        ele = ele.Parent;
      }
    }
  }
}
