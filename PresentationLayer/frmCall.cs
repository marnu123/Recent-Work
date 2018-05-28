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

namespace PresentationLayer
{
    public partial class frmCall : Form
    {
        Call call;
        Timer callTimer = new Timer();
        double secondsPassed;
        CallState currentState;

        enum CallState
        {
            Incoming, InProgress, Ended, Rejected
        }

        public frmCall()
        {
            InitializeComponent();
            call = new Call();
        }

        private void initialise()
        {

        }

        private void callInProgress(Call call)
        {
            if (currentState == CallState.InProgress)
            {
                secondsPassed = (DateTime.Now - call.TimeStart).TotalSeconds;
                startTimer();
                lblNumber.Text = call.CellNumber;
                lblTitle.Text = "Call In Progress";
                btnAnswer.Enabled = false;
                btnAnswer.UseVisualStyleBackColor = false;
                btnAnswer.BackColor = Color.FromArgb(100, Color.GhostWhite);
            }
        }

        private void startTimer()
        {
            callTimer.Interval = 1000;
            callTimer.Tick += CallTimer_Tick;
            callTimer.Start();
        }

        //Initiate a new call
        public frmCall(Call call, bool newCall = false)
        {
            InitializeComponent();
            this.call = call;
            if (!newCall)
            {
                currentState = CallState.InProgress;
                callInProgress(call);
            }
            else
            {
                currentState = CallState.Incoming;
                incomingCall(call);
            }
        }

        private void incomingCall(Call call)
        {
            if (currentState == CallState.Incoming)
            {
                lblTitle.Text = "New Call Incoming";
                lblNumber.Text = call.CellNumber;
                lblDuration.Text = "00:00";
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (currentState == CallState.Incoming)
            {
                call.TimeStart = DateTime.Now;
                secondsPassed = 0;
                startTimer();
                this.BackColor = Color.LightSeaGreen;
                currentState = CallState.InProgress;
            }
        }

        private void CallTimer_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblDuration.Text = ((int)(secondsPassed / 60)).ToString().PadLeft(2, '0') + ":" + ((int) (secondsPassed % 60)).ToString().PadLeft(2, '0');
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (currentState == CallState.InProgress)
            {
                call.TimeEnd = DateTime.Now;
                callTimer.Stop();
                lblTitle.Text = "Call Ended";
                BackColor = Color.GhostWhite;
                currentState = CallState.Ended;
            }
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
