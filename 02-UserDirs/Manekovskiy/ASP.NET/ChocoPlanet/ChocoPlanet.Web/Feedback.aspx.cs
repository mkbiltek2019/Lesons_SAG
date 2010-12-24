using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoPlanet.Web
{
    public partial class Feedback : Page
    {
        public Regex EmailRegex
        {
            get 
            { 
                return new Regex("^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$", RegexOptions.IgnoreCase); 
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            // here goes some code
            tbEmail.Text = string.Empty;
            tbText.Text = string.Empty;
            lblThanks.Visible = true;
        }

        protected void cvEmail_Validate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = EmailRegex.IsMatch(tbEmail.Text);
        }
    }
}