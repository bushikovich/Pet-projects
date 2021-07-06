using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2DataBase
{
    public class BaseUC : UserControl
    {
        protected readonly string CONNECTION_STRING = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Админ\Desktop\Laba2DataBase\Laba2DataBase\bin\Debug\Library.accdb";

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseUC
            // 
            this.Name = "BaseUC";
            this.Load += new System.EventHandler(this.BaseUC_Load);
            this.ResumeLayout(false);

        }

        private void BaseUC_Load(object sender, EventArgs e)
        {

        }
    }
}
