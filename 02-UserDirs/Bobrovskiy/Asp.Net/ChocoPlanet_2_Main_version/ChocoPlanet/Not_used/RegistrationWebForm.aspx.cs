using System;
using System.Web.UI.WebControls;
using ChocoPlanet.Validation;

namespace ChocoPlanet
{
    public partial class RegistrationWebForm : System.Web.UI.Page
    {
        private CustomDataValidator dataValidator = new CustomDataValidator();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void textBox_Validate(object source, ServerValidateEventArgs args)
        {
            //const string good = "Все гаразд!";
            //const string bad = "Капча введена невірно. Спробуйте ще раз.";

            dataValidator.FieldID = ((CustomValidator)source).ControlToValidate;
            dataValidator.FieldValue = args.Value;
            dataValidator.Validate();
            if (!dataValidator.IsValid)
            {
                ((CustomValidator)source).ErrorMessage = dataValidator.ErrorMessage;
            }
            
            args.IsValid = dataValidator.IsValid;

            //recaptcha.Validate();
            //if (recaptcha.IsValid)
            //{
            //    lblResult.Text = good;
            //    lblResult.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    lblResult.Text = bad;
            //    lblResult.ForeColor = System.Drawing.Color.Red;
            //}
        }

        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if(Page.IsValid && cbRulesConfirm.Checked)//&&recaptcha.IsValid
            {
                //Start registration procedure fro user
            } 
        }

        protected void userData_Validate(object source, ServerValidateEventArgs args)
        {
            dataValidator.ValidatePassword(args.Value, tbPasswordConfirmation.Text);
            if (!dataValidator.IsValid)
            {
                ((CustomValidator)source).ErrorMessage = dataValidator.ErrorMessage;
            }

            args.IsValid = dataValidator.IsValid;
        }
    }
}