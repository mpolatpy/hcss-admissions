using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class StudentWaitLists
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public int WaitListId { get; set; }
        public WaitList WaitList { get; set; }

        public string RegistrationStatus { get; set; } = "Initial  Application";
        public string LotteryCategory { get; set; }
        public int LotteryNumber { get; set; }
    }
}