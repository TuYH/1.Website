using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace HXD.SQLServerDAL
{
    /// <summary>
    /// 新广告操作类
    /// </summary>
    public class tb_U_Advertisement
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.tb_U_Advertisement GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,AdName,Width,Height,Files,FileType,href,Elucidation,scripttext,type,CloseTime,isqiyong,submittime from tb_U_Advertisement ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            HXD.Model.tb_U_Advertisement model = new HXD.Model.tb_U_Advertisement();
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.AdName = ds.Tables[0].Rows[0]["AdName"].ToString();
                if (ds.Tables[0].Rows[0]["Width"].ToString() != "")
                {
                    model.Width = int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Height"].ToString() != "")
                {
                    model.Height = int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
                }
                model.Files = ds.Tables[0].Rows[0]["Files"].ToString();
                if (ds.Tables[0].Rows[0]["FileType"].ToString() != "")
                {
                    model.FileType = int.Parse(ds.Tables[0].Rows[0]["FileType"].ToString());
                }
                model.href = ds.Tables[0].Rows[0]["href"].ToString();
                model.Elucidation = ds.Tables[0].Rows[0]["Elucidation"].ToString();
                model.scripttext = ds.Tables[0].Rows[0]["scripttext"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CloseTime"].ToString() != "")
                {
                    model.CloseTime = DateTime.Parse(ds.Tables[0].Rows[0]["CloseTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isqiyong"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isqiyong"].ToString() == "1") || (ds.Tables[0].Rows[0]["isqiyong"].ToString().ToLower() == "true"))
                    {
                        model.isqiyong = true;
                    }
                    else
                    {
                        model.isqiyong = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["submittime"].ToString() != "")
                {
                    model.submittime = DateTime.Parse(ds.Tables[0].Rows[0]["submittime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HXD.Model.tb_U_Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_Advertisement(");
            strSql.Append("AdName,Width,Height,Files,FileType,href,Elucidation,scripttext,type,CloseTime,isqiyong)");
            strSql.Append(" values (");
            strSql.Append("@AdName,@Width,@Height,@Files,@FileType,@href,@Elucidation,@scripttext,@type,@CloseTime,@isqiyong)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			new SqlParameter("@AdName", SqlDbType.NVarChar,50),
			new SqlParameter("@Width", SqlDbType.Int,4),
			new SqlParameter("@Height", SqlDbType.Int,4),
			new SqlParameter("@Files", SqlDbType.VarChar,5000),
			new SqlParameter("@FileType", SqlDbType.Int,4),
			new SqlParameter("@href", SqlDbType.VarChar,300),
			new SqlParameter("@Elucidation", SqlDbType.NVarChar,100),
			new SqlParameter("@scripttext", SqlDbType.Text),
			new SqlParameter("@type", SqlDbType.Int,4),
			new SqlParameter("@CloseTime", SqlDbType.DateTime),
			new SqlParameter("@isqiyong", SqlDbType.Bit,1)};
            parameters[0].Value = model.AdName;
            parameters[1].Value = model.Width;
            parameters[2].Value = model.Height;
            parameters[3].Value = model.Files;
            parameters[4].Value = model.FileType;
            parameters[5].Value = model.href;
            parameters[6].Value = model.Elucidation;
            parameters[7].Value = model.scripttext;
            parameters[8].Value = model.type;
            parameters[9].Value = model.CloseTime;
            parameters[10].Value = model.isqiyong;
            int id = Convert.ToInt32(HXD.DBUtility.SQLHelper.ExecuteScalar(strSql.ToString(), parameters));
            if (id > 0)
            {
                model.id = id;
                addjs(model);
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.tb_U_Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_Advertisement set ");
            strSql.Append("AdName=@AdName,");
            strSql.Append("Width=@Width,");
            strSql.Append("Height=@Height,");
            strSql.Append("Files=@Files,");
            strSql.Append("FileType=@FileType,");
            strSql.Append("href=@href,");
            strSql.Append("Elucidation=@Elucidation,");
            strSql.Append("scripttext=@scripttext,");
            strSql.Append("type=@type,");
            strSql.Append("CloseTime=@CloseTime,");
            strSql.Append("isqiyong=@isqiyong");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
			new SqlParameter("@id", SqlDbType.Int,4),
			new SqlParameter("@AdName", SqlDbType.NVarChar,50),
			new SqlParameter("@Width", SqlDbType.Int,4),
			new SqlParameter("@Height", SqlDbType.Int,4),
			new SqlParameter("@Files", SqlDbType.VarChar,5000),
			new SqlParameter("@FileType", SqlDbType.Int,4),
			new SqlParameter("@href", SqlDbType.VarChar,300),
			new SqlParameter("@Elucidation", SqlDbType.NVarChar,100),
			new SqlParameter("@scripttext", SqlDbType.Text),
			new SqlParameter("@type", SqlDbType.Int,4),
			new SqlParameter("@CloseTime", SqlDbType.DateTime),
			new SqlParameter("@isqiyong", SqlDbType.Bit,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.AdName;
            parameters[2].Value = model.Width;
            parameters[3].Value = model.Height;
            parameters[4].Value = model.Files;
            parameters[5].Value = model.FileType;
            parameters[6].Value = model.href;
            parameters[7].Value = model.Elucidation;
            parameters[8].Value = model.scripttext;
            parameters[9].Value = model.type;
            parameters[10].Value = model.CloseTime;
            parameters[11].Value = model.isqiyong;
            if (HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1)
            {
                addjs(model);
                return true;
            }
            else
            { return false; }
        }

        public void addjs(HXD.Model.tb_U_Advertisement model)
        {
            StringBuilder str = new StringBuilder();
            string datetime = model.CloseTime.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            str.Append("var myDate = new Date();");
            str.Append("var d1 = new Date(\"" + datetime + "\");");
            str.Append("if (Date.parse(myDate) - Date.parse(d1) < 0&&" + model.isqiyong.ToString().ToLower() + "){");//大于等于0表示超时
            if (model.type == 1)
            {
                str.Append("document.write(\"<a href=\\\"http://" + model.href + "\\\" title=\\\"" + model.href + "\\\" target=\\\"_blank\\\">" + model.Elucidation + "</a>\");");
            }
            else if (model.type == 2)
            {
                if (model.Height == 0 && model.Width == 0 && model.href != "")
                { str.Append("document.write(\"<a href=\\\"http://" + model.href + "\\\" title=\\\"" + model.Elucidation + "\\\" target=\\\"_blank\\\"><img border=\\\"0\\\" alt=\\\"" + model.Elucidation + "\\\" src=\\\"" + model.Files + "\\\" /></a>\");"); }
                else if (model.Height != 0 && model.Width != 0 && model.href != "")
                { str.Append("document.write(\"<a href=\\\"http://" + model.href + "\\\" title=\\\"" + model.Elucidation + "\\\" target=\\\"_blank\\\"><img border=\\\"0\\\" alt=\\\"" + model.Elucidation + "\\\" src=\\\"" + model.Files + "\\\" height=\\\"" + model.Height + "\\\" width=\\\"" + model.Width + "\\\" /></a>\");"); }
                else if (model.href == "" && model.Height != 0 && model.Width != 0)
                { str.Append("document.write(\"<img border=\\\"0\\\" alt=\\\"" + model.Elucidation + "\\\" src=\\\"" + model.Files + "\\\" height=\\\"" + model.Height + "\\\" width=\\\"" + model.Width + "\\\" />\");"); }
                else if (model.href == "" && model.Height == 0 && model.Width == 0)
                { str.Append("document.write(\"<img border=\\\"0\\\" alt=\\\"" + model.Elucidation + "\\\" src=\\\"" + model.Files + "\\\" />\");"); }
            }
            else if (model.type == 3)
            {
                str.Append("document.write(\"<object classid=\\\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\\\" codebase=\\\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10.0.45.2\\\" width=\\\"" + model.Width + "\\\" height=\\\"" + model.Height + "\\\">");
                str.Append("<param name=\\\"movie\\\" value=\\\"" + model.Files + "\\\"/>");
                str.Append("<param name=\\\"quality\\\" value=\\\"high\\\"/>");
                str.Append("<param name=\\\"wmode\\\" value=\\\"transparent\\\"/>");
                str.Append("<embed src=\\\"" + model.Files + "\\\" width=\\\"" + model.Width + "\\\" height=\\\"" + model.Height + "\\\" quality=\\\"high\\\" pluginspage=\\\"http://www.macromedia.com/go/getflashplayer\\\" type=\\\"application/x-shockwave-flash\\\" wmode=\\\"transparent\\\"></embed>");
                str.Append("</object>\");");
            }
            else if (model.type == 4)
            {
                str.Append(model.scripttext);
            }
            else if (model.type == 5)
            {
                str.Append("function addEvent(obj,evtType,func,cap){cap=cap||false;if(obj.addEventListener){obj.addEventListener(evtType,func,cap);return true;}else if(obj.attachEvent){if(cap){obj.setCapture();return true;}else{return obj.attachEvent('on' + evtType,func);}}else{return false;}};function removeEvent(obj,evtType,func,cap){cap=cap||false;if(obj.removeEventListener){obj.removeEventListener(evtType,func,cap);return true;}else if(obj.detachEvent){if(cap){obj.releaseCapture();return true;}else{return obj.detachEvent('on' + evtType,func);}}else{return false;}};function getPageScroll(){var xScroll,yScroll;if (self.pageXOffset) {xScroll = self.pageXOffset;} else if (document.documentElement && document.documentElement.scrollLeft){xScroll = document.documentElement.scrollLeft;} else if(document.body) {xScroll = document.body.scrollLeft;}if (self.pageYOffset) {yScroll = self.pageYOffset;} else if (document.documentElement && document.documentElement.scrollTop){yScroll = document.documentElement.scrollTop;} else if (document.body) {yScroll = document.body.scrollTop;}arrayPageScroll = new Array(xScroll,yScroll);return arrayPageScroll;};function GetPageSize(){var xScroll, yScroll;if (window.innerHeight && window.scrollMaxY) { xScroll = document.body.scrollWidth;yScroll = window.innerHeight + window.scrollMaxY;} else if (document.body.scrollHeight > document.body.offsetHeight){xScroll = document.body.scrollWidth;yScroll = document.body.scrollHeight;} else {xScroll = document.body.offsetWidth;yScroll = document.body.offsetHeight;}var windowWidth, windowHeight;if (self.innerHeight) {windowWidth = self.innerWidth;windowHeight = self.innerHeight;} else if (document.documentElement && document.documentElement.clientHeight) {windowWidth = document.documentElement.clientWidth;windowHeight = document.documentElement.clientHeight;} else if (document.body) {windowWidth = document.body.clientWidth;windowHeight = document.body.clientHeight;} if(yScroll < windowHeight){pageHeight = windowHeight;} else { pageHeight = yScroll;}if(xScroll < windowWidth){ pageWidth = windowWidth;} else {pageWidth = xScroll;}arrayPageSize = new Array(pageWidth,pageHeight,windowWidth,windowHeight);return arrayPageSize;};var AdMoveConfig=new Object();AdMoveConfig.IsInitialized=false;AdMoveConfig.AdCount=0;AdMoveConfig.ScrollX=0;AdMoveConfig.ScrollY=0;AdMoveConfig.MoveWidth=0;AdMoveConfig.MoveHeight=0;AdMoveConfig.Resize=function(){var winsize=GetPageSize();AdMoveConfig.MoveWidth=winsize[2];AdMoveConfig.MoveHeight=winsize[3];AdMoveConfig.Scroll();};AdMoveConfig.Scroll=function(){var winscroll=getPageScroll();AdMoveConfig.ScrollX=winscroll[0];AdMoveConfig.ScrollY=winscroll[1];};addEvent(window,'resize',AdMoveConfig.Resize);addEvent(window,'scroll',AdMoveConfig.Scroll);function AdMove(id,addCloseButton){if(!AdMoveConfig.IsInitialized){AdMoveConfig.Resize();AdMoveConfig.IsInitialized=true;};AdMoveConfig.AdCount++;var obj=document.getElementById(id);obj.style.position='absolute';var W=AdMoveConfig.MoveWidth-obj.offsetWidth;var H=AdMoveConfig.MoveHeight-obj.offsetHeight;var x = W*Math.random(),y = H*Math.random();var rad=(Math.random()+1)*Math.PI/6;var kx=Math.sin(rad),ky=Math.cos(rad);var dirx = (Math.random()<0.5?1:-1), diry = (Math.random()<0.5?1:-1);var step = 1;var interval;if(addCloseButton){var closebtn=document.createElement('div');obj.appendChild(closebtn);");
                //str.Append("closebtn.style.position='absolute';closebtn.style.top='1px';closebtn.style.left=(obj.offsetWidth-28) + 'px';closebtn.style.width='24px';closebtn.style.height='12px';");
                //str.Append("closebtn.style.borderStyle='solid';closebtn.style.borderWidth='1px';closebtn.style.borderColor='#000';closebtn.style.backgroundColor='#fff';");//按钮样式
                //str.Append("closebtn.style.fontSize='12px';closebtn.style.color='#000';closebtn.style.cursor='pointer';closebtn.innerHTML='关闭';");//关闭按钮
                str.Append("closebtn.onclick=function(){obj.style.display='none';clearInterval(interval);closebtn.onclick=null;obj.onmouseover=null;obj.onmouseout=null;obj.MoveHandler=null;AdMoveConfig.AdCount--;if(AdMoveConfig.AdCount<=0){removeEvent(window,'resize',AdMoveConfig.Resize);removeEvent(window,'scroll',AdMoveConfig.Scroll);AdMoveConfig.Resize=null;AdMoveConfig.Scroll=null;AdMoveConfig=null;}}};obj.MoveHandler=function(){obj.style.left = (x + AdMoveConfig.ScrollX) + 'px';obj.style.top = (y + AdMoveConfig.ScrollY) + 'px';rad=(Math.random()+1)*Math.PI/6;W=AdMoveConfig.MoveWidth-obj.offsetWidth;H=AdMoveConfig.MoveHeight-obj.offsetHeight;x = x + step*kx*dirx;if (x < 0){dirx = 1;x = 0;kx=Math.sin(rad);ky=Math.cos(rad);} if (x > W){dirx = -1;x = W;kx=Math.sin(rad);ky=Math.cos(rad);}y = y + step*ky*diry;if (y < 0){diry = 1;y = 0;kx=Math.sin(rad);ky=Math.cos(rad);} if (y > H){diry = -1;y = H;kx=Math.sin(rad);ky=Math.cos(rad);}};this.SetLocation=function(vx,vy){x=vx;y=vy;};this.SetDirection=function(vx,vy){dirx=vx;diry=vy;};this.Run=function(){var delay = 10;interval=setInterval(obj.MoveHandler,delay);obj.onmouseover=function(){clearInterval(interval);};obj.onmouseout=function(){interval=setInterval(obj.MoveHandler, delay);}}};");
                str.Append("document.write(\"<div id='adfddiv' style='width:" + model.Width + "px;height:" + model.Height + "px;word-wrap:break-word; overflow:hidden;'><a href='" + model.href + "' target='_blank'><img src='" + model.Files + "' alt='" + model.Elucidation + "' style='border:0;width:" + model.Width + "px;height:" + model.Height + "px;'/></a></div>\");");
                str.Append("var adjss=new AdMove(\"adfddiv\",true);adjss.Run();");
            }
            str.Append("}");
            HXD.Common.FileOperate.DeleteFile(Web.Model.PublicModel.ADJsFile + model.id + ".js");
            HXD.Common.FileObj.WriteFile(Web.Model.PublicModel.ADJsFile + model.id + ".js", str.ToString(), Web.Model.PublicModel.EncodingUTF8);
        }
    }
}