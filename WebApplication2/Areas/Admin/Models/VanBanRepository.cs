using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.Admin.Models
{
    public class VanBanRepository
    {
        private string connectionString = @"Data Source=DESKTOP-A9M4EN4\SQLSERVER;Initial Catalog=HTQLVB;Integrated Security=True";
        public List<VanBanCreateDto> GetVANBAN()
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetVanBan";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<VanBanCreateDto> list = new List<VanBanCreateDto>();
                        while (reader.Read())
                        {
                            VanBanCreateDto obj = new VanBanCreateDto
                            {
                                ID_VAN_BAN = (decimal)reader["ID_VAN_BAN"],
                                ID_LOAI_VAN_BAN = (decimal)reader["ID_LOAI_VAN_BAN"],
                                ID_NOI_PHAT_HANH = (decimal)reader["ID_NOI_PHAT_HANH"],
                                SO_VAN_BAN = (string)reader["SO_VAN_BAN"],
                                NGAY_GOI = (DateTime)reader["NGAY_GOI"],
                                NGAY_NHAN = (DateTime)reader["NGAY_NHAN"],
                                NGAY_KY = (DateTime)reader["NGAY_KY"],
                                NGUOI_KY=(string)reader["NGUOI_KY"],
                                TRICH_YEU = (string)reader["TRICH_YEU"],
                                TRANG_THAI_XU_LY = (string)reader["TRANG_THAI_XU_LY"],
                                FILE_DINH_KEM = (string)reader["FILE_DINH_KEM"],
                                loaivanban = (string)reader["TEN_LOAI_VAN_BAN"],
                                noiphathanh = (string)reader["TEN_NOI_PHAT_HANH"]
                            };
                            list.Add(obj);

                        }
                        return list;
                    }
                }
            }
        }
            public int ChangeDanhSachDinhKem(decimal idvanban, string danhsachdinhkem)
            {
                Parameter[] parameters =
                {
                new Parameter{Name="@DanhSachDinhKem",Value=danhsachdinhkem,DbType=DbType.String},
                new Parameter{Name="@IdVanBan",Value=idvanban,DbType=DbType.Decimal},

            };
                using (DbConnection connection = new SqlConnection(connectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "ChangeDanhSachDinhKem";
                        command.CommandType = CommandType.StoredProcedure;
                        SetParameter(command, parameters);
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            public int Edit(VanBanCreateDto obj)
            {
                Parameter[] parameters =
                {
                new Parameter{Name="@IdVanBan",Value=obj.ID_VAN_BAN,DbType=DbType.Decimal},
                new Parameter{Name="@IdLoaiVanBan",Value=obj.ID_LOAI_VAN_BAN,DbType=DbType.Decimal},
                new Parameter{Name="@IdNoiPhatHanh",Value=obj.ID_NOI_PHAT_HANH,DbType=DbType.Decimal},
                new Parameter{Name="@SoVanBan",Value=obj.SO_VAN_BAN,DbType=DbType.String},
                new Parameter{Name="@TrichYeu",Value=obj.TRICH_YEU,DbType=DbType.String},
                new Parameter{Name="@NgayKy",Value=obj.NGAY_KY,DbType=DbType.DateTime},
                new Parameter{Name="@NgayGoi",Value=obj.NGAY_GOI,DbType=DbType.DateTime},
                new Parameter{Name="@NgayNhan",Value=obj.NGAY_NHAN,DbType=DbType.DateTime},
                new Parameter{Name="@NguoiKy",Value=obj.NGUOI_KY,DbType=DbType.String},
                new Parameter{Name="@TrangThai",Value=obj.TRANG_THAI_XU_LY,DbType=DbType.String},
                new Parameter{Name="@FileDinhKem",Value=obj.FILE_DINH_KEM,DbType=DbType.String}
            };
                using (DbConnection connection = new SqlConnection(connectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "EditVanBan";
                        command.CommandType = CommandType.StoredProcedure;
                        SetParameter(command, parameters);
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            public int ChangeStatusVanBan(decimal idvanban, string trangthai)
            {
                Parameter[] parameters =
                {
                new Parameter{Name="@TrangThaiXuLy",Value=trangthai,DbType=DbType.String},
                new Parameter{Name="@IdVanBan",Value=idvanban,DbType=DbType.Decimal},

            };
                using (DbConnection connection = new SqlConnection(connectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "ChangeStatusVanBan";
                        command.CommandType = CommandType.StoredProcedure;
                        SetParameter(command, parameters);
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            public int DeleteVanBan(decimal idvanban)
            {
                Parameter parameter = new Parameter { Name = "@IdVanBan", Value = idvanban, DbType = DbType.Decimal };


                using (DbConnection connection = new SqlConnection(connectionString))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DeleteVanBan";
                        command.CommandType = CommandType.StoredProcedure;
                        SetParameter(command, parameter);
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