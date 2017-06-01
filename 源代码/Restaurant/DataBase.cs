using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Restaurant
{
    class DataBase
    {
        public DataBase()
        {
            sqlConnection = new SqlConnection();
            sqlCommand = null;
            sqlDataReader = null;
            sqlDataAdapter = null;
            dataSet = null;
        }
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet;

        public void SQLUpdate(string sql)
        {
            SetConnection();
            SetUpdate(sql);
        }
        public SqlDataReader SQLQueryDataReader(string sql)
        {
            SetConnection();
            SetQueryDataReader(sql);
            return sqlDataReader;
        }
        public DataSet SQLQueryDataSet(string sql)
        {
            SetConnection();
            SetQueryDataSet(sql);
            return dataSet;
        }
        public void Close()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void SetConnection()
        {
            try
            {
                sqlConnection = new SqlConnection("server=.;database=Restaurant;uid=sa;pwd=sa");
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        private void SetUpdate(string sql)
        {
            try
            {
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        private void SetQueryDataReader(string sql)
        {
            try
            {
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        private void SetQueryDataSet(string sql)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }
}
