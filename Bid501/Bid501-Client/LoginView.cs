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
using Bid501_Shared;

namespace Bid501_Client
{
    public partial class LoginView : Form
    {

        
        public LoginDel handleLogin { get; set; }
        public LoginRequest loginRequest { get; set; }

        public LoginView()
        {
            InitializeComponent();

        }

        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(Bid501_Shared.State state)
        {
            switch (state)
            {
                case Bid501_Shared.State.START:
                    userTextPrompt.Text = "Please Enter Username";
                    passwordText.Enabled = false;
                    loginButton.Enabled = false;
                    break;
                case Bid501_Shared.State.GOTUSERNAME:
                    userTextPrompt.Text = "Please Enter Password";
                    passwordText.Enabled = true;
                    break;
                case Bid501_Shared.State.GOTPASSWORD:
                    userTextPrompt.Text = "Validating Credentials...";
                    break;
                case Bid501_Shared.State.DECLINED:
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Sorry, Invalid Credentials";
                    }));
                    break;
                case Bid501_Shared.State.SUCCESS:
                    //will need to change the sucess state to close login form and open a new admin view
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Congrats! You are Logged In.";
                    }));
                    break;
                default:
                    userTextPrompt.Text = "Invalid State";
                    break;

            }
        }

        /// <summary>
        /// Listener to the Login button. It takes the user's input
        /// for the username and password and pass the values to the
        /// Controller along with the state the view is in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxLoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            handleLogin(username + ":" + password); //changed
        }

        /// <summary>
        /// TO synch the View and the Controller objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            handleLogin(""); //changed
        }

        /// <summary>
        /// This method helps avoid some user input propblems, and helps 
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            //handleLogin(Bid501_Shared.State.GOTUSERNAME, ""); //changed
            passwordText.Enabled = true;
        }


        /// <summary>
        /// This method helps avoid some user input propblems, and helps
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = true;
        }

        private void passwordText_Enter(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            handleLogin("Login:" + username + ":" + password);
        }
    }
}
