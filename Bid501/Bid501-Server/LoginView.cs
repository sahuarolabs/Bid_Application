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
        public LoginDel handleLogin { get; set; } //added

        /// <summary>
        /// The reference to the controller object, later
        /// we need to replace this with delegate(s).
        /// </summary>
        Controller controller;

        public LoginView()
        {
            InitializeComponent();

        }

        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.START:
                    userTextPrompt.Text = "Please Enter Username";
                    passwordText.Enabled = false;
                    loginButton.Enabled = false;
                    break;
                case State.GOTUSERNAME:
                    userTextPrompt.Text = "Please Enter Password";
                    passwordText.Enabled = true;
                    break;
                case State.GOTPASSWORD:
                    userTextPrompt.Text = "Validating Credentials...";
                    break;
                case State.DECLINED:
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Sorry, Invalid Credentials";
                    }));
                    break;
                case State.SUCCESS:
//will need to change the sucess state to close login form and open a new admin view
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        usernameText.Text = "";
                        passwordText.Text = "";
                        userTextPrompt.Text = "Congrats,admin! You are Logged In.";
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
            String username = usernameText.Text;
            String password = passwordText.Text;
            Console.WriteLine(username + " " + password);
            handleLogin(State.GOTPASSWORD, username + ":" + password); //changed

        }

        /// <summary>
        /// Links the View to the controller.
        /// </summary>
        /// <param name="c">The App's main controller object. Later
        /// this shold be a delegate.</param>
        public void SetController(Controller c)
        {
            controller = c;
        }

        /// <summary>
        /// TO synch the View and the Controller objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            handleLogin(State.START, ""); //changed
        }

        /// <summary>
        /// This method helps avoid some user input propblems, and helps 
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            handleLogin(State.GOTUSERNAME, ""); //changed
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
    }
}
