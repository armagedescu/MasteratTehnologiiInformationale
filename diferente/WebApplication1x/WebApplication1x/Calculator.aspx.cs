using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1x
{
    public partial class CalculatorWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string expression = Expression.Text;
            string rezultat = LimbajCalcStiintific.CalculeazaExpresie(expression);
            Expression.Text = rezultat;
            if (rezultat == expression)
            {
                Result.Text = "Expresie incorecta: " + rezultat;
                Result.ForeColor = System.Drawing.Color.Red;
            } else
            {
                Result.Text = "Succes";
                Result.ForeColor = System.Drawing.Color.Green;
            }

        }
    }
}