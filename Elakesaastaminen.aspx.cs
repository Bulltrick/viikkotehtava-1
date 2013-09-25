using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vkoteht1
{
    public partial class Elakesaastaminen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtIka.Text == "") txtIka.Text = System.Configuration.ConfigurationManager.AppSettings["ikaDefault"].ToString();
            if (txtPalkka.Text == "") txtPalkka.Text = System.Configuration.ConfigurationManager.AppSettings["palkkaDefault"].ToString();
            txtArvio.Text = laskeElake();
            Body.Attributes.Add("bgcolor", System.Configuration.ConfigurationManager.AppSettings["variDefault"].ToString());
        }

        public String laskeElake()
        {
            double AEKerroin = (63 - Convert.ToDouble(txtIka.Text)) * (5.5);
            lblEAKerroin.Text = "Elinaikakertoimen vaikutus -" + Convert.ToString(AEKerroin);
            double Laki = Convert.ToDouble(txtPalkka.Text) / 2;
            lblLaki.Text = "Lakisääteinen eläke " + Convert.ToString(Laki);
            double apu = Laki - AEKerroin;
            return Convert.ToString(apu);
        }

        public String intPlusString(String str, int nro)
        {
            int apu = Int32.Parse(str) + nro;
            return apu.ToString();
        }

        protected void btnIkaMinus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIka.Text) <= 18) return;
            txtIka.Text = intPlusString(txtIka.Text, -1);
            txtArvio.Text = laskeElake();
        }

        protected void btnIkaPlus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIka.Text) >= 63) return;
            txtIka.Text = intPlusString(txtIka.Text, 1);
            txtArvio.Text = laskeElake();
        }

        protected void btnPalkkaMinus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPalkka.Text) <= 0) return;
            txtPalkka.Text = intPlusString(txtPalkka.Text, -100);
            txtArvio.Text = laskeElake();
        }

        protected void btnPalkkaPlus_Click(object sender, EventArgs e)
        {
            txtPalkka.Text = intPlusString(txtPalkka.Text, 100);
            txtArvio.Text = laskeElake();
        }

        protected void btnLisaa_Click(object sender, EventArgs e)
        {
            txtPalkka.Text = intPlusString(txtPalkka.Text, 10000);
            Server.Transfer("omainfo.aspx");
        }
    }
}