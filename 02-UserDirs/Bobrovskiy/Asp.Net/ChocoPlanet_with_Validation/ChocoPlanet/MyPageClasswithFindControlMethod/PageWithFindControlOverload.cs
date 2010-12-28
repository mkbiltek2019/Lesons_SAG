using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ChocoPlanet.MyPageClasswithFindControlMethod
{
    public class PageWithFindControlOverload:Page
    {
        public new T FindControl<T>(string id) where T:Control
        {
            return FindControl<T>(this.Form, id);
        }

        private new T FindControl<T>(Control startingControl, string id) where T : Control
        {
            T found = startingControl as T;
            if ((string.IsNullOrEmpty(id) || (found == null)))
            {
                return default(T);//(T)null;
            }

            if (string.Compare(id, found.ID) == 0)
            {
                return found;
            }

            foreach (Control ctl in startingControl.Controls)
            {
                found = FindControl<T>(ctl, id);
                if ((found != null))
                {
                    return found;
                }
            }
            return default(T);//(T)null;
        } 

        public new Control FindControl<T>(string id, bool searchInChildControls) where T : Control
        {
            T ctl = this.Form as T;
            bool result = false;
            LinkedList<T> ctls = new LinkedList<T>();

            while (ctl != null)
            {
                if (ctl.ID == id)
                {
                    result = true;
                }

                if (searchInChildControls)
                {
                    foreach (T child in ctl.Controls)
                    {
                        if (child.ID == id)
                        {
                            ctl = child;
                            result = true;
                            break;
                        }

                        if (child.HasControls())
                        {
                            ctls.AddLast(child);
                        }
                    }
                }

                if (result)
                {
                    break;
                }

                ctl = ctls.First.Value;
                ctls.Remove(ctl);
            }

            return ctl;
        }
    }
}