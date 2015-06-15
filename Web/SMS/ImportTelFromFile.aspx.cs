﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;
namespace Web.SMS
{   
    /// <summary>
    /// 从文件导入手机号
    /// xuty 2011/24
    /// </summary>
    public partial class ImportTelFromFile : Eyousoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(global::Common.Enum.TravelPermission.短信中心_短信中心_栏目))
            {
                Utils.ResponseNoPermit(global::Common.Enum.TravelPermission.短信中心_短信中心_栏目, true);
                return;
            }
        }
    }
}
