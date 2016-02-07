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
    private readonly int m_nBtnCategoryCount = 2;
    private InfoItemUI[] m_infoItemUI;
    private readonly int m_nInfoItemUICount = 2;
    private string m_strSelectedCateType;
    private MainForm m_mainForm;
    private bool m_bInited;

    public InfoSectionUI(MainForm mainForm)
    {
      m_mainForm = mainForm;
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
      ChangeSeletedCate((sender as Button).Tag as string);
    }

    private void Init()
    {
      if (InfoLocalXmlHandler.m_xml == null || m_bInited)
        return;

      m_bInited = true;

      m_panelSection = new Panel();
      m_panelSection.Location = new Point(0, 33);
      m_panelSection.Size = new Size(911, 491);

      XmlNodeList categoryElems = InfoLocalXmlHandler.m_xml.GetElementsByTagName(GlobalConstants.infoXml.strElemCategory);
      m_buttonCategorys = new Button[m_nBtnCategoryCount];
      for (int i = 0; i < m_nBtnCategoryCount; ++i)
      {
        if (i >= categoryElems.Count)
          break;
        Button btn = new Button();
        m_buttonCategorys[i] = btn;
        btn.BackColor = GlobalConstants.Common.colorMainBG;
        btn.FlatStyle = FlatStyle.Flat;
        btn.Font = new Font("SimSun", 12.0f, FontStyle.Bold);
        btn.ForeColor = GlobalConstants.Common.colorNormalText;
        btn.Location = new Point(363 + i * 93, 0);
        btn.Size = new Size(93, 34);
        btn.Click += new System.EventHandler(btn_category_Click);
        btn.Text = categoryElems[i].Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText;
        btn.Tag = categoryElems[i].Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
        m_panelSection.Controls.Add(btn);
      }

      m_infoItemUI = new InfoItemUI[m_nInfoItemUICount];
      XmlNodeList itemNodes = categoryElems[0].ChildNodes;
      for (int i = 0; i < m_nInfoItemUICount; ++i)
      {
        if (i >= itemNodes.Count)
          break;
        InfoItemUI itemUI = new InfoItemUI(m_panelSection, 12 + i * 445, 36);
        m_infoItemUI[i] = itemUI;
      }

      ChangeSeletedCate(categoryElems[0].Attributes[GlobalConstants.infoXml.strAttrType].InnerText);

      m_mainForm.Controls.Add(m_panelSection);
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

      XmlNodeList categoryElems = InfoLocalXmlHandler.m_xml.GetElementsByTagName(GlobalConstants.infoXml.strElemCategory);
      XmlNodeList itemNodes = null;
      foreach (XmlNode cateNode in categoryElems)
      {
        string strCateType = cateNode.Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
        if (strCateType == m_strSelectedCateType)
        {
          itemNodes = cateNode.ChildNodes;
        }
      }

      if (itemNodes == null)
      {
        CoreWrapper.Core.WriteLog(CoreWrapper.Core.ELogType.error, "FreshInfoItemUI: itemNodes == null");
      }

      for (int i = 0; i < m_nInfoItemUICount; ++i)
      {
        if (i >= itemNodes.Count)
          break;
        InfoItemUI itemUI = m_infoItemUI[i];
        itemUI.FreshItem((XmlElement)itemNodes[i]);
      }
    }
  }
}
