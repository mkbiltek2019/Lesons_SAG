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
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            btnResult.Text = (int.Parse(tbNumber1.Text) + int.Parse(tbNumber2.Text))
                .ToString();
        }
    }
}