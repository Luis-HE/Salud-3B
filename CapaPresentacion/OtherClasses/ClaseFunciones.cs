using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI.WebControls;

namespace CapaPresentacion.OtherClasses
{
    public class ClaseFunciones
    {
        public static void FillMonths(DropDownList dprObject)
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                dprObject.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            }
        }
    }
}