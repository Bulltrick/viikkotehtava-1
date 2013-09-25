using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vkoteht1
{
    public partial class Valuuttamuunnin2 : System.Web.UI.Page
    {
        String naem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtNimi.Text == "") txtNimi.Text = haeNimi();
            
        }

        public String haeNimi()
        {
            if (Request.QueryString["user"] != null) return Request.QueryString["user"];
            if (Session["SessionNimi"] != null) return (String)Session["SessionNimi"];
            if (Request.Cookies["Nimi"] != null)
            {
                naem = Request.Cookies["Nimi"].Value;
                Request.Cookies["Nimi"].Expires = DateTime.Now.AddDays(-1);
                return naem;
            }
            return "Taisit tulla tänne tupsahtaen? :)";
        }

        public void btnMuunna_OnClick(object sender, EventArgs e)
        {
            int apu;
            txtMarkat.Text = "" + Int32.Parse(txtMarkat.Text) / 6;
            if (Request.Cookies["Muunnoksia"] == null) Response.Cookies["Muunnoksia"].Value = "0";
            apu = Int32.Parse(Request.Cookies["Muunnoksia"].Value) +1;
            Response.Cookies["Muunnoksia"].Value = "" + apu;
            lblLaskut.Text = "Laskutoimituksia " + apu;
        }

    }
}