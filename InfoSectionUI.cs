using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace RPlayer
{
  class InfoSectionUI
  {
    private Panel m_panelSection;
    private Button[] m_buttonCategorys;
    private int m_nBtnCategoryCount;
    private InfoItemUI[] m_infoItemUI;
    private int m_nInfoItemUICount;
    private string m_strSelectedCateType;
    private Form m_FormOwner;
    private bool m_bInited;
    FormInfoMore m_formInfoMore;
    InfoLocalXmlHandler m_infoLocalXmlHandler;
    private bool m_bInfoMore;
    private Label m_labelUpPage;
    private Label m_labelNextPage;
    private Label m_labelPages;
    private int m_nPages;
    private Dictionary<string, int> m_dicPageCur;
    private readonly string m_strUpPageText = "上一页";
    private readonly string m_strNextPageText = "下一页";

    public InfoSectionUI(Form formOwner, InfoLocalXmlHandler infoLocalXmlHandler)
    {
      m_nPages = 0;
      m_dicPageCur = new Dictionary<string, int>();

      if (formOwner as FormInfoMore != null)
      {
        m_bInfoMore = true;
        m_nInfoItemUICount = 4;
        m_nBtnCategoryCount = 2;
      }
      else
      {
        m_bInfoMore = false;
        m_nInfoItemUICount = 2;
        m_nBtnCategoryCount = 3;
      }

      m_FormOwner = formOwner;
      m_infoLocalXmlHandler = infoLocalXmlHandler;
      m_formInfoMore = null;
      Init();
    }

    private void ChangeSeletedCate(string strCateType)
    {
      if (strCateType != m_strSelectedCateType)
      {
        m_strSelectedCateType = strCateType;
        foreach (Button btn in m_buttonCategorys)
        {
          if (btn.Tag as string == m_strSelectedCateType)
            btn.BackColor = GlobalConstants.Common.colorBtnSelected;
          else
            btn.BackColor = GlobalConstants.Common.colorMainBG;
        }

        FreshItems();
      }
    }

    private void btn_category_Click(object sender, EventArgs e)
    {
      if ((sender as Button).Text == GlobalConstants.Common.strMoreInfoText)
      {
        if(m_formInfoMore ==  null)
          m_formInfoMore = new FormInfoMore();
        m_formInfoMore.Show();
        return;
      }
      ChangeSeletedCate((sender as Button).Tag as string);
    }

    private void label_SwitchPage_Click(object sender, EventArgs e)
    {
      if ((sender as Label).Text == m_strUpPageText)
      {
        if (m_dicPageCur[m_strSelectedCateType] <= 1)
          return;
        m_dicPageCur[m_strSelectedCateType]--;
      }
      else
      {
        if (m_dicPageCur[m_strSelectedCateType] >= m_nPages)
          return;
        m_dicPageCur[m_strSelectedCateType]++;
      }
      FreshItems();
    }

    private void Init()
    {
      if (m_infoLocalXmlHandler.m_xml == null || m_bInited)
        return;

      m_bInited = true;

      m_panelSection = new Panel();
      if (m_bInfoMore)
      {
        m_panelSection.Location = new Point(0, 0);
        m_panelSection.Size = new Size(911, 720);

        m_labelUpPage = new Label();
        m_labelUpPage.Location = new Point(571, 18);
        m_labelUpPage.Size = new Size(41, 16);
        m_labelUpPage.ForeColor = Color.Snow;
        m_labelUpPage.Text = m_strUpPageText;
        m_labelUpPage.Click += new System.EventHandler(label_SwitchPage_Click);
        m_panelSection.Controls.Add(m_labelUpPage);

        m_labelNextPage = new Label();
        m_labelNextPage.Location = new Point(659, 18);
        m_labelNextPage.Size = new Size(41, 16);
        m_labelNextPage.ForeColor = Color.Snow;
        m_labelNextPage.Text = m_strNextPageText;
        m_labelNextPage.Click += new System.EventHandler(label_SwitchPage_Click);
        m_panelSection.Controls.Add(m_labelNextPage);

        m_labelPages = new Label();
        m_labelPages.Location = new Point(611, 19);
        m_labelPages.Size = new Size(52, 12);
        m_labelPages.ForeColor = Color.Snow;
        m_labelPages.TextAlign = ContentAlignment.MiddleCenter;
        m_panelSection.Controls.Add(m_labelPages);
      }
      else
      {
        m_panelSection.Location = new Point(0, 33);
        m_panelSection.Size = new Size(911, 491);
      }

      XmlNodeList categoryElems = m_infoLocalXmlHandler.m_xml.GetElementsByTagName(GlobalConstants.infoXml.strElemCategory);
      m_buttonCategorys = new Button[m_nBtnCategoryCount];
      for (int i = 0; i < m_nBtnCategoryCount; ++i)
      {
        if (i > categoryElems.Count)
          break;
        Button btn = new Button();
        m_buttonCategorys[i] = btn;
        btn.BackColor = GlobalConstants.Common.colorMainBG;
        btn.FlatStyle = FlatStyle.Flat;
        btn.Font = new Font("SimSun", 12.0f, FontStyle.Bold);
        btn.ForeColor = GlobalConstants.Common.colorNormalText;
        int x;
        if (m_bInfoMore) x = 363; else x = 318;
        btn.Location = new Point(x + i * 93, 0);
        btn.Size = new Size(93, 34);
        btn.Click += new System.EventHandler(btn_category_Click);
        if (i == categoryElems.Count)
        {
          btn.Text = GlobalConstants.Common.strMoreInfoText;
          btn.Tag = "more";
        }
        else
        {
          btn.Text = categoryElems[i].Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText;
          string type = categoryElems[i].Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
          btn.Tag = type;

          m_dicPageCur.Add(type,1);
        }
        m_panelSection.Controls.Add(btn);       
      }

      m_infoItemUI = new InfoItemUI[m_nInfoItemUICount];
      XmlNodeList itemNodes = categoryElems[0].ChildNodes;
      for (int i = 0; i < m_nInfoItemUICount; ++i)
      {
        int y;
        if (i < 2)
          y = 36;
        else
          y = 374;
        InfoItemUI itemUI = new InfoItemUI(m_panelSection, 12 + i % 2 * 445, y,m_bInfoMore);
        m_infoItemUI[i] = itemUI;
      }

      ChangeSeletedCate(categoryElems[0].Attributes[GlobalConstants.infoXml.strAttrType].InnerText);

      m_FormOwner.Controls.Add(m_panelSection);
    }

    public void ShowSection(bool bShow)
    {
      if (!m_bInited)
        return;
      m_panelSection.Visible = bShow;
    }

    public void FreshItems()
    {
      if (!m_bInited)
        Init();

      XmlNodeList categoryElems = m_infoLocalXmlHandler.m_xml.GetElementsByTagName(GlobalConstants.infoXml.strElemCategory);
      XmlNodeList itemNodes = null;
      foreach (XmlNode cateNode in categoryElems)
      {
        string strCateType = cateNode.Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
        if (strCateType == m_strSelectedCateType)
        {
          itemNodes = cateNode.ChildNodes;
          break;
        }
      }

      if (itemNodes == null)
      {
        CoreWrapper.Core.WriteLog(CoreWrapper.Core.ELogType.error, "FreshInfoItemUI: itemNodes == null");
        return;
      }

      if (m_bInfoMore)
      {
        m_nPages = itemNodes.Count / m_nInfoItemUICount;
        if (itemNodes.Count % m_nInfoItemUICount != 0)
          ++m_nPages;
        m_labelPages.Text = m_dicPageCur[m_strSelectedCateType].ToString() + "/" + m_nPages.ToString();
      }

      int nPageCurIndex = m_dicPageCur[m_strSelectedCateType] - 1;

      for (int i = 0; i < m_nInfoItemUICount; ++i)
      {
        InfoItemUI itemUI = m_infoItemUI[i];
        itemUI.m_groupBoxItem.Visible = false;
        int nItemIndex = nPageCurIndex * m_nInfoItemUICount + i;
        if (nItemIndex >= itemNodes.Count)
          continue;
        itemUI.FreshItem((XmlElement)itemNodes[nItemIndex]);
      }
    }
  }
}
