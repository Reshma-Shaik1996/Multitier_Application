using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm_ClientDB_Reshma.DataAccess;
namespace Midterm_ClientDB_Reshma.Business
{
   public class Client
    {

        private int clientId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        public int CLientID { get => clientId; set => clientId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public string Email { get => email; set => email = value; }
        public bool IsUniqueEmpId(int id)
        {
            return (ClientDB.IsUniqueId(id));
        }
        public void SaveClient(Client cli)
        {
            ClientDB.SaveRecord(cli);
        }

        public Client SearchClient(int cliId)
        {
            return (ClientDB.SearchRecord(cliId));
        }
        public List<Client> ListClient()
        {
            return (ClientDB.ListRecord());
        }
        public List<Client> SearchClient(int option, string input)
        {
            return (ClientDB.SearchRecord(option, input));
        }
        public void UpdateEmployee(Client cli)
        {
            ClientDB.UpdateRecord(cli);
        }



    }
}
