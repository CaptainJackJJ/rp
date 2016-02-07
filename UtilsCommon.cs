using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPlayer
{
  class UtilsCommon
  {
    static public bool IsNewVersion(string strCompared, string strCompareWith)
    {
      if (strCompared == "" || strCompareWith == "")
        MessageBox.Show("IsNewVersion get wrong agru");

      string[] strAarryCompared = strCompared.Split('.');
      string[] strAarryCompareWith = strCompareWith.Split('.');
      uint nIndex = 0;
      foreach (string strComparedItem in strAarryCompared)
      {
        UInt32 nCompared = Convert.ToUInt32(strComparedItem);
        UInt32 nComparedWith = Convert.ToUInt32(strAarryCompareWith[nIndex++]);
        if (nCompared > nComparedWith)
          return true;
        else if(nCompared == nComparedWith)
          continue;
        else
          return false;
      }
      return false;
    }
  }
}
