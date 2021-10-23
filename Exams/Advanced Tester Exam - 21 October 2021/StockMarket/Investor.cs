using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public IReadOnlyList<Stock> Portfolio { get; private set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                List<Stock> temp = Portfolio.ToList();
                temp.Add(stock);
                Portfolio = temp.AsReadOnly();
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stockToSell = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
            if (stockToSell == null)
            {
                return $"{companyName} does not exist.";
            }
            
            if (sellPrice < stockToSell.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            MoneyToInvest += sellPrice;
            List<Stock> temp = Portfolio.ToList();
            temp.Remove(stockToSell);
            Portfolio = temp.AsReadOnly();

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
            => Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany()
            => Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
