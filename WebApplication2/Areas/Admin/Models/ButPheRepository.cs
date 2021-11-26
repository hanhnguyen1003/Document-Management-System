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
    public class ButPheRepository
    {
        private string connectionString = @"Data Source=DESKTOP-A9M4EN4\SQLSERVER;Initial Catalog=HTQLVB;Integrated Security=True";
        public int AddButPhe(BUTPHE obj,string trangthaixuly)
        {
            Parameter[] parameters =
            {
                new Parameter{Name="@ID_BUT_PHE",Value=obj.ID_BUT_PHE,DbType=DbType.Decimal},
                new Parameter{Name="@ID_VAN_BAN",Value=obj.ID_VAN_BAN,DbType=DbType.Decimal},
                new Parameter{Name="@NOI_DUNG_BUT_PHE",Value=obj.NOI_DUNG_BUT_PHE,DbType=DbType.String},
                new Parameter{Name="@THOI_GIAN_BD",Value=obj.THOI_GIAN_BD,DbType=DbType.DateTime},
                new Parameter{Name="@THOI_GIAN_KT",Value=obj.THOI_GIAN_KT,DbType=DbType.DateTime},
                new Parameter{Name="@TRANG_THAI_XU_LY",Value=trangthaixuly,DbType=DbType.String}
            };
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AddButPhe";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        void SetParameter(IDbCommand command, Parameter parameter)
        {
            IDbDataParameter dataParameter = command.CreateParameter();
            dataParameter.ParameterName = parameter.Name;
            dataParameter.Value = parameter.Value;
            dataParameter.DbType = parameter.DbType;
            if (Enum.IsDefined(typeof(ParameterDirection),parameter.Direction))
            {
                dataParameter.Direction = parameter.Direction;
            }
            command.Parameters.Add(dataParameter);
        }
        void SetParameter(IDbCommand command,Parameter[] parameters)
        {
            foreach (var item in parameters)
            {
                SetParameter(command, item);
            }
        }


        public int AddNhanVien(NHANVIENBUTPHE obj)
        {
            Parameter[] parameters =
            {
                new Parameter{Name="@ID_BUT_PHE",Value=obj.ID_BUT_PHE,DbType=DbType.Decimal},
                new Parameter{Name="@ID_NHAN_VIEN",Value=obj.ID_NHAN_VIEN,DbType=DbType.Decimal}
               
            };
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AddNhanVien";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
           
        }
        public string GetNhanVienByIdButPhe(decimal id)
        {
            Parameter parameter = new Parameter { Name = "@IdButPhe", Value = id, DbType = DbType.Decimal };
            List<string> r = new List<string>();
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVienByIdButPhe";
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