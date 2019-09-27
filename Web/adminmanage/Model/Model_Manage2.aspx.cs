using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.Common;
using HXD.Model;
using HXD.BLL;

public partial class adminmanage_Model_Model_Manage2 : System.Web.UI.Page
{
    protected int MenuId;
    protected string[] Arry;
    protected string InfoList;
    protected string Model;
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected bTable bT = new bTable();
    protected HXD.ModelField.BLL.Model bm = new HXD.ModelField.BLL.Model();
    protected HXD.ModelField.Model.Model mm = new HXD.ModelField.Model.Model();
    protected string add = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        MenuId = StringDeal.ToInt(Request.QueryString["MenuId"]);
        mm.TableName = bM.GetMenuTableName(MenuId);//获取模型表名
        mm.Temp = Request.Params["Id"];
        mM.Id = MenuId;
        if (!Page.IsPostBack)
        {
            Model = mm.TableName;
            if (Request.QueryString["Action"] == "del")
            {
                bm.ModelDelete(mm);
                Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
                StringDeal.Alter("删除成功");
            }
            #region 2010-05-25 mjh
            DelBut.Visible = false;
            this.StatusBut.Visible = false;
            this.unStatusBut.Visible = false;
            this.TopBut.Visible = false;
            this.unTopBut.Visible = false;
            this.EliteBut.Visible = false;
            this.unEliteBut.Visible = false;
            this.HotBut.Visible = false;
            this.unHotBut.Visible = false;

            if (mM.Id != 0)
            {
                DataSet ds = bM.MenuReader(mM);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string[] Arry2 = ds.Tables[0].Rows[0]["Sitting"].ToString().Split(',');
                    for (int i = 0; i < Arry2.Length; i++)
                    {
                        if (Arry2[i] == "1")
                        {
                            add += "<a href=\"Model_Edit.aspx?MenuId=" + MenuId + "\" class=\"red\"> | 添加</a>";
                        }

                        if (Arry2[i] == "3")
                        {
                            DelBut.Visible = true;
                            this.DelBut.Attributes.Add("title", "批量删除");
                            this.DelBut.Attributes.Add("onclick", "return confirm('确认删除');");
                        }

                        if (Arry2[i] == "4")
                        {
                            StatusBut.Visible = true;
                            unStatusBut.Visible = true;
                            this.StatusBut.Attributes.Add("title", "批量审核");
                            this.StatusBut.Attributes.Add("onclick", "return confirm('确认审核');");
                            this.unStatusBut.Attributes.Add("title", "批量关闭");
                            this.unStatusBut.Attributes.Add("onclick", "return confirm('确认关闭');");
                        }

                        if (Arry2[i] == "6")
                        {
                            TopBut.Visible = true;
                            unTopBut.Visible = true;
                            this.TopBut.Attributes.Add("title", "批量设置置顶");
                            this.TopBut.Attributes.Add("onclick", "return confirm('确认设置置顶');");
                            this.unTopBut.Attributes.Add("title", "批量取消置顶");
                            this.unTopBut.Attributes.Add("onclick", "return confirm('确认取消置顶');");
                        }

                        if (Arry2[i] == "7")
                        {
                            this.EliteBut.Visible = true;
                            this.unEliteBut.Visible = true;
                            this.EliteBut.Attributes.Add("title", "批量设置推荐");
                            this.EliteBut.Attributes.Add("onclick", "return confirm('确认设置推荐');");
                            this.unEliteBut.Attributes.Add("title", "批量取消推荐");
                            this.unEliteBut.Attributes.Add("onclick", "return confirm('确认取消推荐');");
                        }

                        if (Arry2[i] == "8")
                        {
                            this.HotBut.Visible = true;
                            this.unHotBut.Visible = true;
                            this.HotBut.Attributes.Add("title", "批量设置热门");
                            this.HotBut.Attributes.Add("onclick", "return confirm('确认设置热门');");
                            this.unHotBut.Attributes.Add("title", "批量取消热门");
                            this.unHotBut.Attributes.Add("onclick", "return confirm('确认取消热门');");
                        }


                    }
                }

            }
            #endregion


            //this.DelBut.Attributes.Add("title", "批量删除");
            //this.DelBut.Attributes.Add("onclick", "return confirm('确认删除');");
            //this.StatusBut.Attributes.Add("title", "批量审核");
            //this.StatusBut.Attributes.Add("onclick", "return confirm('确认审核');");
            //this.unStatusBut.Attributes.Add("title", "批量关闭");
            //this.unStatusBut.Attributes.Add("onclick", "return confirm('确认关闭');");
            //this.TopBut.Attributes.Add("title", "批量设置置顶");
            //this.TopBut.Attributes.Add("onclick", "return confirm('确认设置置顶');");
            //this.unTopBut.Attributes.Add("title", "批量取消置顶");
            //this.unTopBut.Attributes.Add("onclick", "return confirm('确认取消置顶');");
            //this.EliteBut.Attributes.Add("title", "批量设置推荐");
            //this.EliteBut.Attributes.Add("onclick", "return confirm('确认设置推荐');");
            //this.unEliteBut.Attributes.Add("title", "批量取消推荐");
            //this.unEliteBut.Attributes.Add("onclick", "return confirm('确认取消推荐');");
            //this.HotBut.Attributes.Add("title", "批量设置热门");
            //this.HotBut.Attributes.Add("onclick", "return confirm('确认设置热门');");
            //this.unHotBut.Attributes.Add("title", "批量取消热门");
            //this.unHotBut.Attributes.Add("onclick", "return confirm('确认取消热门');");
            mM.Temp = "Title";
            this.MenuTitle.Text = bM.GetMenuField(mM, MenuId);
            this.MenuTitle1.Text = this.MenuTitle.Text;
            GetModelList(MenuId);
            ListTitleBind();
            ListBind(MenuId);
            this.ListTable.Text = InfoList;
        }
    }

    #region 栏目列表标题遍历
    /// <summary>
    /// 栏目列表标题遍历
    /// </summary>
    protected void ListTitleBind()
    {
        int i = Arry.Length + 6;
        InfoList = "<tr>\n";
        InfoList += "<td colspan=\"" + i + "\" class=\"redbold\">" + this.MenuTitle.Text + "列表</td>\n";
        InfoList += "</tr>\n";
        InfoList += "<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">\n";
        InfoList += "<th><input type=\"checkbox\" onClick=\"check();\" /></th>\n";
        InfoList += "<th aling=\"center\" nowrap=\"nowrap\" title=\"信息ID\">Id</th>";
        foreach (string x in Arry)
        {
            string width = "";
            if (StringDeal.ToInt(x.Split(',')[2]) > 0)
            {
                width = " width='" + x.Split(',')[2] + "%'";
            }
            InfoList += "<th" + width + ">" + StringDeal.StrFormat(x.Split(',')[1]) + "</th>\n";
        }
        InfoList += "<th aling=\"center\" nowrap=\"nowrap\" title=\"排序号\">排序</th>\n";
        InfoList += "<th aling=\"center\" nowrap=\"nowrap\" title=\"锁定状态\">状态</th>\n";
        InfoList += "<th align=\"center\">操作</th>\n";
        InfoList += "</tr>\n";
    }
    #endregion

    #region 栏目列表信息遍历
    /// <summary>
    /// 栏目列表信息遍历
    /// </summary>
    /// <param name="ParentId"></param>
    /// <param name="Line"></param>
    protected void ListBind(int MenuId)
    {
        #region 2010-05-25 mjh
        string mmod = "style=\"display:none;\"";
        string mdel = "style=\"display:none;\"";
        string mshow = "style=\"display:none;\"";
        if (mM.Id != 0)
        {
            DataSet dst = bM.MenuReader(mM);
            if (dst.Tables[0].Rows.Count > 0)
            {

                string[] Arry2 = dst.Tables[0].Rows[0]["Sitting"].ToString().Split(',');
                for (int i = 0; i < Arry2.Length; i++)
                {
                    if (Arry2[i] == "2")
                    {
                        mmod = "";
                    }

                    if (Arry2[i] == "3")
                    {
                        mdel = "";
                    }
                    if (Arry2[i] == "5")
                    {
                        mshow = "";
                    }
                }
            }

        }
        #endregion
        mm.FieldList = GetField();
        mm.Condition = " ClassId=" + MenuId;
        mm.Sort = "Sort DESC";
        mm.PageSize = 20;
        mm.PageIndex = StringDeal.ToInt(Request.QueryString["Page"]);
        DataSet ds = bm.ModelList(mm);
        //----分页开始-----
        SgqPage pg = new SgqPage();
        pg.PageSize = mm.PageSize;
        pg.PageIndex = mm.PageIndex;
        pg.RecordCount = (int)ds.Tables[1].Rows[0][0];//获取数据总数
        this.PageView.Text = pg.PageView2();
        //----分页结束-----
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            InfoList += "<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">\n";
            InfoList += "<td align=\"center\"><input type=\"checkbox\" name=\"Id\" value=\"" + dr[0] + "\" /></td>\n";
            InfoList += "<td align=\"center\">" + dr[0] + "</td>\n";
            int x = 0;
            foreach (string j in GetField().Split(','))
            {
                int i = 0;
                if (x == 0)
                {
                    if (StringDeal.GetTrueOfStr(dr["IsTop"], "[置顶]") != string.Empty)
                    { i++; }
                    if (StringDeal.GetTrueOfStr(dr["IsElite"], "[推荐]") != string.Empty)
                    { i++; }
                    if (StringDeal.GetTrueOfStr(dr["IsHot"], "[热门]") != string.Empty)
                    { i++; }
                    i = i * 6;
                }
                InfoList += "<td><div class=\"editfieldbox\" title=\"" + StringDeal.StrFormat(dr[j]) + "\">" + HXD.Common.StringDeal.Substrings1(StringDeal.StrFormat(dr[j]).ToString(), 44 - i) + " ";
                if (x == 0)
                {
                    InfoList += "<span style=\"color:green;\">";
                    InfoList += StringDeal.GetTrueOfStr(dr["IsTop"], "[置顶]");
                    InfoList += StringDeal.GetTrueOfStr(dr["IsElite"], "[推荐]");
                    InfoList += StringDeal.GetTrueOfStr(dr["IsHot"], "[热门]");
                    InfoList += "</span>";
                }
                InfoList += "</div></td>\n";
                x++;
            }
            InfoList += "<td align=\"center\" nowrap=\"nowrap\"><input type=\"type\" onchange=\"IsNum(this.value," + dr[0] + ");\" class=\"input required\" size=\"3\" id=\"SortId_" + dr[0] + "\" name=\"SortId\" value=\"" + dr["Sort"] + "\" /><span id='s" + dr[0] + "'></span></td>\n";
            InfoList += "<td align=\"center\" nowrap=\"nowrap\">" + StringDeal.GetYesOrNo(dr["IsStatus"]) + "</td>\n";
            InfoList += "<td align=\"center\" nowrap=\"nowrap\">";
            InfoList += " <a href=\"Useradd.aspx?MenuId=" + dr[0] + "\">添加管理员</a> <a " + mshow + " href=\"Model_show.aspx?MenuId=" + MenuId + "&Id=" + dr[0] + "\">查看</a> <a " + mmod + " href=\"Model_Edit.aspx?MenuId=" + MenuId + "&Id=" + dr[0] + "\">修改</a> <a " + mdel + " onclick=\"return confirm('确认删除');\" href=\"?Action=del&MenuId=" + MenuId + "&Id=" + dr[0] + "\">删除</a>";
            InfoList += "</td>\n</tr>\n";
        }
    }
    #endregion

    #region 获取列表字段名数组
    /// <summary>
    /// 获取列表字段名数组
    /// </summary>
    protected string GetField()
    {
        string Field = "";
        foreach (string x in Arry)
        {
            Field += x.Split(',')[0] + ",";
        }
        Field = Field.Trim(',');
        return Field;
    }
    #endregion

    #region 获取列表页所显示的字段、名称、宽度
    /// <summary>
    /// 获取列表页所显示的字段、名称、宽度
    /// </summary>
    /// <returns></returns>
    private void GetModelList(int Id)
    {
        mM.Temp = "Model_List";
        string Arrystr = bM.GetMenuField(mM, Id);
        if (String.IsNullOrEmpty(Arrystr))
        {
            mM.Temp = "ParentId";
            Id = StringDeal.ToInt(bM.GetMenuField(mM, Id));
            GetModelList(Id);
        }
        else
        {
            Arry = Arrystr.Split('|');
        }
    }
    #endregion

    #region 对信息的操作（删除，审核，置顶，推荐，热门）
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要删除的对象！");
        }
        else
        {
            bm.ModelDelete(mm);
            Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
        }
    }
    /// <summary>
    /// 批量审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StatusBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要审核的对象！");
        }
        mm.IsStatus = true;
        bm.ModelStatus(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量关闭
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unStatusBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要关闭的对象！");
        }
        mm.IsStatus = false;
        bm.ModelStatus(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量置顶
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TopBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要置顶的对象！");
        }
        mm.IsTop = true;
        bm.ModelTop(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量取消置顶
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unTopBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要取消置顶的对象！");
        }
        mm.IsTop = false;
        bm.ModelTop(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EliteBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要推荐的对象！");
        }
        mm.IsElite = true;
        bm.ModelElite(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量取消推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unEliteBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要取消推荐的对象！");
        }
        mm.IsElite = false;
        bm.ModelElite(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量热门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HotBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要设置热门的对象！");
        }
        mm.IsHot = true;
        bm.ModelHot(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    /// <summary>
    /// 批量取消热门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unHotBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mm.Temp))
        {
            StringDeal.Alter("请选择要取消热门的对象！");
        }
        mm.IsHot = false;
        bm.ModelHot(mm);
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId, true);
    }
    #endregion
}