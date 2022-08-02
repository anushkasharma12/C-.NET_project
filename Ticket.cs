using System.ComponentModel.DataAnnotations;

namespace Assignement_2_Tickets
{
    public class Ticket
    {   
        //defining all the fields of the table

        [Key] //primary key, will auto generate number for each user entry (self incrementing)
        public int Id { get; set; }
        public string Problem { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AssignedTo { get; set; }

        public string SubmittedBy { get; set; }


        public int getTicketId()
        {
            return Id;
        }

        public string getRecord()
        {
            return string.Format(
                   "TicketId : {0} \t" +
                   "Title : {1} \t" +
                   "Problem : {2} \t" +
                   "Description : {3} \t" +
                   "AssignedTo : {4} \t" +
                   "SubmittedBy : {5} \t ",
                   Id,
                   Title,
                   Problem,
                   Description,
                   AssignedTo,
                   SubmittedBy);
        }
    }
}