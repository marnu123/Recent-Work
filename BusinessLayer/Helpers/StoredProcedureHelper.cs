using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;
using BusinessLayer.StoredProcedures;
using BusinessLayer.Classes;

namespace BusinessLayer.Helpers
{
    public static class StoredProcedureHelper
    {
        public static bool IsUniqueEmail(string email)
        {
            return DataHandler.GetInstance().ExecuteProcedure(new IsUniqueEmail(email)).Rows.Count == 0;
        }

        //Return a dictionary of clients with their ID's and their emails
        public static Dictionary<string, string> GetClientEmails(string searchString = "")
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            DataTable dt = DataHandler.GetInstance().ExecuteProcedure(new GetClientEmailAddresses(searchString));
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(dr["PK_ClientID"].ToString(), dr["FK_PersonEmail"].ToString());
            }

            return result;
        }

        public static List<TaskWithContract> GetUnassginedTasksWithContracts()
        {
            DataTable dt = DataHandler.GetInstance().ExecuteProcedure(new GetUnassignedTasksWithContracts());
            List<TaskWithContract> result = new List<TaskWithContract>();

            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new TaskWithContract(dr["CurrentContract"].ToString(), new Task(dr)));
            }

            return result;
        }

        public static List<Schedule> GetScheduledTasksInProgress()
        {
            DataTable dt = DataHandler.GetInstance().ExecuteProcedure(new GetTasksInProgress());
            List<Schedule> result = new List<Schedule>();

            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new Schedule(dr));
            }

            return result;
        }
    }
}
