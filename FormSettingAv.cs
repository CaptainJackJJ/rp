using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPlayer
{
    public partial class FormSettingAv : Form
    {
      private FormSettings m_formSettings;
      public FormSettingAv(FormSettings formSettings)
        {
          m_formSettings = formSettings;
            InitializeComponent();
            SetUiLange();
            this.ShowInTaskbar = false;
        }

        public void SetAllUiLange()
        {
          SetUiLange();
        }

        private void SetUiLange()
        {

        }
    }
}
