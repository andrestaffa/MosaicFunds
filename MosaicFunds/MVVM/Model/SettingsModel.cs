using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicFunds.MVVM.Model {
    class SettingsModel {

        public string Title { get; set; }
        public string Settings1_Static { get; set; }
        public string Settings1 { get; set; }
        public string Settings2_Static { get; set; }
        public string Settings2 { get; set; }
        public string Settings3_Static { get; set; }
        public string Settings3 { get; set; }
        public string Settings4_Static { get; set; }
        public string Settings4 { get; set; }

        public SettingsModel() {}

        public SettingsModel(string title, string settings1_static, string settings1, string settings2_static, string settings2, string settings3_static, string settings3, string settings4_static, string settings4) {
            this.Title = title;

            this.Settings1_Static = settings1_static;
            this.Settings1 = settings1;

            this.Settings2_Static = settings2_static;
            this.Settings2 = settings2;

            this.Settings3_Static = settings3_static;
            this.Settings3 = settings3;

            this.Settings4_Static = settings4_static;
            this.Settings4 = settings4;
        }
    }
}
