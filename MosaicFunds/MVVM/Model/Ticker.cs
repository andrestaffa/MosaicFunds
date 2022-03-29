using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicFunds.MVVM.Model
{
    class Ticker
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Price { get; set; }
        public string ChangeDollar { get; set; }
        public string ChangePercent { get; set; }
        public string Shares { get; set; }
        public string Value { get; set; }
        public string Profit { get; set; }

        public Ticker() {}

        public Ticker(string name, string companyName, string price, string changeDollar, string changePercent, string shares, string value, string profit) {
            this.Name = name;
            this.CompanyName = companyName;
            this.Price = price;
            this.ChangeDollar = changeDollar;
            this.ChangePercent = changePercent;
            this.Shares = shares;
            this.Value = value;
            this.Profit = profit;
        }

    }
}
