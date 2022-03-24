using AutoTrans.WPF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutoTrans.WPF.Classes
{
    internal class Global
    {
        public static Frame MainFrame { get; set; }
        public static DBEntities DB { get; set; }
        public static User MyUser { get; set; }
    }
}
