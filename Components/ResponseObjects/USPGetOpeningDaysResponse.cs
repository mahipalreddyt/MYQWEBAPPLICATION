using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPGetOpeningDaysResponse
    {
        public int OpeningId { get; set; }
        public string DayTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> SeqNo { get; set; }
    }
}
