using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vkoteht1
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.Cookies["Muunnoksia"].Value = "0";
        }

        public void btnPara_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Valuuttamuunnin2.aspx?" + "user=" + txtNimi.Text);
            Server.Transfer("Valuuttamuunnin2.aspx");
        }

        public void btnSession_OnClick(object sender, EventArgs e)
        {
            Session["SessionNimi"] = txtNimi.Text;
            Server.Transfer("Valuuttamuunnin2.aspx");
        }

        public void btnCookie_OnClick(object sender, EventArgs e)
        {
            Response.Cookies["Nimi"].Value = txtNimi.Text;
            Response.Cookies["Nimi"].Expires = DateTime.Now.AddDays(1);
            Server.Transfer("Valuuttamuunnin2.aspx");
        }

    }
}