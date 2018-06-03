using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Classes;
using BusinessLayer.CallCentre;

namespace PresentationLayer
{
    public partial class frmCall : Form
    {
        Call call;
        Timer callTimer = new Timer();
        double secondsPassed;
        CallState currentState;
        private string nextCall = "";
        private string currentCallNumber;
        private string employeeId;
        CallerQueue callerQueue;
        //Determine if the last call was saved
        bool callSaved = true;

        public CallState CurrentCallState { get => currentState; }

        public string NextCall
        {
            get => nextCall;
            private set
            {
                nextCall = value;
                showNextCall(nextCall);
            }
        }

        public event EventHandler CallEnded;

        private void OnCallEnd()
        {
            if (CallEnded != null) CallEnded(this, new EventArgs());
            showNextCall(nextCall);
        }
        

        private void showNextCall(string number)
        {
            if (number != "")
            {
                if (currentState == CallState.Ended || currentState == CallState.NoCall || currentState == CallState.Rejected)
                {
                    nextCall = "";
                    currentState = CallState.Incoming;
                    incomingCall(number);
                }
            }
        }

        public enum CallState
        {
            Incoming, InProgress, Ended, Rejected, NoCall
        }

        private void noCall()
        {
            if (currentState == CallState.NoCall)
            {
                lblTitle.Text = "";
                lblDuration.Text = "";
                lblNumber.Text = "";
                txtInformation.Enabled = false;
                btnSave.Enabled = false;
                btnAnswer.Hide();
                btnReject.Hide();
                pnlStartCall.Show();
            }
        }

        //Open the caller
        public frmCall(string employeeId)
        {
            initialise(employeeId);
            call = new Call();
            currentState = CallState.NoCall;
            noCall();
        }

        //Initiate a new call
        public frmCall(string number, string employeeId)
        {
            initialise(employeeId);
            currentState = CallState.Incoming;
            incomingCall(number);
        }


        //Initiate an already started call
        public frmCall(Call call, string employeeId)
        {
            initialise(employeeId);
            currentState = CallState.InProgress;
            callInProgress(call);
        }

        private void initialise(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            callerQueue = CallerQueue.GetInstance();
            callerQueue.NewCall += callerQueue_OnNewCall;
            callTimer.Tick += CallTimer_Tick;
        }

        private void callerQueue_OnNewCall(object sender, EventArgs e)
        {
            if (currentState != CallState.Incoming)
            {
                try
                {
                    NextCall = callerQueue.GetNextCall();
                }
                catch (Exception ex) { }
            }
        }

        private void callInProgress(Call call)
        {
            if (currentState == CallState.InProgress)
            {
                pnlStartCall.Hide();
                secondsPassed = (DateTime.Now - call.TimeStart).TotalSeconds;
                startTimer();
                lblNumber.Text = call.CellNumber;
                lblTitle.Text = "Call In Progress";
                btnAnswer.Enabled = false;
                txtInformation.Enabled = true;
                btnAnswer.Show();
                btnReject.Show();
                lblNumber.Show();
                btnSave.Enabled = false;
                lblDuration.Show();
                btnAnswer.UseVisualStyleBackColor = false;
                btnAnswer.BackColor = Color.FromArgb(100, Color.GhostWhite);
            }
        }

        private void startTimer()
        {
            callTimer.Interval = 1000;
            callTimer.Start();
        }

        private void incomingCall(string number)
        {
            if (currentState == CallState.Incoming)
            {
                currentCallNumber = number;
                pnlStartCall.Hide();
                lblTitle.Text = "New Call Incoming";
                lblNumber.Text = number;
                lblDuration.Text = "00:00";
                btnAnswer.Enabled = true;
                btnReject.Enabled = true;
                btnAnswer.Show();
                btnReject.Show();
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (!callSaved) saveCall(call);
            if (currentState == CallState.Incoming)
            {
                call = new Call(0, DateTime.Now, DateTime.Now, employeeId, currentCallNumber, "", false);
                secondsPassed = 0;
                startTimer();
                BackColor = Color.LightSeaGreen;
                currentState = CallState.InProgress;
                callInProgress(call);
            }
        }

        private void callEnded(Call call)
        {
            if (currentState == CallState.Ended)
            {
                call.TimeEnd = DateTime.Now;
                callTimer.Stop();
                lblTitle.Text = "Call Ended";
                BackColor = Color.GhostWhite;
                showNextCall(nextCall);
            }
        }

        private void CallTimer_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblDuration.Text = ((int)(secondsPassed / 60)).ToString().PadLeft(2, '0') + ":" + ((int) (secondsPassed % 60)).ToString().PadLeft(2, '0');
        }

        private void rejectCall(Call call)
        {
            if (currentState == CallState.Rejected)
            {
                call.IsOutgoing = false;
                lblTitle.Text = "Call Rejected";
                btnAnswer.Hide();
                btnReject.Hide();
                pnlStartCall.Show();
                lblDuration.Hide();
                lblNumber.Hide();
                showNextCall(nextCall);
            }
        }

        private void saveCall(Call call)
        {
            call.CapturedInformation = txtInformation.Text;
            call.Insert();
            callSaved = true;
            txtInformation.Text = "";
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (currentState == CallState.Incoming)
            {
                currentState = CallState.Rejected;
                rejectCall(call);
            }

            if (currentState == CallState.InProgress)
            {
                currentState = CallState.Ended;
                callEnded(call);
            }
        }

        private void btnCallStart_Click(object sender, EventArgs e)
        {
            //Test if the number length is 10 digits long and add 2 formatting spaces
            if (txtNewNumber.Text.Length == 12)
            {
                currentState = CallState.InProgress;
                call = new Call(0, DateTime.Now, DateTime.Now, employeeId, txtNewNumber.Text, "", true);
                callInProgress(call);
            }
            else MessageBox.Show("The cell number must be 10 digits", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveCall(call);
        }
    }
}

/*Todo
 * Add threads that randomly select clients from the database as callers to the call centre.
 * Add these calls to a queue and allow the operator to accept or decline calls, accessible from the outside
 * Add events that will allow the form to update when calls are added
 * Add these occurrences to the database
 * Run the caller simulator on a separate thread
 * Show a lsist of currently waiting incoming calls
 */
