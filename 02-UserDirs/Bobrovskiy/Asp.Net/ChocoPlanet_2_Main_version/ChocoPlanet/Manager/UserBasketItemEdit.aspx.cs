using System;
using ChocoPlanet.Business.Product_Category;

namespace ChocoPlanet.Manager
{
    public partial class UserBasketItemEdit : System.Web.UI.Page
    {
        OrderStatusController orderStatusController = new OrderStatusController();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["orderStatusID"]);

            DateTime? curierDate = Convert.ToDateTime(this.tbCurierDate.Text); 
            DateTime? deliveryDate = Convert.ToDateTime(this.tbDeliveryDate.Text); 

            string state = ddlOrderState.SelectedItem.Text;
            OrderStateController orderStateController = new OrderStateController();
            int stateId = orderStateController.GetIdByName(state);

            if (id != null && id != 0)
            {
                orderStatusController.ModifyOrderStatus(id, curierDate, deliveryDate, stateId);
            }

            Session["orderStatusID"] = 0;
        }

        protected void tbRenderText(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["orderStatusID"]);

            if (id != null && id != 0)
            {
                this.tbCurierDate.Text = orderStatusController.GetById(id).CourierPassingDate.ToString();
                this.tbDeliveryDate.Text = orderStatusController.GetById(id).CourierPassingDate.ToString();
            }
        }

    }
}