using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoParses.UI.ViewModels
{
    class UIParameters
    {
        public GroupBox groupBoxStatic { get; set; }
        public GroupBox groupBoxDynamic { get; set; }
        public GroupBox groupBoxCommon { get; set; }
        public string TemplateDir { get; set; }
        public string ExportDir { get; set; }
        public List<ListViewItem> fileList { get; set; }

        public UIParameters() { }
    }
}
