using System;
using System.Data;
using System.Data.OleDb;
using ClosedXML.Excel;

namespace AskFm.Utils
{
    public static class ReadDataFromExcel
    {

        internal static UserData GetUserData(string path, string sheet, string userDataToSearch)
        {
            //DataTable dt = ReadExcelFile(sheet, path);
            //UserData user = GetUserDataFromExcelFile(dt, userDataToSearch);
            UserData user = GetUserDataFromExcelFile(path, sheet, userDataToSearch);
            return user;
        }

#if false
        private static DataTable ReadExcelFile(string sheetName, string filePath)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection())
                {
                    DataTable dt = new DataTable();
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";" +
                                            "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    using (OleDbCommand comm = new OleDbCommand())
                    {
                        comm.CommandText = "Select * from [" + sheetName + "$]";

                        comm.Connection = conn;

                        using (OleDbDataAdapter da = new OleDbDataAdapter())
                        {
                            da.SelectCommand = comm;
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private static UserData GetUserDataFromExcelFile(DataTable dt, string userDataToSearch)
        {
            if (dt == null) return null;
            UserData user = new UserData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                {
                    if (dt.Rows[i][j].ToString() == userDataToSearch)
                    {
                        user.Login = dt.Rows[i + 1][j + 1].ToString();
                        user.Password = dt.Rows[i + 1][j + 2].ToString();
                        return user;
                    }
                }
            }
            return null;
        }
#endif

#if true
        private static UserData GetUserDataFromExcelFile(string path, string sheet, string userDataToSearch)
        {
            UserData user = new UserData();
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet;
            workbook.Worksheets.TryGetWorksheet(sheet, out worksheet);
            for (int i = 1; i < 21; i++)
            {
                IXLRow row = worksheet.Row(i);
                for (int j = 1; j < 21; j++)
                {
                    string str = worksheet.Row(i).Cell(j).GetString();
                    if (String.IsNullOrEmpty(str)) continue;
                    if (str != userDataToSearch) continue;
                    user.Login = worksheet.Row(i).RowBelow().Cell(j + 1).GetString();
                    user.Password = worksheet.Row(i).RowBelow().Cell(j + 2).GetString();
                    return user;
                }
            }
            return null;
        }
#endif

    }

    public class UserData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "Login: " + this.Login + " Password: " + this.Password;
        }
    }
}
