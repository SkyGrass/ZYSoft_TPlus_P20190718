﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ufida.T.EAP.AppBase;
using Ufida.T.BAP.Web.Base;
using System.Web.UI.WebControls;
using Chanjet.ZYSoft.CTL.Interface;
using Ufida.T.EAP.Aop;
using Ufida.T.EAP.DataStruct.Context;
using System.Web;
using Ufida.T.EAP.Dal;

namespace Chanjet.ZYSoft.CTL.UIP
{
    public class CTLPage : IAppHandler
    {
        GenericController controller;
        ICTL interfaceService;
        Label lblUserName;
        Label lbUserId;
        public void AppEventHandler(object sender, AppEventArgs e)
        {
            controller = sender as GenericController;

            lblUserName = controller.GetViewControl("lblUserName") as Label;

            lbUserId = controller.GetViewControl("lbUserId") as Label;

            interfaceService = ServiceFactory.getService<ICTL>();

            Page_Load(sender, e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = HttpContext.Current.Session["UserInfo"] as UserInfo;
            lblUserName.Text += userInfo.PersonName;
            lbUserId.Text += userInfo.UserID;
        }
    }
}
