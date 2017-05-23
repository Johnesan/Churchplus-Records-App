using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churchplus_Records.Models
{

    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string PastorName { get; set; }

        public string ChurchName { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebsiteURL { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool Expired { get; set; }
    }
}
