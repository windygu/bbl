﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Webmaster
{
    /// <summary>
    /// webmaster logout page
    /// </summary>
    /// Author:汪奇志 2011-04-15
    public partial class logout : WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.Logout();
        }
    }
}
