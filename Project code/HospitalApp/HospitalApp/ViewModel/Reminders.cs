using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class Reminders : ViewModel
    {
        public Reminders() : base()
        {

        }
        public void Language_selectionChanged(object sender, EventArgs e)
        {
            if (TranslationSource.Instance.CurrentCulture != null)
            {
                if (TranslationSource.Instance.CurrentCulture.Name.Equals("sr-Latn"))
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                }
                else
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
                }
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
        }
    }
}
