using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.Admin.Models
{
    public class AppRepository
    {
        NhanVienRepository nhanvien;
        VanBanRepository vanban;
        ButPheRepository butphe;
        DonViRepository donvi;
        VanBanDAO vanBanDAO;
        DonViDAO donViDAO;
        NhanVienDAO nhanVienDAO;
        LoaiVanBanDAO loaiVanBanDAO;

        NoiPhatHanhDAO noiPhatHanhDAO;

        public NoiPhatHanhDAO NoiPhatHanhDAO
        {
            get
            {
                if (noiPhatHanhDAO is null)
                {
                    noiPhatHanhDAO = new NoiPhatHanhDAO();

                }
                return noiPhatHanhDAO;
            }
        }
        public LoaiVanBanDAO LoaiVanBanDAO
        {
            get
            {
                if (loaiVanBanDAO is null)
                {
                    loaiVanBanDAO = new LoaiVanBanDAO();
                    
                }
                return loaiVanBanDAO;
            }
        }
        public NhanVienDAO NhanVienDAO
        {
            get
            {
                if (nhanVienDAO is null)
                {
                    nhanVienDAO = new NhanVienDAO();
                }
                return nhanVienDAO;
            }
        }
        public DonViDAO DonViDAO
        {
            get
            {
                if (donViDAO is null)
                {
                    donViDAO = new DonViDAO();
                }
                return donViDAO;
            }
        }
        public VanBanDAO VanBanDAO
        {
            get
            {
                if (vanBanDAO is null)
                {
                    vanBanDAO = new VanBanDAO();
                }
                return vanBanDAO;
            }
        }
        public DonViRepository DonVi
        {
            get
            {
                if (donvi is null)
                {
                    donvi = new DonViRepository();
                }
                return donvi;
            }
        }
        public ButPheRepository ButPhe
        {
            get
            {
                if (butphe is null)
                {
                    butphe = new ButPheRepository();
                }
                return butphe;
            }
        }
        public VanBanRepository VanBan
        {
            get
            {
                if (vanban is null)
                {
                    vanban = new VanBanRepository();
                }
                return vanban;
            }
        }
        public NhanVienRepository NhanVien
        {
            get
            {
                if (nhanvien is null)
                {
                    nhanvien = new NhanVienRepository();
                }
                return nhanvien;
            }
        }
    }
}