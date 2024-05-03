using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Bid501_Server
{
    public partial class LoginView : Form
    {
        private AdminOpen adOpen;
        public LoginDel handleLogin { get; set; }
        //  public LoginRequest loginRequest { get; set; }
        List<Account> accounts;
        AccountModel am;
        bool admin = false;
        public LoginView(AdminOpen ao, AccountModel acc)
        {
            InitializeComponent();
            this.adOpen = ao;
            this.am = acc;
            accounts = am.AccountSync();
            passwordText.Enabled = false;
            loginButton.Enabled = false;
        }

        public void DisplayState(Bid501_Shared.State state)
        {
            switch (state)
            {
                case Bid501_Shared.State.START:
                    userTextPrompt.Text = "Please Enter Username";
                    break;
                case Bid501_Shared.State.GOTUSERNAME:
                    userTextPrompt.Text = "Please Enter Password";
                    passwordText.Enabled = true;
                    break;
                case Bid501_Shared.State.GOTPASSWORD:
                    userTextPrompt.Text = "Validating Credentials...";
                    break;
                case Bid501_Shared.State.DECLINED:
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Sorry, you do not have Admin privledges, try again";
                       //  UxLoginBtn. = false;   
                    break;
                case Bid501_Shared.State.SUCCESS:
                    //will need to change the sucess state to close login form and open a new admin view
                    //Invoke this code since it will only ever be run on a separate thread.
              
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Congrats! You are Logged In.";
                    this.Hide();
                    adOpen();
                        
                    break;
                default:
                    userTextPrompt.Text = "Invalid State";
                    break;

            }
        }

       
        private void UxLoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            admin = validateLogins(username, password);
            if(admin == true)
            {
                
                DisplayState(Bid501_Shared.State.SUCCESS);
                
            }
            else
            {
                DisplayState(Bid501_Shared.State.DECLINED);
            }
        }

        private bool validateLogins(string username,string password)
        {
            foreach(Account account in accounts)
            {
                if(username == account.Username && password == account.Password)
                {
                    if (account.IsAdmin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            passwordText.Enabled = true;
            DisplayState(Bid501_Shared.State.GOTUSERNAME);
        }


        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = true;
            DisplayState(Bid501_Shared.State.GOTPASSWORD);
        }
    }
}
