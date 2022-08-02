using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignement_2_Tickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Ticket> TicketList { get; private set; }
        public List<string> retrievedData = new List<string>();

        //create method
        public void create()
        {
            using (DataContext context = new DataContext())
            {
                //storing user inputed text in variables

                var problem = cbProblem.Text;
                var title = txtTitle.Text;
                var description = txtDescription.Text;
                var submittedBy = txtSubmittedBy.Text;
                var assignedTo = cbAssignedTo.Text;

                //creating new entry and saving it to the database

                if(problem != null && title != null && description != null && submittedBy != null && assignedTo != null)
                {
                    context.TicketsTable.Add(new Ticket() { Problem = problem, Title = title, Description = description, SubmittedBy = submittedBy, AssignedTo = assignedTo });
                    context.SaveChanges();
                }
                else
                    MessageBox.Show("Some fields are missing. All fields must be filled!");

            }
        }

        //read method
        public void read()
        {
            // retriving data from db
            using (DataContext context = new DataContext())
            {
                TicketList = context.TicketsTable.ToList();
                
            }

            foreach(Ticket ticket in TicketList)
            {
                retrievedData.Add(ticket.getRecord());
            }

            ticketListBox.ItemsSource = retrievedData;

        }

        //save button calling create and read methods and giving feedback to user
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            create();
            MessageBox.Show("Record Created.");
            formHeading.Content = "Create New Ticket";
            txtTitle.Text = "";
            txtSubmittedBy.Text = "";
            txtDescription.Text = "";
            cbProblem.Text = "";
            cbAssignedTo.Text = "";
            txtTitle.Focus();
            ticketListBox.Focus();
            read();
        }

        //clearing all the text fields
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtSubmittedBy.Text = "";
            txtDescription.Text = "";
            cbProblem.Text = "";
            cbAssignedTo.Text = "";
            txtTitle.Focus();
            formHeading.Content = "Create New Ticket";
        }

        //search database on ticket id
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            using (DataContext context = new DataContext())
            {
                TicketList = context.TicketsTable.ToList();
            }

            if (txtSearch.Text != "")
            {
                foreach (Ticket ticket in TicketList)
                {

                    if (Convert.ToInt32(txtSearch.Text) == ticket.getTicketId())
                    {
                        //providing feedback to user and displaying the ticket find
                        MessageBox.Show("Record Found!!");
                        txtTitle.Text = ticket.Title;
                        txtSubmittedBy.Text = ticket.SubmittedBy;
                        txtDescription.Text = ticket.Description;
                        cbProblem.Text = ticket.Problem;
                        cbAssignedTo.Text = ticket.AssignedTo;
                        break;
                    }

                }

            }
            //providing feedback to user
            else
            {
                MessageBox.Show("Error: Please Enter the Ticket ID");
                txtSearch.Focus();
            }

            formHeading.Content = "Existing Ticket:";
        }
    }
}
