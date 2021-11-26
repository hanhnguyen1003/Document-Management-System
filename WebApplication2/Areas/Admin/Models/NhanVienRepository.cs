using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Models
{
    public class NhanVienRepository
    {
        private readonly string connectionString = @"Data Source=DESKTOP-A9M4EN4\SQLSERVER;Initial Catalog=HTQLVB;Integrated Security=True";

        public List<NHANVIEN> GetNhanVien()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVien";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<NHANVIEN> list = new List<NHANVIEN>();
                    while (reader.Read())
                    {
                        NHANVIEN obj = new NHANVIEN
                        {
                            ID_NHAN_VIEN = (decimal)reader["ID_NHAN_VIEN"],
                            HO_TEN = (string)reader["HO_TEN"]
                        };
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }

        public List<NHANVIEN> GetNhanVienAllExceptNhanVienVanBan(decimal idvanban)
        {
            Parameter parameter = new Parameter
            {
                Name = "@IdVanBan",
                Value = idvanban,
                DbType = DbType.Decimal
            };
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVienAllExceptNhanVienVanBan";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameter);
                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<NHANVIEN> list = new List<NHANVIEN>();
                    while (reader.Read())
                    {
                        NHANVIEN obj = new NHANVIEN
                        {
                            ID_NHAN_VIEN = (decimal)reader["ID_NHAN_VIEN"],
                            HO_TEN = (string)reader["HO_TEN"]
                        };
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
        public List<NHANVIEN> GetNhanVienByVanBan(decimal idvanban)
        {
            Parameter parameter = new Parameter
            {
                Name = "@IdVanBan",
                Value = idvanban,
                DbType = DbType.Decimal
            };
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVienByVanBan";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameter);
                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<NHANVIEN> list = new List<NHANVIEN>();
                    while (reader.Read())
                    {
                        NHANVIEN obj = new NHANVIEN
                        {
                            ID_NHAN_VIEN = (decimal)reader["ID_NHAN_VIEN"],
                            HO_TEN = (string)reader["HO_TEN"]
                        };
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
        public List<NHANVIEN> GetNhanVien1(decimal iddonvi)
        {
            Parameter parameter = new Parameter
            {
                Name = "@IdDonVi",
                Value = iddonvi,
                DbType = DbType.Decimal
            };
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetNhanVienByDonVi";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, parameter);
                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<NHANVIEN> list = new List<NHANVIEN>();
                    while (reader.Read())
                    {
                        NHANVIEN obj = new NHANVIEN
                        {
                            ID_NHAN_VIEN = (decimal)reader["ID_NHAN_VIEN"],
                            HO_TEN = (string)reader["HO_TEN"]
                        };
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
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
    }
}