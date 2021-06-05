using System;

namespace HospitalApp.ViewModel
{
    class Home : ViewModel
    {
        public Home() : base()
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
