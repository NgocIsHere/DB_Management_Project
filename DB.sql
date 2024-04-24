-- tạo user từ connection của root------------------------------------------------------

--alter session set "_oracle_script" = true;
--CREATE USER C##ADMIN IDENTIFIED BY 123; 
--GRANT DBA TO C##ADMIN;
--GRANT EXECUTE ANY PROCEDURE TO C##ADMIN;
----CẤP QUYỀN TRÊN TOÀN BỘ CONTAINER
--GRANT CREATE SESSION TO C##ADMIN CONTAINER = ALL; 

--kết nối sang user vừa tạo với chế default-----------------------------------------------
alter session set "_oracle_script" = true;

CREATE TABLE PROJECT_NHANSU
(
    MANV VARCHAR(3),
    HOTEN NVARCHAR2(50),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    PHUCAP INT,
    DT VARCHAR(10),
    VAITRO VARCHAR2(50),
    MADV VARCHAR(5),
    
    PRIMARY KEY(MANV)
);

CREATE TABLE PROJECT_SINHVIEN
(
    MASV VARCHAR(3),
    HOTEN NVARCHAR2(50),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    DCHI VARCHAR2(100),
    DT VARCHAR(10),
    MACT VARCHAR(5),
    MANGANH VARCHAR(5),
    SOTCTL INT,
    DTBTL FLOAT,
    
    PRIMARY KEY(MASV)
);
CREATE TABLE PROJECT_DONVI
(
    MADV VARCHAR(5),
    TENDV VARCHAR2(50),
    TRGDV VARCHAR(3),
    PRIMARY KEY(MADV)
);

CREATE TABLE PROJECT_HOCPHAN
(
    MAHP VARCHAR(10),
    TENHP VARCHAR2(50),
    SOTC INT,
    SSLT INT,
    STTH INT, 
    SOSVTD INT,
    MADV VARCHAR(5),
    
    PRIMARY KEY(MAHP)
);

CREATE TABLE PROJECT_KHMO
(
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(5),
    PRIMARY KEY(MAHP, HK,NAM,MACT)
);

CREATE TABLE PROJECT_PHANCONG
(
    MAGV VARCHAR(3),
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(5),
    
    PRIMARY KEY(MAGV,MAHP,HK,NAM,MACT)
);
CREATE TABLE PROJECT_DANGKY
(
    MASV VARCHAR(3),
    MAGV VARCHAR(3),
    MAHP VARCHAR(10),
    HK INT, 
    NAM INT,
    MACT VARCHAR(5),
    DIEMTHI FLOAT,
    DIEMQT FLOAT,
    DIEMCK FLOAT,
    DIEMTK FLOAT,
    
    PRIMARY KEY(MASV,MAGV,MAHP,HK,NAM,MACT)
);


ALTER TABLE PROJECT_NHANSU
ADD
    CONSTRAINT FK_NS_DV
    FOREIGN KEY (MADV)
    REFERENCES PROJECT_DONVI;

ALTER TABLE PROJECT_DONVI
ADD
    CONSTRAINT FK_DV_NS
    FOREIGN KEY (TRGDV)
    REFERENCES PROJECT_NHANSU;
    
ALTER TABLE PROJECT_HOCPHAN
ADD
    CONSTRAINT FK_HP_DV
    FOREIGN KEY (MADV)
    REFERENCES PROJECT_DONVI;
    
ALTER TABLE PROJECT_KHMO
ADD
    CONSTRAINT FK_KHMO_HP
    FOREIGN KEY (MAHP)
    REFERENCES PROJECT_HOCPHAN;
    
ALTER TABLE PROJECT_PHANCONG
ADD
    CONSTRAINT FK_PC_NS
    FOREIGN KEY (MAGV)
    REFERENCES PROJECT_NHANSU;

ALTER TABLE PROJECT_PHANCONG
ADD
    CONSTRAINT FK_PC_KHMO
    FOREIGN KEY (MAHP,HK,NAM,MACT)
    REFERENCES PROJECT_KHMO;  

ALTER TABLE PROJECT_DANGKY
ADD
    CONSTRAINT FK_DK_SV
    FOREIGN KEY (MASV)
    REFERENCES PROJECT_SINHVIEN;

ALTER TABLE PROJECT_DANGKY
ADD
    CONSTRAINT FK_DK_PC
    FOREIGN KEY (MAGV,MAHP,HK,NAM,MACT)
    REFERENCES PROJECT_PHANCONG;    

 

CREATE ROLE C##P_NVCOBAN;
CREATE ROLE C##P_GIANGVIEN;
CREATE ROLE C##P_GIAOVU;
CREATE ROLE C##P_TRUONGDONVI;
CREATE ROLE C##P_TRUONGKHOA;
CREATE ROLE C##P_SINHVIEN;
--DROP ROLE C##P_NVCOBAN

--XEM ROLE ĐÃ TẠO
SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'C##P_%';
--XEM QUYỀN TRÊN TABLE CỦA ROLE
SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE 'C##P_%';
--XEM DANH SÁCH MEMBER CỦA ROLE
SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE 'C##P_%'; 



ALTER TABLE PROJECT_NHANSU
ADD
    USERNAME VARCHAR(100)

ALTER TABLE PROJECT_SINHVIEN
MODIFY (MASV VARCHAR2(10));
ALTER TABLE PROJECT_DANGKY
MODIFY (MASV VARCHAR2(10));




