using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicFunds.MVVM.Model {
    class SettingsModel {

        public string Title { get; set; }

        public SettingsModel() {}

        public SettingsModel(string title) {
            this.Title = title;
        }
    }
}
