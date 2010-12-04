using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello!!!111";

            if (IsPostBack)
            {
                UpdatelbresultText();
            }
        }

        protected void lbResult_Click(object sender, EventArgs e)
        {
            UpdatelbresultText();
        }

        private void UpdatelbresultText()
        {
            if (ddlOperation.SelectedItem.Value == "+")
            {
                lbResult.Text = (int.Parse(tbNumber1.Text) + int.Parse(tbNumber2.Text))
                                .ToString();
            }
            else
            {
                lbResult.Text = (int.Parse(tbNumber1.Text) - int.Parse(tbNumber2.Text))
                                .ToString();
            }
        }
    }
}