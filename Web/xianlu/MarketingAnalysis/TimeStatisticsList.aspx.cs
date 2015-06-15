﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Eyousoft.Common;
using EyouSoft.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Web.xianlu
{
    /// <summary>
    /// 页面功能：营销分析（时间统计）：查询，导出到Excel，统计图，打印
    /// Author：  liangx
    /// Date：    2010-1-18
    /// ------------------------------------------------------------------------
    /// 修改人：张新兵，修改时间：2011-01-21
    /// </summary>
    public partial class TimeStatisticsList : System.Web.UI.Page
    {
        #region Protected Members
        protected int PageIndex = 1;//页码
        protected int CurrentPage = 0;//当前页数
        protected int PageSize = 20;//每页显示的记录：20条
        protected int RecordCount = 0;//总记录
        protected string Month = string.Empty;//月份
        protected string SalesMan = string.Empty;   //销售员
        protected string SalesManId = string.Empty; //销售员id
        protected string PlanAM = string.Empty;     //计调员
        protected string PlanAMId = string.Empty;     //计调员id
        protected string TimeStar1;                //开始时间
        protected string TimeEnd1;                 //结束时间
        protected string IsExcel = string.Empty;    //是否导出
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IsExcel"] != null && Request.QueryString["IsExcel"].ToString() == "1")
            {
                IList<string> list = new List<string>();

                ToExcel(this.CustomRepeater3, list);
            }
            string isGetXml = Utils.GetQueryStringValue("getXml");
            if (isGetXml == "1")
            {
                Response.Clear();
                Response.Write(FusionChartsFree());
                Response.End();
            }
            if(!Page.IsPostBack)
            {
                BindTimeList();
            }
        }

        #region 时间统计列表信息
        public void BindTimeList()
        {
            Month = Utils.InputText(Request.QueryString["Month"]);
            SalesMan = Utils.InputText(Request.QueryString["Xiaosy"]);
            SalesManId = Utils.InputText(Server.UrlDecode(Request.QueryString["XiaosyId"]));
            PlanAM = Utils.InputText(Request.QueryString["Jidy"]);
            PlanAMId = Utils.InputText(Request.QueryString["JidyId"]);
            TimeStar1 = Utils.InputText(Request.QueryString["TimeStar"]);
            TimeEnd1 = Utils.InputText(Request.QueryString["TimeEnd"]);

            //调用获取列表集合的方法
            // 绑定分页控件
            this.ExportPageInfo1.CurrencyPage = PageIndex;
            this.ExportPageInfo1.intPageSize = PageSize;
            this.ExportPageInfo1.intRecordCount = RecordCount;
            this.ExportPageInfo1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExportPageInfo1.UrlParams = Request.QueryString;
        }
        #endregion 


        #region ExportToExcel
        public void ToExcel(System.Web.UI.Control ctl, IList<string> TimeStatisticeList)
        {

            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=时间统计.xls");

            HttpContext.Current.Response.Charset = "UTF-8";

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;

            HttpContext.Current.Response.ContentType = "application/ms-excel";

            ctl.Page.EnableViewState = false;

            StringWriter sw = new StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 时间统计图
        public string FusionChartsFree()
        {
            IList<TimeStatistic> list = new List<TimeStatistic>();//数据源
            list.Add(new TimeStatistic()
            {
                Month = "10月",
                PersonNum = "100",
                Day = 10
            });
            list.Add(new TimeStatistic()
            {
                Month = "1月",
                PersonNum = "354",
                Day = 50
            });
            //string GetFree = string.Empty;
            StringBuilder strXml = new StringBuilder();
            StringBuilder strCategory = new StringBuilder("<categories>");
            StringBuilder strDataSet = new StringBuilder("<dataset seriesname='人数' color='F0807F' showValue='1'>");
            StringBuilder strDataSetDay = new StringBuilder("<dataset seriesname='人天数' color='B22222' showValue='1'>");
            strXml.Append(@"<graph xAxisName='月份' yAxisName='人数/人天数' canvasBgColor='F6DFD9' canvasBaseColor='FE6E54' hovercapbgColor='FFECAA' hovercapborder='F47E00' divlinecolor='F47E00' limitsDecimalPrecision='0' divLineDecimalPrecision='0'>");

            for (int i = 0; i < list.Count; i++)
            {
                strCategory.Append(@"<category name='" + list[i].Month.ToString() + "' hoverText='" + list[i].Month.ToString() + "'/>");
                //人数
                strDataSet.Append(@"<set value='" + list[i].PersonNum.ToString() + "' />");
                //人天数
                strDataSetDay.Append(@"<set value='" + list[i].Day.ToString() + "' />");
            }
            strCategory.Append("</categories>");
            strDataSet.Append("</dataset>");
            strDataSetDay.Append("</dataset>");
            strXml.Append(strCategory.ToString());
            strXml.Append(strDataSet.ToString());
            strXml.Append(strDataSetDay.ToString());
            strXml.Append(@"</graph>");
            return strXml.ToString();
        }
        #endregion

        public class TimeStatistic
        {
            public string Month { get; set; }//月份
            public string PersonNum { get; set; }//人数
            public int Day { get; set; }//天数
        }
    }
}
