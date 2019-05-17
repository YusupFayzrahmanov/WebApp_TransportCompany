using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Newtonsoft.Json;

namespace WebApp_TransportCompany.Extensions
{
    public static class ExcelDataSet
    {

        public static string Read()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            bool flag = false;
            List<TatneftReport> tatneftReports = new List<TatneftReport>();
            object cardNumber = null;
            using (var stream = File.Open("C:\\Users\\User\\Desktop\\Учеба\\ПРОЕКТ УПРАВЛЕНИЯ ГРУЗОПЕРЕВОЗКАМИ\\оперативная справка по заправкам и состоянию счета.xls", 
                FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:
                    do
                    {
                        while (reader.Read())
                        {
                            
                            if(flag)
                            {
                                if (reader.GetValue(1) is string)
                                    if (reader.GetString(1).Contains("держатель"))
                                        cardNumber = reader.GetString(1);
                                if(reader.GetValue(0) !=null)
                                {
                                    tatneftReports.Add(new TatneftReport()
                                    {
                                        GasStationName = reader.GetValue(0),
                                        GasStationNumber = reader.GetValue(1),
                                        Date = reader.GetString(2),
                                        Time = reader.GetValue(3),
                                        Litres = reader.GetValue(5),
                                        Price = reader.GetValue(6),
                                        Total = reader.GetValue(7),
                                        CardNumber = cardNumber
                                    });
                                }
                            }
                            if (reader.GetValue(0) is string)
                                if (reader.GetString(0) == "Владелец\nАЗС")
                                    flag = true;
                        }
                    } while (reader.NextResult());
                    
                    
                }
            }
            
            return JsonConvert.SerializeObject(tatneftReports);

        }
    }

    public class TatneftReport
    {
        public object CardNumber { get; set; }

        public object GasStationName { get; set; }

        public object GasStationNumber { get; set; }

        public object Date { get; set; }

        public object Time { get; set; }

        public object Litres { get; set; }

        public object Price { get; set; }

        public object Total { get; set; }


    }
}
