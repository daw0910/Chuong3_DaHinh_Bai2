using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuong3_DaHinh_Bai2
{
        class SanPham
    {
        private string _ten;
        private double _giamua;
        public SanPham () { }
        public SanPham(string ten, double giamua)
        {
            this._ten = ten;
            this._giamua = giamua;
        }
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public double GiaMua
        {
            get { return _giamua; }
            set
            {
                if (value >= 0)
                    _giamua = value;
            }
        }      
        public virtual double TinhGiaBan()
        {
            return 0;
        }
        public virtual string InChiTiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.Write("Cho biết tên sản phẩm: ");
            _ten = Console.ReadLine();
            Console.Write("Cho biết giá bán: ");
            _giamua =double.Parse(Console.ReadLine());
        }
    }
    class Socola : SanPham
    {
        private double _loinhuan;
        public Socola() : base() { }
        public Socola (string ten, double giamua): base(ten, giamua) { _loinhuan = GiaMua * 0.2; }
        public override double TinhGiaBan()
        {
            return GiaMua +_loinhuan;
        }
        public override string InChiTiet()
        {
            return string.Format("Tên: {0} -Giá bán:{1: #,##0}", Ten, TinhGiaBan());

        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = GiaMua * 0.2;
        }
    }
    class NuocUong : SanPham
    {
        private double _loinhuan;
        private double _chiphigiulanh;
        public NuocUong(): base () { }
        public NuocUong(string ten,double giamua): base (ten,giamua)
        {
            _loinhuan = GiaMua * 0.15;
            _chiphigiulanh = GiaMua * 0.1;
        }
        public override double TinhGiaBan()
        {
            return GiaMua +_loinhuan+_chiphigiulanh;
        }
        public override string InChiTiet()
        {
            return string.Format("Tên: {0} - Giá Bán: {1: #,##0}",Ten,TinhGiaBan());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = GiaMua * 0.15;
            _chiphigiulanh = GiaMua * 0.1;
        }
    }
    class QuanLySanPham
    {
        private string _ten;
        private SanPham[] dssp;
        private int n;
        public QuanLySanPham()
        {
            _ten = "Cửa hàng bán lẻ";
            dssp = new SanPham[100];
            n = 0;
        }
        public QuanLySanPham (int size)
        {
            _ten = "Cửa hàng bán lẻ";
            dssp = new SanPham[size];
                n = 0;
        }
        public void Nhap()
        {
            int chon;
            string hoilai;
            SanPham sp;
            while (true)
            {
                Console.Write("Bạn muốn chọn sản phẩm loại nào: (1.Socola -2.Nước uống): ");
                chon = int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case 1:
                        sp = new Socola();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                    case 2:
                        sp = new NuocUong();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                }
                Console.Write("Bạn có muốn tiếp tục không? (Y/N):");
                hoilai = Console.ReadLine();
                if (hoilai.ToLower().Equals("n"))
                    break;
            }    
        }
        public void InDanhSachSP()
        {
            Console.WriteLine("--------------------Cửa Hàng Bán Lẻ--------------------------");
            for ( int i =0; i<n; i++)
            {
                Console.WriteLine(dssp[i].InChiTiet());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLySanPham q1 = new QuanLySanPham();
            q1.Nhap();
            q1.InDanhSachSP();
            Console.ReadLine();
        }
    }
}
