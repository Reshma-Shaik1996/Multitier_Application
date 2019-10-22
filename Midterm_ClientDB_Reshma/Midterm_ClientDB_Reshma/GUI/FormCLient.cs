using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midterm_ClientDB_Reshma.DataAccess;
using Midterm_ClientDB_Reshma.Business;
using Midterm_ClientDB_Reshma.GUI;


namespace Midterm_ClientDB_Reshma.GUI
{
    public partial class FormCLient : Form
    {
        public FormCLient()
        {
            InitializeComponent();
        }

        private void FormCLient_Load(object sender, EventArgs e)
        {

        }

        private void Buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void Buttonsave_Click(object sender, EventArgs e)
        {


            Client cli = new Client();
            int cliId = Convert.ToInt32(textBox1.Text.Trim());
            if (!(cli.IsUniqueEmpId(cliId)))
            {
                MessageBox.Show("Client ID already exists.", "Duplicate EmployeeID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }

         

            //valid data
            cli.CLientID = Convert.ToInt32(textBox1.Text.Trim());
            cli.FirstName = textBox2.Text.Trim();
            cli.LastName = textBox3.Text.Trim();
            cli.PhoneNumber = textBox4.Text.Trim();
            cli.Email = textBox5.Text.Trim();

            cli.SaveClient(cli);
            MessageBox.Show("Employee record has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Buttonupdate_Click(object sender, EventArgs e)
        {

        }

       

        private void Buttonsearch_Click(object sender, EventArgs e)
        {



            int selectedIndex = comboBoxOption.SelectedIndex;
            List<Client> listClient = new List<Client>();
            switch (selectedIndex)
            {
                case 0: //Search Client by ClientId
                    Client cli = new Client();
                    cli = cli.SearchClient(Convert.ToInt32(textBoxInput.Text));
                    if (cli != null)
                    {
                        textBox1.Text = cli.CLientID.ToString();
                        textBox2.Text = cli.FirstName;
                        textBox3.Text = cli.LastName;
                        textBox4.Text = cli.PhoneNumber;
                        textBox5.Text = cli.Email;


                    }
                    else
                    {
                        MessageBox.Show("Client record not found!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1: //Search Client by First Name
                    Client ancli = new Client();
                    listClient = ancli.SearchClient(1, textBoxInput.Text.Trim());
                    listViewEmployee.Items.Clear();
                    if (listClient.Count != 0)
                    {
                        foreach (Client cli1 in listClient)
                        {
                            ListViewItem item = new ListViewItem(cli1.CLientID.ToString());
                            item.SubItems.Add(cli1.FirstName);
                            item.SubItems.Add(cli1.LastName);
                            item.SubItems.Add(cli1.PhoneNumber);
                            item.SubItems.Add(cli1.Email);

                            listViewEmployee.Items.Add(item);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Client list is empty" + "\n" + "Please enter Employee Data", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
               
                default:
                    break;
            }


















        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

