using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using BusinessLayer.CallCentre;
using BusinessLayer.Classes;

namespace PresentationLayer
{
    public partial class frmMenu : Form
    {
        Dictionary<Type, Form> openForms;
        CallSimulator callSim;

        Employee loggedInUser;
        CallerQueue calls = CallerQueue.GetInstance();

        private void calls_NewCall(object sender, EventArgs e)
        {
            showNotification();
        }

        private void showNotification()
        {
            notifyIncomingCall.Icon = SystemIcons.Application;
            notifyIncomingCall.ShowBalloonTip(3000);
        }

        private void initialise()
        {
            InitializeComponent();
            callSim = new CallSimulator(60, 240);
            callSim.Start();
            openForms = new Dictionary<Type, Form>();
        }

        public frmMenu(Employee user)
        {
            initialise();
            loggedInUser = user;
        }

        public frmMenu()
        {
            calls.NewCall += calls_NewCall;
            initialise();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            showForm(new frmPerson());
        }

        private void showForm(Form toShow)
        {
            if (!openForms.ContainsKey(toShow.GetType()))
            {
                openForms.Add(toShow.GetType(), toShow);
                toShow.Show();
                toShow.Closed += (s, events) =>
                {
                    Show();
                    openForms.Remove(s.GetType());
                };
            }
            else
            {
                openForms[toShow.GetType()].Focus();
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            showForm(new frmProduct());
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            showForm(new frmLocation());
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            showForm(new frmComponent());
        }

        private void btnContractTypes_Click(object sender, EventArgs e)
        {
            showForm(new frmContractType());
        }

        private void btnCaller_Click(object sender, EventArgs e)
        {
            showForm(new frmCall("123"));
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            showForm(new frmTask());
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            showForm(new frmScheduleTreeViewForm());
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            showForm(new frmSchedule());
        }

        private void notifyIncomingCall_BalloonTipClicked(object sender, EventArgs e)
        {
            frmCall frm;

            if (!openForms.ContainsKey(typeof(frmCall)))
            {
                frm = new frmCall(calls.GetNextCall(), "123");
            }
            else frm = (frmCall) openForms[typeof(frmCall)];

            showForm(frm);
        }

        private void btnCallLog_Click(object sender, EventArgs e)
        {
            showForm(new frmCallLog());
        }
    }
}
