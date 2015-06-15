﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using System.IO;
using Common.Enum;
using EyouSoft.BLL.CompanyStructure;
using System.Text;

namespace Web.TeamPlan
{
    /// <summary>
    /// 团队计划标准版发布
    /// 功能：普通发布团队计划
    /// 创建人：戴银柱
    /// 创建时间： 2011-01-13 
    /// </summary>
    /// 修改时间：2011-06-30 
    /// 修改人：柴逸宁
    /// 修改备注：添加集合时间的时间部分
    /// 修改时间：2011.7.12
    /// 修改人：田想兵
    /// 修改备注：人数和单价配置
    public partial class StandardVersion : Eyousoft.Common.Page.BackPage
    {
        /// <summary>
        /// 人数配置 by 田想兵2011.7.12
        /// </summary>
        protected int NumConfig = 0;
        protected string strTraffic = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断栏目权限
            if (!CheckGrant(TravelPermission.团队计划_团队计划_栏目))
            {
                Utils.ResponseNoPermit(TravelPermission.团队计划_团队计划_栏目, false);
                return;
            }
            if (!IsPostBack)
            {
                BindDefaultValue();
                NumConfig = (int)(new EyouSoft.BLL.CompanyStructure.CompanySetting().GetTeamNumberOfPeople(CurrentUserCompanyID));
                //操作类型：copy=复制   update = 修改 add = 添加
                string type = Utils.GetQueryStringValue("type");
                //团队计划的编号
                string id = Utils.GetQueryStringValue("id");
                //设置线路用户控件的JS方法
                this.xianluWindow1.callBack = "StandardVersion.AjaxGetLineInfo";
                //设置发布类型
                this.xianluWindow1.publishType = 2;
                this.selectOperator1.Title = "送团人：";
                switch (type)
                {
                    //复制一条计划
                    case "Copy":
                        //判断新增计划权限
                        if (!CheckGrant(TravelPermission.团队计划_团队计划_新增计划))
                        {
                            Utils.ResponseNoPermit(TravelPermission.团队计划_团队计划_新增计划, false);
                            return;
                        }
                        if (id != "")
                        {
                            //保存ID
                            this.hideID.Value = id;
                            //保存操作类型
                            this.hideType.Value = "Copy";
                            //隐藏文件
                            this.pnlFile.Visible = false;
                            //初始化
                            DataInit(id);
                            //隐藏快速发布标签
                            this.pnlFast.Visible = false;
                            //隐藏文件删除
                            this.pnlFile.Visible = false;
                        }
                        break;
                    //修改一条计划
                    case "Update":
                        //判断修改计划权限
                        if (!CheckGrant(TravelPermission.团队计划_团队计划_修改计划))
                        {
                            Utils.ResponseNoPermit(TravelPermission.团队计划_团队计划_修改计划, false);
                            return;
                        }
                        if (id != "")
                        {
                            //保存ID
                            this.hideID.Value = id;
                            //保存操作类型
                            this.hideType.Value = "Update";
                            //初始化
                            DataInit(id);
                            //隐藏快速发布标签
                            this.pnlFast.Visible = false;
                        }
                        break;
                    //添加一条计划
                    default:
                        //判断新增计划权限
                        if (!CheckGrant(TravelPermission.团队计划_团队计划_新增计划))
                        {
                            Utils.ResponseNoPermit(TravelPermission.团队计划_团队计划_新增计划, false);
                            return;
                        }
                        //保存操作类型
                        this.hideType.Value = "Add";
                        strTraffic = GetTrafficList(-1);
                        //隐藏文件
                        this.pnlFile.Visible = false;
                        //初始化线路区域
                        DdlAreaInit("");
                        //初始化常用城市
                        CityDataInit("");
                        //隐藏文件删除
                        this.pnlFile.Visible = false;
                        break;
                }
            }
        }


        /// <summary>
        /// 获取关联交通
        /// </summary>
        /// <returns></returns>
        protected string GetTrafficList(int selected)
        {
            EyouSoft.BLL.PlanStruture.PlanTrffic BLL = new EyouSoft.BLL.PlanStruture.PlanTrffic(SiteUserInfo);
            EyouSoft.Model.PlanStructure.TrafficInfo SearchModel = new EyouSoft.Model.PlanStructure.TrafficInfo();
            //SearchModel.IsDelete = false;
            IList<EyouSoft.Model.PlanStructure.TrafficInfo> list = BLL.GetTrafficList(null, SiteUserInfo.CompanyID);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<option value='' data-price='' data-shengyu='0'>请选择</option>");
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.TrafficId == selected)
                    {
                        sb.AppendFormat("<option value='{0}' selected='selected' data-price='' data-shengyu='0'>{1}</option>", item.TrafficId, item.TrafficName);
                    }
                    else
                    {
                        sb.AppendFormat("<option value='{0}' data-price='' data-shengyu='0'>{1}</option>", item.TrafficId, item.TrafficName);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 绑定默认值(送团人，集合地点，集合标志)
        /// </summary>
        private void BindDefaultValue()
        {
            EyouSoft.BLL.CompanyStructure.CompanySetting bll = new CompanySetting();
            EyouSoft.Model.CompanyStructure.CompanyFieldSetting model = bll.GetSetting(this.SiteUserInfo.CompanyID);
            if (model != null)
            {
                selectOperator1.OperId = model.SongTuanRenId;
                selectOperator1.OperName = model.SongTuanRenName;
                txtPlace.Text = model.JiHeDiDian;
                txtLogo.Text = model.JiHeBiaoZhi;
            }
        }


        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            NumConfig = (int)(new EyouSoft.BLL.CompanyStructure.CompanySetting().GetTeamNumberOfPeople(CurrentUserCompanyID));
            #region 将表单值赋值于变量
            //团号
            string teamNum = this.txtTeamNum.Text.Trim();
            //线路区域名
            string lineArea = Utils.GetFormValue(this.ddlLineArea.UniqueID);
            //计调员
            string coordinatorId = Utils.GetFormValue(this.ddlSeller.UniqueID);
            //线路名称
            string xianLuName = this.xianluWindow1.Name;
            //线路ID
            string routeId = this.xianluWindow1.Id;
            //组团社ID
            int buyerCId = Utils.GetInt(this.hideGroupsId.Value);
            //组团社名称
            string buyerCName = Utils.GetFormValue(this.txtGroupsName.UniqueID);
            //天数
            int? dayCount = Utils.GetIntNull(this.txtDayCount.Text);
            //人数
            int? peopleCount = Utils.GetIntNull(this.txtPeopelCount.Text);
            //出发交通
            string startTraffic = this.txtStartTraffic.Text.Trim();
            //返程交通
            string endTraffic = this.txtEndTraffic.Text.Trim();
            //出团日期
            DateTime lDate = Utils.GetDateTime(this.txtLDate.Text);
            //不含项目
            string noProject = this.txtNoProject.Text.Trim();
            //购物安排
            string buyPlan = this.txtBuyPlan.Text;
            //儿童安排
            string childPlan = this.txtChildPlan.Text;
            //自费项目
            string selfProject = this.txtSelfProject.Text;
            //注意事项
            string note = this.txtNote.Text;
            //温馨提示
            string tips = this.txtTips.Text;
            //内部信息
            string internalMsg = this.txtNeiBu.Text;
            //集合时间
            //string gatheredTime = (Utils.GetFormValue(this.txtGathered.UniqueID)) + " " + ddl_jh_date.SelectedValue + ":00:00";
            string gatheredTime = Utils.GetFormValue(this.txtGathered.UniqueID);
            //集合地点
            string place = Utils.GetFormValue(this.txtPlace.UniqueID);
            //集合标志
            string logo = Utils.GetFormValue(this.txtLogo.UniqueID);
            //送团人
            string operatorId = this.selectOperator1.OperId;
            //常用城市
            int tourCity = Utils.GetInt(Utils.GetFormValue(this.ddlCityList.UniqueID));

            #endregion

            #region 验证上传文件的格式是否正确
            string msg = "";
            if (!EyouSoft.Common.Function.UploadFile.CheckFileType(Request.Files, "fileField", new[] { ".gif", ".jpeg", ".jpg", ".png", ".xls", ".doc", ".docx", ".rar", ".txt" }, null, out msg))
            {
                this.litMsg.Text = Utils.ShowMsg(msg);
                return;
            }
            #endregion

            #region 地接信息
            IList<EyouSoft.Model.TourStructure.TourLocalAgencyInfo> djList = this.DiJieControl1.GetList;
            #endregion

            #region 行程安排
            IList<EyouSoft.Model.TourStructure.TourPlanInfo> planList = this.xingcheng1.GetValues();
            #endregion

            #region 包含项目
            IList<EyouSoft.Model.TourStructure.TourTeamServiceInfo> standList = this.PriceControl1.GetList;
            #endregion

            #region 验证
            if (lineArea == "")
            {
                this.litMsg.Text = Utils.ShowMsg("请选择线路区域!");
                return;
            }
            //判断是否选择组团社
            if (buyerCId <= 0)
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请选择组团社!"));
                return;

            }
            if (xianLuName == "")
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请输入线路名称!"));
                return;
            }
            if (coordinatorId == "-1")
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请选择计调员!"));
                return;
            }
            if (dayCount == null || dayCount == 0)
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请输入天数!"));
                return;
            }
            if ((peopleCount == null || peopleCount == 0) && NumConfig == (int)EyouSoft.Model.EnumType.CompanyStructure.TeamNumberOfPeople.OnlyTotalNumber)
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请输入人数!"));
                return;
            }
            int crNum = Utils.GetInt(txt_crNum.Text);
            if (crNum == 0 && NumConfig == (int)EyouSoft.Model.EnumType.CompanyStructure.TeamNumberOfPeople.PartNumber)
            {
                EyouSoft.Common.Function.MessageBox.ResponseScript(this, Utils.ShowMsg("请输入人数!"));
                return;
            }
            #endregion

            //声明bll对象
            EyouSoft.BLL.TourStructure.Tour bll = new EyouSoft.BLL.TourStructure.Tour(SiteUserInfo);
            //声明model对象
            EyouSoft.Model.TourStructure.TourTeamInfo model = new EyouSoft.Model.TourStructure.TourTeamInfo();
            //如果是修改那么先获得该对象model
            if (this.hideType.Value == "Update")
            {
                //如果是修改操作，那么先获的这个对象
                model = (EyouSoft.Model.TourStructure.TourTeamInfo)bll.GetTourInfo(this.hideID.Value);
            }
            //判断对象是否存在
            if (model != null)
            {
                #region 对象属性赋值
                model.TourCode = teamNum;
                model.AreaId = Convert.ToInt32(lineArea);
                //修改时原购买单位
                if (model.BuyerCId > 0)
                {
                    model.OBuyerCId = model.BuyerCId;
                }
                model.Coordinator = new EyouSoft.Model.TourStructure.TourCoordinatorInfo();
                model.Coordinator.CoordinatorId = Utils.GetInt(coordinatorId);
                model.BuyerCId = buyerCId;
                model.BuyerCName = buyerCName;
                model.RouteName = xianLuName;
                if (model.RouteId != 0)
                {
                    model.ORouteId = model.RouteId;
                }
                model.RouteId = Utils.GetInt(routeId);
                model.TourDays = Convert.ToInt32(dayCount);

                #region 添加送团人
                if (this.selectOperator1.OperId.Trim() != "")
                {
                    string[] operIdList = this.selectOperator1.OperId.Split(',');
                    if (operIdList.Count() > 0)
                    {
                        model.SentPeoples = new List<EyouSoft.Model.TourStructure.TourSentPeopleInfo>();
                        for (int i = 0; i < operIdList.Count(); i++)
                        {
                            if (operIdList[i].Trim() != "")
                            {
                                EyouSoft.Model.TourStructure.TourSentPeopleInfo sentPeopleModel = new EyouSoft.Model.TourStructure.TourSentPeopleInfo();
                                sentPeopleModel.OperatorId = Utils.GetInt(operIdList[i]);
                                model.SentPeoples.Add(sentPeopleModel);
                            }
                        }
                    }
                }
                #endregion

                model.GatheringPlace = place;
                model.GatheringSign = logo;
                model.GatheringTime = gatheredTime;
                model.PlanPeopleNumber = Convert.ToInt32(peopleCount);
                model.LTraffic = startTraffic;
                model.RTraffic = endTraffic;
                model.LDate = lDate;
                model.LocalAgencys = djList;
                EyouSoft.Model.TourStructure.TourTeamNormalPrivateInfo tourTeamModel = new EyouSoft.Model.TourStructure.TourTeamNormalPrivateInfo();
                tourTeamModel.Plans = planList;
                tourTeamModel.BuHanXiangMu = noProject;
                tourTeamModel.GouWuAnPai = buyPlan;
                tourTeamModel.ErTongAnPai = childPlan;
                tourTeamModel.ZiFeiXIangMu = selfProject;
                tourTeamModel.ZhuYiShiXiang = note;
                tourTeamModel.WenXinTiXing = tips;
                tourTeamModel.NeiBuXingXi = internalMsg;
                model.TourNormalInfo = tourTeamModel;
                model.Services = standList;
                model.CompanyId = SiteUserInfo.CompanyID;
                model.OperatorId = SiteUserInfo.ID;
                model.TourType = EyouSoft.Model.EnumType.TourStructure.TourType.团队计划;
                model.ReleaseType = EyouSoft.Model.EnumType.TourStructure.ReleaseType.Normal;
                model.TicketStatus = EyouSoft.Model.EnumType.PlanStructure.TicketState.None;
                model.TotalAmount = PriceControl1.TotalAmount;
                //model.SelfUnitPriceAmount = PriceControl1.OnePriceAll;
                model.TourCityId = tourCity;
                model.TourTraffic = new List<int>() { Utils.GetInt(Utils.GetFormValue("selectTraffic"), -1) };
                ///人数、单价 by txb
                model.TourTeamUnit = new EyouSoft.Model.TourStructure.MTourTeamUnitInfo();
                model.TourTeamUnit.NumberCr = Utils.GetInt(txt_crNum.Text);
                model.TourTeamUnit.NumberEt = Utils.GetInt(txt_rtNum.Text);
                model.TourTeamUnit.NumberQp = Utils.GetInt(txt_allNum.Text);
                model.TourTeamUnit.UnitAmountCr = PriceControl1.cr_price;
                model.TourTeamUnit.UnitAmountEt = PriceControl1.rt_price;
                model.TourTeamUnit.UnitAmountQp = PriceControl1.all_price;
                #endregion

                #region 上传单文件
                //团队附件实体
                EyouSoft.Model.TourStructure.TourAttachInfo attachModel = new EyouSoft.Model.TourStructure.TourAttachInfo();
                //文件路径
                string filePath = "";
                //文件名
                string fileName = "";
                //文件上传
                if (EyouSoft.Common.Function.UploadFile.FileUpLoad(Request.Files["fileField"], "TeamPlanFile", out filePath, out fileName))
                {
                    if (filePath.Trim() != "" && fileName.Trim() != "")
                    {
                        //设置文件上传后的虚拟路劲
                        attachModel.FilePath = filePath;
                        //保存原文件名
                        attachModel.Name = fileName;
                        IList<EyouSoft.Model.TourStructure.TourAttachInfo> attachList = new List<EyouSoft.Model.TourStructure.TourAttachInfo>();
                        attachList.Add(attachModel);
                        model.Attachs = attachList;
                    }
                    else if (this.hideData.Value.Trim() != "")
                    {
                        //设置文件上传后的虚拟路劲
                        attachModel.FilePath = this.hideData.Value;
                        IList<EyouSoft.Model.TourStructure.TourAttachInfo> attachList = new List<EyouSoft.Model.TourStructure.TourAttachInfo>();
                        attachList.Add(attachModel);
                        model.Attachs = attachList;
                    }
                    else
                    {
                        model.Attachs = null;
                    }
                }
                else
                {
                    //上传失败提示
                    this.litMsg.Text = Utils.ShowMsg("文件上传失败!");
                    return;
                }
                #endregion

                #region 数据操作
                int count = 0;
                if (model.TourTraffic != null && model.TourTraffic.Count > 0)
                {


                    EyouSoft.BLL.PlanStruture.PlanTrffic BLL = new EyouSoft.BLL.PlanStruture.PlanTrffic();
                    EyouSoft.Model.PlanStructure.TrafficPricesInfo TrafficPricesInfoModel = BLL.GetTrafficPriceModel(model.TourTraffic.First(), model.LDate);
                    if (TrafficPricesInfoModel != null && TrafficPricesInfoModel.TicketNums > 0)
                    {
                        //新增和复制操作时 进行数据添加操作
                        if (this.hideType.Value == "Add" || this.hideType.Value == "Copy")
                        {
                            //数据库添加操作
                            count = bll.InsertTeamTourInfo(model);
                            //新增成功
                            if (count > 0)
                            {
                                Utils.ShowAndRedirect("添加成功!", "/TeamPlan/TeamPlanList.aspx");
                            }
                            else
                                //失败时提示
                                if (count == -1)
                                {
                                    EyouSoft.Common.Function.MessageBox.ResponseScript(this, "javascript:alert('团号重复!');");
                                }
                                else
                                {
                                    EyouSoft.Common.Function.MessageBox.ResponseScript(this, "javascript:alert('添加失败!');");
                                }
                        }
                        else
                        {
                            //数据库修改操作
                            count = bll.UpdateTeamTourInfo(model);
                            //成功提示
                            if (count > 0)
                            {
                                Utils.ShowAndRedirect("修改成功!", "/TeamPlan/TeamPlanList.aspx");
                            }
                            else
                            {
                                EyouSoft.Common.Function.MessageBox.ResponseScript(this, "javascript:alert('修改失败!');");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('提交失败,关联交通票数为零！');location.href=location.href;</script>");
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('提交失败,关联交通为空！');location.href=location.href;</script>");
                }
                #endregion
            }
            else
            {
                Utils.ShowAndRedirect("该计划不存在!", "/TeamPlan/TeamPlanList.aspx");
            }
        }

        #region 初始化控件赋值
        /// <summary>
        /// 页面控件初始化
        /// </summary>
        /// <param name="id"></param>
        protected void DataInit(string id)
        {
            //初始化时 获得Model
            EyouSoft.Model.TourStructure.TourTeamInfo model = (EyouSoft.Model.TourStructure.TourTeamInfo)new EyouSoft.BLL.TourStructure.Tour(SiteUserInfo).GetTourInfo(id);
            if (model != null)
            {
                //如果该团队计划已经核算结束或提交财务，那么不提供修改功能
                if (model.Status == EyouSoft.Model.EnumType.TourStructure.TourStatus.核算结束 || model.Status == EyouSoft.Model.EnumType.TourStructure.TourStatus.财务核算)
                {
                    this.pelAdd.Visible = false;
                }
                if (model.TourTraffic != null && model.TourTraffic.Count > 0)
                {
                    strTraffic = GetTrafficList(model.TourTraffic.First());
                }
                #region 页面控件赋值
                //类型判断
                if (model.ReleaseType == EyouSoft.Model.EnumType.TourStructure.ReleaseType.Quick)
                {
                    Response.Redirect("/TeamPlan/FastVersion.aspx?type=" + this.hideType.Value + "&id=" + id);
                    return;
                }
                //线路区域
                DdlAreaInit(model.AreaId.ToString());
                //计调员
                GetSettleByArea(model.AreaId, model.Coordinator != null ? model.Coordinator.CoordinatorId.ToString() : "");

                //团队编号
                this.txtTeamNum.Text = model.TourCode;
                this.hideOldTeamNum.Value = model.TourCode;
                //线路ID
                this.xianluWindow1.Id = model.RouteId.ToString();
                //线路名称
                this.xianluWindow1.Name = model.RouteName;
                //天数
                this.txtDayCount.Text = model.TourDays.ToString();
                //人数
                this.txtPeopelCount.Text = model.PlanPeopleNumber.ToString();
                this.hid_PeopelCount.Value = model.PlanPeopleNumber.ToString();
                //出发交通
                this.txtStartTraffic.Text = model.LTraffic;
                //返程交通
                this.txtEndTraffic.Text = model.RTraffic;
                //出团日期
                this.txtLDate.Text = model.LDate.ToString("yyyy-MM-dd");
                //地接社信息
                this.DiJieControl1.SetList = model.LocalAgencys;
                //行程安排
                this.xingcheng1.Bind(model.TourNormalInfo.Plans.ToList());
                //包含项目
                this.PriceControl1.SetList = model.Services;
                //设置合计价格
                this.PriceControl1.TotalAmount = model.TotalAmount;
                //单价合计
                //this.PriceControl1.OnePriceAll = model.SelfUnitPriceAmount;
                if (model.TourTeamUnit != null)
                {
                    this.PriceControl1.all_price = model.TourTeamUnit.UnitAmountQp;
                    this.PriceControl1.cr_price = model.TourTeamUnit.UnitAmountCr;
                    this.PriceControl1.rt_price = model.TourTeamUnit.UnitAmountEt;
                    txt_allNum.Text = model.TourTeamUnit.NumberQp.ToString();
                    txt_crNum.Text = model.TourTeamUnit.NumberCr.ToString();
                    txt_rtNum.Text = model.TourTeamUnit.NumberEt.ToString();
                    hid_Num.Value = (model.TourTeamUnit.NumberQp + model.TourTeamUnit.NumberCr + model.TourTeamUnit.NumberEt).ToString();

                }
                //不含项目
                this.txtNoProject.Text = model.TourNormalInfo.BuHanXiangMu;
                //购物安排
                this.txtBuyPlan.Text = model.TourNormalInfo.GouWuAnPai;
                //儿童安排
                this.txtChildPlan.Text = model.TourNormalInfo.ErTongAnPai;
                //自费项目
                this.txtSelfProject.Text = model.TourNormalInfo.ZiFeiXIangMu;
                //注意事项
                this.txtNote.Text = model.TourNormalInfo.ZhuYiShiXiang;
                //温馨提示
                this.txtTips.Text = model.TourNormalInfo.WenXinTiXing;
                //内部信息
                this.txtNeiBu.Text = model.TourNormalInfo.NeiBuXingXi;
                //组团社ID
                this.hideGroupsId.Value = model.BuyerCId.ToString();
                //组团社名称
                this.txtGroupsName.Text = model.BuyerCName;
                //集合地点
                this.txtPlace.Text = model.GatheringPlace;
                //集合标志
                this.txtLogo.Text = model.GatheringSign;
                //集合时间
                //if (Utils.GetDateTimeNullable(model.GatheringTime) == null)
                //{
                //    this.txtGathered.Text = string.Empty;
                //}
                //else
                //{
                //    //日期
                //    string[] date = model.GatheringTime.Split(' ');
                //    //时间
                //    if (date.Length > 1)
                //    {
                //        //日期部分赋值
                //        this.txtGathered.Text = date[0];
                //        //拆分时间部分
                //        string[] time = date[1].Split(':');
                //        if (time.Length > 0)
                //        {
                //            //取时间部分的时
                //            ddl_jh_date.SelectedValue = time[0];
                //        }
                //    }
                //    else
                //    {
                //        //日期部分赋值
                //        this.txtGathered.Text = date[0];
                //    }

                //}
                this.txtGathered.Text = model.GatheringTime;
                //常用城市
                CityDataInit(model.TourCityId.ToString());

                #region 添加送团人
                //model.SentPeoples = new List<EyouSoft.Model.TourStructure.TourSentPeopleInfo>();
                if (model.SentPeoples != null && model.SentPeoples.Count > 0)
                {
                    for (int i = 0; i < model.SentPeoples.Count; i++)
                    {
                        this.selectOperator1.OperId += model.SentPeoples[i].OperatorId + ",";
                        this.selectOperator1.OperName += model.SentPeoples[i].OperatorName + ",";
                    }
                    this.selectOperator1.OperName.TrimEnd(',');
                    this.selectOperator1.OperId.TrimEnd(',');
                }

                #endregion
                //文件显示
                IList<EyouSoft.Model.TourStructure.TourAttachInfo> attachList = model.Attachs;
                if (attachList != null && attachList.Count > 0)
                {
                    EyouSoft.Model.TourStructure.TourAttachInfo fileModel = attachList[0];

                    if (fileModel.FilePath.Trim() == "")
                    {
                        this.pnlFile.Visible = false;
                    }
                    else
                    {
                        this.hideData.Value = fileModel.FilePath;
                        this.lblFileName.Text = "<a href=\"" + fileModel.FilePath + "\" target=\"_blank\">查看附件</a>";
                    }
                }
                else
                {
                    this.pnlFile.Visible = false;
                }
                #endregion

            }
            else
            {
                //如果未找到则跳转至列表
                Response.Redirect("/TeamPlan/TeamPlanList.aspx");
            }
        }
        #endregion

        #region 线路区域初始化
        /// <summary>
        /// 线路区域初始化
        /// </summary>
        /// <param name="selectValue"></param>
        protected void DdlAreaInit(string selectValue)
        {
            //清空下拉框值
            this.ddlLineArea.Items.Clear();
            //添加默认行
            this.ddlLineArea.Items.Add(new ListItem("--请选择--", "0"));
            //获得线路区域集合
            IList<EyouSoft.Model.CompanyStructure.Area> areaList = new EyouSoft.BLL.CompanyStructure.Area(SiteUserInfo).GetAreas();
            if (areaList != null && areaList.Count > 0)
            {
                //将数据添加至下拉框
                for (int i = 0; i < areaList.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = areaList[i].Id.ToString();
                    item.Text = areaList[i].AreaName;
                    this.ddlLineArea.Items.Add(item);
                }
                //设置选中行
                if (selectValue != "")
                {
                    this.ddlLineArea.SelectedValue = selectValue;
                }
            }
        }
        #endregion

        #region 获得计调员
        protected void GetSettleByArea(int areaId, string selectVal)
        {

            //声明bll对象
            EyouSoft.Model.CompanyStructure.Area model = new EyouSoft.BLL.CompanyStructure.Area().GetModel(areaId);
            IList<EyouSoft.Model.CompanyStructure.UserArea> list = null;
            if (model != null)
            {
                list = model.AreaUserList;
            }
            this.ddlSeller.Items.Clear();
            this.ddlSeller.Items.Add(new ListItem("--请选择--", "-1"));
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = list[i].UserId.ToString();
                    item.Text = list[i].ContactName;
                    this.ddlSeller.Items.Add(item);
                }
            }

            if (selectVal.Trim() != "")
            {
                this.ddlSeller.SelectedValue = selectVal;
            }
        }
        #endregion

        #region 获得常用城市
        protected void CityDataInit(string selectIndex)
        {
            EyouSoft.BLL.CompanyStructure.City cityBll = new EyouSoft.BLL.CompanyStructure.City();
            IList<EyouSoft.Model.CompanyStructure.City> list = cityBll.GetList(SiteUserInfo.CompanyID, null, true);
            if (list != null && list.Count > 0)
            {
                this.ddlCityList.Items.Clear();
                this.ddlCityList.Items.Add(new ListItem("--请选择--", "0"));
                for (int i = 0; i < list.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = list[i].Id.ToString();
                    item.Text = list[i].CityName;
                    if (selectIndex.Trim() != "" && selectIndex == list[i].Id.ToString())
                    {
                        item.Selected = true;
                    }
                    this.ddlCityList.Items.Add(item);
                }
            }
        }
        #endregion
    }
}
