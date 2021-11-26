using Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.Admin.Models
{
    public class DonViRepository
    {
        private readonly string connectionString = @"Data Source=DESKTOP-A9M4EN4\SQLSERVER;Initial Catalog=HTQLVB;Integrated Security=True";

        void SetParameter(IDbCommand command, Parameter parameter)
        {
            IDbDataParameter dataParameter = command.CreateParameter();
            dataParameter.ParameterName = parameter.Name;
            dataParameter.Value = parameter.Value;
            dataParameter.DbType = parameter.DbType;
            if (Enum.IsDefined(typeof(ParameterDirection), parameter.Direction))
            {
                dataParameter.Direction = parameter.Direction;
            }
            command.Parameters.Add(dataParameter);
        }

        void SetParameter(IDbCommand command, Parameter[] parameters)
        {
            foreach (var item in parameters)
            {
                SetParameter(command, item);
            }
        }


        public string GetNhanVienByDonVi(decimal id)
        {
            Parameter parameter = new Parameter { Name = "@IdDonVi", Value = id, DbType = DbType.Decimal };
            List<string> r = new List<string>();
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVienByDonVi";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameter);
                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Add((string)reader["HO_TEN"]);
                    }
                    return String.Join(",", r);
                }
            }
        }

    }
}
