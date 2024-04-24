import random
from datetime import datetime, timedelta

first_names = ["Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng"]
middle_names = ["Văn", "Thị", "Đăng", "Lê", "Hữu", "Bảo", "Minh", "Trung", "Ngọc", "Thuỳ"]
last_names = ["Anh", "Trang", "Phương", "Thu", "Huy", "Tùng", "Việt", "Nam", "Hoa", "Linh"]


MADONVI = ['VPK', 'HTTT', 'CNPM', 'KHMT', 'CTTT', 'TGMT', 'MMTVT']
DONVI = ['Văn phòng khoa', 'Bộ môn HTTT', 'Bộ môn CNPM', 'Bộ môn KHMT', 'Bộ môn CNTT', 'Bộ môn TGMT' , 'Bộ môn MMT và Viễn thông']
VAITRO = ['C##P_NVCOBAN', 'C##P_GIANGVIEN', 'C##P_GIAOVU']
VAITROTRUONG = ['C##P_TRUONGDONVI', 'C##P_TRUONGKHOA']
gender = ['Nam', 'Nữ']

TENHOCPHAN =  [
    #các môn học vpk
    'Nhập môn lập trình', 'Kỹ thuật lập trình', 'Cấu trúc dữ liệu và giải thuật', 'Lập trình hướng đối tượng', 'Cơ sở dữ liệu', 'Mạng máy tính', 
    #các môn httt
    'Cơ sở dữ liệu nâng cao', 'Phân tích thiết kế hệ thống thông tin', 'An toàn và bảo mật dữ liệu trong hệ thống thông tin','Hệ thống thông tin doanh nghiệp',
    'Hệ quản trị cơ sở dữ liệu','Quản trị cơ sở dữ liệu hiện đại'
    #các môn CNPM
    'Kiểm thử phần mềm', 'Phát triển game', 'Phát triển ứng dụng web', 'Thiết kế phần mềm', 'Kiến trúc phần mềm', 'Thiết kế giao diện', 'Lập trình Windows',
    #các môn học khmt
    'Nhập môn học máy', 'Nhận dạng', 'Nhập môn thiết kế và phân tích giải thuật', 'Các hệ cơ sở tri thức', 'Automata và ngôn ngữ hình thức', 'Khai thác dữ liệu và ứng dụng', 
    #các môn học CTTT
    'Khóa luận tốt nghiệp', 'Thực tập tốt nghiệp', 'Thực tập dự án tốt nghiệp', 'Chuyên đề tổ chức dữ liệu', 'Chuyên đề tkpm nâng cao', 'Đồ án phần mềm',
    #các môn học tgmt
    'Đồ họa máy tính', 'Thị giác máy tính', 'Xử lý ảnh số và video số', 'Phân tích thống kê dữ liệu nhiều biến', 'Đồ họa ứng dụng', 'Thị giác robot',
    #các môn học MMTVT
    'Hệ thống viễn thông', 'Lập trình mạng', 'mạng máy tính nâng cao', 'thực tập Mạng máy tính', 'An ninh máy tính', 'Thiết kế mạng'
]
MAHOCPHAN = [ 
    'NMLT', 'KTLP', 'CTDLGT', 'LTHDT', 'CSDL', 'MMT',
    'CSDLNC', 'PTTKHTTT', 'ATBMDLHTTT', 'HTTTDN', 'HQTCSDL', 'QTCSDLHD',
    'KTPM', 'PTG', 'PTUDW', 'TKPM', 'KTPM', 'TKGD', 
    'NMHM', 'ND', 'NMTKPTGT', 'CHCSTT', 'AUTOMATA', 'KTDLUD',
    'KLTN', 'TTTN', 'TTDATN', 'CDTCDL', 'CDTKPMNC', 'DAPM',
    'DHMT', 'TGMT', 'XLASVS', 'PTTKDLNB', 'DHUD', 'TGR',
    'HTVT', 'LTM', 'MMTNC', 'TTMMT', 'ANMT', 'TKM'
]

MACHUONGTRINH = ['CQ', 'CLC', 'CTTT', 'VP']
NAM = [2023, 2024]
HK = [1,2,3]

DIACHI = ['Hà Nội', 'Hồ Chí Minh','Khánh Hòa', 'Tiền Giang', 'Gia lai', 'Bạc Liêu', 'Cà mau' ]



sinhvien_size = 4000
nhansu_size = 100




def pick_random_elements(array):
    n = len(array)
    k = random.randint(1, n-1)  # Chọn số lượng phần tử ngẫu nhiên từ 1 đến n-1
    return random.sample(array, k)

def random_phone_num_generator():
    first = str(random.randint(100, 999))
    second = str(random.randint(1, 888)).zfill(3)
    last = (str(random.randint(1, 9998)).zfill(4))
    while last in ['1111', '2222', '3333', '4444', '5555', '6666', '7777', '8888']:
        last = (str(random.randint(1, 9998)).zfill(4))
    return '{}{}{}'.format(first, second, last)

def writefile(filename,sql_insert):
    with open(filename, 'w', encoding='utf-8') as f:
        f.write(sql_insert)

SQL_TRUONG_NHANSU_INSERT = ''
SQL_DONVI_INSERT = ''

nhansu = []
hocphan = []
donvi = []

for i in range (DONVI.__len__()):
    SQL_dv1 = '''INSERT INTO PROJECT_DONVI\n'''
    SQL_dv2 = 'VALUES ('

    SQL_truong_dv1 = '''INSERT INTO PROJECT_NHANSU\n'''
    SQL_truong_dv2 = 'VALUES ('


    manv = i + 1
    gioitinh = random.choice(gender)
    random_name = random.choice(first_names) + " " + random.choice(middle_names) + " " + random.choice(last_names)

    start_date = datetime(1950, 1, 1)
    end_date = datetime(2000, 12, 31)

    random_date = start_date + (end_date - start_date) * random.random()

    ngay_sinh = random_date.strftime("%Y-%m-%d")
    phucap = random.randint(100000, 1000000)

    phonenumber = random_phone_num_generator()
    madonvi = MADONVI[i]

    if MADONVI[i] == 'VPK':
        vaitro = VAITROTRUONG[1]
    else:
        vaitro = VAITROTRUONG[0]

    account = 'PROJECT_U_' + str(i+1)

    nhansu.append([manv, random_name, gioitinh, ngay_sinh, phucap, phonenumber, vaitro, madonvi, account])
    SQL_truong_dv2 += f'{manv}, \'{random_name}\', \'{gioitinh}\', to_date(\'{ngay_sinh}\',\'YYYY-MM-DD\'), {phucap}, \'{phonenumber}\', \'{vaitro}\', \'{madonvi}\', \'{account}\');\n'
    SQL_TRUONG_NHANSU_INSERT += SQL_truong_dv1 + SQL_truong_dv2

    SQL_dv2 += f'\'{madonvi}\', \'{DONVI[i]}\', null);\n'
    SQL_DONVI_INSERT += SQL_dv1 + SQL_dv2
    donvi.append([madonvi, DONVI[i], manv])

SQL_TRUONG_NHANSU_INSERT += '''\n\n'''
SQL_TRUONG_NHANSU_INSERT += '''UPDATE PROJECT_DONVI
SET TRGDV = 1
WHERE MADV = 'VPK';
UPDATE PROJECT_DONVI
SET TRGDV = 2
WHERE MADV = 'HTTT';
UPDATE PROJECT_DONVI
SET TRGDV = 3
WHERE MADV = 'CNPM';
UPDATE PROJECT_DONVI
SET TRGDV = 4
WHERE MADV = 'KHMT';
UPDATE PROJECT_DONVI
SET TRGDV = 5
WHERE MADV = 'CTTT';
UPDATE PROJECT_DONVI
SET TRGDV = 6
WHERE MADV = 'TGMT';
UPDATE PROJECT_DONVI
SET TRGDV = 7
WHERE MADV = 'MMTVT';
                                '''



SQL_NHANSU_INSERT = ''
for i in range (7, nhansu_size):
    SQL_ns1 = '''INSERT INTO PROJECT_NHANSU\n'''
    SQL_ns2 = 'VALUES ('

    manv = i + 1
    gioitinh = random.choice(gender)
    random_name = random.choice(first_names) + " " + random.choice(middle_names) + " " + random.choice(last_names)

    start_date = datetime(1950, 1, 1)
    end_date = datetime(2000, 12, 31)

    random_date = start_date + (end_date - start_date) * random.random()

    ngay_sinh = random_date.strftime("%Y-%m-%d")
    phucap = random.randint(100000, 1000000)

    phonenumber = random_phone_num_generator()
    vaitro = random.choice(VAITRO)
    madonvi = random.choice(MADONVI)

    if madonvi == 'VPK':
        vaitro = random.choice([VAITRO[2], VAITRO[0]])


    account = 'PROJECT_U_' + str(i+1)
    nhansu.append([manv, random_name, gioitinh, ngay_sinh, phucap, phonenumber, vaitro, madonvi, account])
    SQL_ns2 += f'{manv}, \'{random_name}\', \'{gioitinh}\', to_date(\'{ngay_sinh}\',\'YYYY-MM-DD\'), {phucap}, \'{phonenumber}\', \'{vaitro}\', \'{madonvi}\', \'{account}\');\n'
    SQL_NHANSU_INSERT += SQL_ns1 + SQL_ns2

SQL_HOCPHAN_INSERT = ''
for i in range (MAHOCPHAN.__len__()):
    SQL_hp1 = '''INSERT INTO PROJECT_HOCPHAN\n'''
    SQL_hp2 = 'VALUES ('

    mahp = MAHOCPHAN[i]
    tenhp = TENHOCPHAN[i]
    sotinchi = 4
    sotietthuchanh = 30
    sotietlythuyet = 45
    sosinhvientoida = 100
    madv = MADONVI[int(i/6)]

    hocphan.append([mahp, tenhp, sotinchi, sotietlythuyet, sotietthuchanh, sosinhvientoida, madv])
    SQL_hp2 += f'\'{mahp}\', \'{tenhp}\', {sotinchi}, {sotietlythuyet}, {sotietthuchanh}, {sosinhvientoida}, \'{madv}\');\n'
    SQL_HOCPHAN_INSERT += SQL_hp1 + SQL_hp2


SQL_KHMO_INSERT = ''
khmo = []
for i in range(hocphan.__len__()):


    mahp = hocphan[i][0]
    namhoc = 2024

    hocky = pick_random_elements(HK)
    chuongtrinh = pick_random_elements(MACHUONGTRINH)
    for j in range(hocky.__len__()):
        for k in range(chuongtrinh.__len__()):
            sql_khmo1 = '''INSERT INTO PROJECT_KHMO\n'''
            sql_khmo2 = 'VALUES ('
            sql_khmo2 += f'\'{mahp}\',{hocky[j]},  {namhoc}, \'{chuongtrinh[k]}\');\n'
            khmo.append([mahp, hocky[j], namhoc, chuongtrinh[k]])
    
            SQL_KHMO_INSERT += sql_khmo1 + sql_khmo2

    pass


slgiaovien = 0
for gv in nhansu:
    if gv[6] == 'C##P_GIANGVIEN' or gv[6] == 'C##P_TRUONGDONVI' or gv[6] == 'C##P_TRUONGKHOA':
        slgiaovien += 1
print('Số lượng giáo viên: ', slgiaovien)
soluongmonhocgiangday = int(khmo.__len__() / slgiaovien)
print('Số lượng môn học giảng dạy trung bình của 1 giáo viên: ', soluongmonhocgiangday)

SQL_PHANCONG_INSERT = ''
phancong = []
for i in range(nhansu.__len__()):
    if nhansu[i][6] == 'C##P_GIANGVIEN' or nhansu[i][6] == 'C##P_TRUONGDONVI' or nhansu[i][6] == 'C##P_TRUONGKHOA':
        
        manv = nhansu[i][0]
        for j in range(soluongmonhocgiangday):
            sql_pc1 = '''INSERT INTO PROJECT_PHANCONG\n'''
            sql_pc2 = 'VALUES ('
            phancong_khmo = khmo[i + j]
            sql_pc2 += f'{manv}, \'{phancong_khmo[0]}\',{phancong_khmo[1]},{phancong_khmo[2]},\'{phancong_khmo[3]}\');\n'
            phancong.append([manv, phancong_khmo[0], phancong_khmo[1], phancong_khmo[2], phancong_khmo[3]])
            SQL_PHANCONG_INSERT += sql_pc1 + sql_pc2

SQL_SINHVIEN_INSERT = ''
sinhvien = []
for i in range(sinhvien_size):
    SQL_sv1 = '''INSERT INTO PROJECT_SINHVIEN\n'''
    SQL_sv2 = 'VALUES ('

    mssv = i + 1
    gioitinh = random.choice(gender)
    random_name = random.choice(first_names) + " " + random.choice(middle_names) + " " + random.choice(last_names)

    start_date = datetime(2002, 1, 1)
    end_date = datetime(2006, 12, 31)
    delta = end_date - start_date
    random_days = random.randint(0, delta.days)
    ngay_sinh = (start_date + timedelta(days=random_days)).date()
    
    diachi = random.choice(DIACHI)
    sdt = random_phone_num_generator()
    mact = random.choice(MACHUONGTRINH)
    manganh = random.choice(MADONVI[1:6])
    SQL_sv2 += f'{mssv}, \'{random_name}\', \'{gioitinh}\', to_date(\'{ngay_sinh}\',\'YYYY-MM-DD\'), \'{diachi}\', \'{sdt}\', \'{mact}\', \'{manganh}\', null, null);\n'
    sinhvien.append([mssv, random_name, gioitinh, ngay_sinh, diachi, sdt, mact, manganh])
    SQL_SINHVIEN_INSERT += SQL_sv1 + SQL_sv2

SQL_DANGKY_INSERT = ''
dangky = []
for i in range(sinhvien_size):
    mssv = i + 1
    diemtbtl = 0
    sotctl = 0
    list_phancong = []

    for j in range(3):
        sql_dk1 = '''INSERT INTO PROJECT_DANGKY\n'''
        sql_dk2 = 'VALUES ('



        while True:
            sv_phancong = random.choice(phancong)
            if sv_phancong not in list_phancong:
                list_phancong.append(sv_phancong)
                break
   


        
        diemthi = random.randint(0, 10)
        diemqt = random.randint(0, 10)
        diemck = random.randint(0, 10)
        diemtk = 0.6 * diemthi + 0.1 * diemqt + 0.3 * diemck
        diemtbtl += diemtk
        if diemtk >= 5:
            sotctl += 4
        sql_dk2 +=  f'{mssv}, \'{sv_phancong[0]}\', \'{sv_phancong[1]}\', {sv_phancong[2]}, {sv_phancong[3]},\'{sv_phancong[4]}\',{diemthi}, {diemqt}, {diemck}, {diemtk});\n'
        dangky.append([mssv, sv_phancong[0], sv_phancong[1], sv_phancong[2], sv_phancong[3], sv_phancong[4], diemthi, diemqt, diemck, diemtk])
        SQL_DANGKY_INSERT += sql_dk1 + sql_dk2
    
    diemtbtl = diemtbtl / 3

    sql_updatediem1 = '''UPDATE PROJECT_SINHVIEN\n'''
    sql_updatediem2 = 'SET DTBTL = ' + str(diemtbtl) + ', SOTCTL = ' + str(sotctl) + '\n'
    sql_updatediem3 = 'WHERE MASV = ' + str(mssv) + ';\n'
    SQL_DANGKY_INSERT += sql_updatediem1 + sql_updatediem2 + sql_updatediem3




writefile('TRUONG_NHANSU_INSERT.sql', SQL_TRUONG_NHANSU_INSERT)
writefile('DONVI_INSERT.sql', SQL_DONVI_INSERT)
writefile('NHANSU_INSERT.sql', SQL_NHANSU_INSERT)
writefile('HOCPHAN_INSERT.sql', SQL_HOCPHAN_INSERT)
writefile('KHMO_INSERT.sql', SQL_KHMO_INSERT)
writefile('PHANCONG_INSERT.sql', SQL_PHANCONG_INSERT)
writefile('SINHVIEN_INSERT.sql', SQL_SINHVIEN_INSERT)
writefile('DANGKY_INSERT.sql', SQL_DANGKY_INSERT)

# SQL_sv1 = '''INSERT INTO PROJECT_SINHVIEN\n'''
# for i in range(size):
#     fullname = FullNameGenerator()
#     hoten = fullname.generate()
#     ngaysinh = datetime(1990, 1, 1) + timedelta(days=random.randint(0, 365*30))
#     gioitinh = random.choice
# SQL_sv2 = 'VALUES (' + 