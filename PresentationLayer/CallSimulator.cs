using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using System.Windows.Forms;
using BusinessLayer.CallCentre;

namespace PresentationLayer
{
    public class CallSimulator
    {
        List<string> cellNumbers;
        Timer randomTimer;
        Random randomiser;
        CallerQueue calls;
        int minInterval, maxInterval;

        public CallSimulator(int minIntervalSeconds, int maxIntervalSeconds)
        {
            calls = CallerQueue.GetInstance();
            cellNumbers = StoredProcedureHelper.GetUniqueCellNumbers();
            randomTimer = new Timer();
            randomiser = new Random();
            randomTimer.Tick += randomTimer_Tick;
            this.minInterval = minIntervalSeconds;
            this.maxInterval = maxIntervalSeconds;
        }

        public void Start()
        {
            setRandomTime();
        }

        public void Stop()
        {
            randomTimer.Stop();
        }

        private void setRandomTime()
        {
            randomTimer.Interval = randomiser.Next(minInterval * 1000, maxInterval * 1000);
            randomTimer.Start();
        }

        private void randomTimer_Tick(object sender, EventArgs e)
        {
            calls.AddCall(cellNumbers[randomiser.Next(0, cellNumbers.Count() - 1)]);
            setRandomTime();
        }
    }
}
