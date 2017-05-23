using Churchplus_Records.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Churchplus_Records
{
    //This class acts as a model for creating the masterPage ListItems
    public class RootPageMenuItem
    {
        public RootPageMenuItem()
        {
            //Sets the initial pagetype to be the RecordList. This causes the default detail page to be set to a RecordList Instance
            TargetType = typeof(RecordsList);
        }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
