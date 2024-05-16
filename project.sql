-- tạo user từ connection của root------------------------------------------------------
--alter session set "_oracle_script" = true;
--CREATE USER C##ADMIN IDENTIFIED BY 123; 
--GRANT DBA TO C##ADMIN;
--GRANT EXECUTE ANY PROCEDURE TO C##ADMIN;
----CẤP QUYỀN TRÊN TOÀN BỘ CONTAINER
--GRANT CREATE SESSION TO C##ADMIN CONTAINER = ALL; 

--kết nối sang user vừa tạo với chế default-----------------------------------------------
alter session set "_oracle_script" = true;


CREATE TABLE Project_NHANSU
(
    MANV VARCHAR(10),
    HOTEN NVARCHAR2(100),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    PHUCAP INT,
    DT VARCHAR(10),
    VAITRO VARCHAR2(100),
    MADV VARCHAR(10),
    
    PRIMARY KEY(MANV)
);

CREATE TABLE Project_SINHVIEN
(
    MASV VARCHAR(10),
    HOTEN NVARCHAR2(100),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    DCHI VARCHAR2(100),
    DT VARCHAR(10),
    MACT VARCHAR(10),
    MANGANH VARCHAR(10),
    SOTCTL INT,
    DTBTL FLOAT,
    
    PRIMARY KEY(MASV)
);
CREATE TABLE Project_DONVI
(
    MADV VARCHAR(10),
    TENDV VARCHAR2(100),
    TRGDV VARCHAR(10),
    PRIMARY KEY(MADV)
);

CREATE TABLE Project_HOCPHAN
(
    MAHP VARCHAR(10),
    TENHP VARCHAR2(100),
    SOTC INT,
    SSLT INT,
    STTH INT, 
    SOSVTD INT,
    MADV VARCHAR(10),
    
    PRIMARY KEY(MAHP)
);

CREATE TABLE Project_KHMO
(
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(10),
    PRIMARY KEY(MAHP, HK,NAM,MACT)
);

CREATE TABLE Project_PHANCONG
(
    MAGV VARCHAR(10),
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(10),
    
    PRIMARY KEY(MAGV,MAHP,HK,NAM,MACT)
);
CREATE TABLE Project_DANGKY
(
    MASV VARCHAR(10),
    MAGV VARCHAR(10),
    MAHP VARCHAR(10),
    HK INT, 
    NAM INT,
    MACT VARCHAR(10),
    DIEMTHI FLOAT,
    DIEMQT FLOAT,
    DIEMCK FLOAT,
    DIEMTK FLOAT,
    
    PRIMARY KEY(MASV,MAGV,MAHP,HK,NAM,MACT)
);

ALTER TABLE Project_NHANSU
ADD
    CONSTRAINT FK_NS_DV
    FOREIGN KEY (MADV)
    REFERENCES Project_DONVI;

ALTER TABLE Project_DONVI
ADD
    CONSTRAINT FK_DV_NS
    FOREIGN KEY (TRGDV)
    REFERENCES Project_NHANSU;
    
ALTER TABLE Project_HOCPHAN
ADD
    CONSTRAINT FK_HP_DV
    FOREIGN KEY (MADV)
    REFERENCES Project_DONVI;
    
ALTER TABLE Project_KHMO
ADD
    CONSTRAINT FK_KHMO_HP
    FOREIGN KEY (MAHP)
    REFERENCES Project_HOCPHAN;
    
ALTER TABLE Project_PHANCONG
ADD
    CONSTRAINT FK_PC_NS
    FOREIGN KEY (MAGV)
    REFERENCES Project_NHANSU;

ALTER TABLE Project_PHANCONG
ADD
    CONSTRAINT FK_PC_KHMO
    FOREIGN KEY (MAHP,HK,NAM,MACT)
    REFERENCES Project_KHMO;  

ALTER TABLE Project_DANGKY
ADD
    CONSTRAINT FK_DK_SV
    FOREIGN KEY (MASV)
    REFERENCES Project_SINHVIEN;

ALTER TABLE Project_DANGKY
ADD
    CONSTRAINT FK_DK_PC
    FOREIGN KEY (MAGV,MAHP,HK,NAM,MACT)
    REFERENCES Project_PHANCONG;    



CREATE ROLE C##P_NVCOBAN;
CREATE ROLE C##P_GIANGVIEN;
CREATE ROLE C##P_GIAOVU;
CREATE ROLE C##P_TRUONGDONVI;
CREATE ROLE C##P_TRUONGKHOA;
CREATE ROLE C##P_SINHVIEN;

--====================================================================
select*from project_nhansu;
SELECT* FROM PROJECT_DONVI;
SELECT*FROM PROJECT_HOCPHAN;


CREATE USER PROJECT_U_2 IDENTIFIED BY 123;
GRANT CONNECT TO PROJECT_U_2;
GRANT C##P_TRUONGDONVI TO PROJECT_U_2;
CREATE USER PROJECT_U_13 IDENTIFIED BY 123;
GRANT CONNECT TO PROJECT_U_13;
GRANT C##P_GIAOVU TO PROJECT_U_13;
CREATE USER PROJECT_U_10 IDENTIFIED BY 123;
GRANT CONNECT TO PROJECT_U_10;
GRANT C##P_GIANGVIEN TO PROJECT_U_10;
SELECT* FROM PROJECT_NHANSU;
--=============================================================================
--XEM ROLE ĐÃ TẠO
SELECT * FROM DBA_ROLES WHERE ROLE LIKE 'C##P_%';
--XEM QUYỀN TRÊN TABLE CỦA ROLE
SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE 'C##P%';
--XEM DANH SÁCH MEMBER CỦA ROLE
SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE 'C##P_%'; 

select table_name from all_tables where table_name like 'PROJECT_%';
SELECT *
FROM ALL_VIEWS
WHERE VIEW_NAME LIKE 'PROJECT_%'

SELECT * FROM USER_SYS_PRIVS; 
SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE LIKE 'PROJECT_U_%';
SELECT * FROM USER_ROLE_PRIVS;



select * from all_tables where table_name like 'PROJECT_%'

SELECT * FROM USER_TAB_COLUMNS WHERE TABLE_NAME = 'PROJECT_S_TEST_DANGKY'
select*from project_phancong where magv = '11'
--=============================================================
--CS1
CREATE OR REPLACE VIEW PROJECT_NVCOBAN_XEMTHONGTINCANHAN
AS SELECT *
FROM PROJECT_NHANSU
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER');

CREATE OR REPLACE VIEW PROJECT_NVCOBAN_UPDATESDT
AS SELECT DT
FROM PROJECT_NHANSU
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER');

CREATE OR REPLACE PROCEDURE PROJECT_CAIDAT_CS1 AS
    STRSQL VARCHAR2(2000);
BEGIN
    STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_NVCOBAN_XEMTHONGTINCANHAN TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT UPDATE ON PROJECT_NVCOBAN_UPDATESDT TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    
    STRSQL := 'GRANT SELECT ON PROJECT_SINHVIEN TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_DONVI TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_HOCPHAN TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_KHMO TO C##P_NVCOBAN';
    EXECUTE IMMEDIATE STRSQL;
    
    --STRSQL := 'GRANT CONNECT, CREATE SESSION TO C##P_NVCOBAN';
    --EXECUTE IMMEDIATE STRSQL;   
END;
/
EXEC PROJECT_CAIDAT_CS1;
/
--CS2
CREATE OR REPLACE VIEW PROJECT_GIANGVIEN_XEMPHANCONGCANHAN
AS SELECT PC.MAGV, PC.MAHP, PC.HK, PC.NAM, PC.MACT
FROM PROJECT_NHANSU NS JOIN PROJECT_PHANCONG PC ON NS.MANV = PC.MAGV
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER');

CREATE OR REPLACE VIEW PROJECT_GIANGVIEN_XEMDANGKYDCPC
AS SELECT DK.*
FROM PROJECT_NHANSU NS JOIN PROJECT_DANGKY DK ON DK.MAGV = NS.MANV
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER'); 

--CREATE OR REPLACE VIEW PROJECT_GIANGVIEN_CAPNHATDIEM_DANGKY
--AS SELECT DK.MASV,DK.DIEMTHI, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
--FROM PROJECT_NHANSU NS JOIN PROJECT_DANGKY DK ON DK.MAGV = NS.MANV
--WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER'); 

CREATE OR REPLACE PROCEDURE PROJECT_CAIDAT_CS2 AS
    STRSQL VARCHAR2(2000);
BEGIN
    STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT C##P_NVCOBAN TO C##P_GIANGVIEN WITH ADMIN OPTION';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_GIANGVIEN_XEMPHANCONGCANHAN TO C##P_GIANGVIEN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT ON PROJECT_GIANGVIEN_XEMDANGKYDCPC TO C##P_GIANGVIEN';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT SELECT, UPDATE(DIEMTHI, DIEMQT, DIEMCK, DIEMTK) ON PROJECT_GIANGVIEN_XEMDANGKYDCPC TO C##P_GIANGVIEN';
    EXECUTE IMMEDIATE STRSQL;

    --STRSQL := 'GRANT CONNECT TO C##P_GIANGVIEN';
    --EXECUTE IMMEDIATE STRSQL;
    
END;
/
EXEC PROJECT_CAIDAT_CS2;
/
--CS3

CREATE OR REPLACE VIEW GIAOVU_PHANCONG AS
SELECT * FROM PROJECT_PHANCONG
WHERE MAHP IN (SELECT MAHP FROM PROJECT_HOCPHAN WHERE MADV = (SELECT MADV FROM PROJECT_DONVI WHERE TENDV = 'Văn phòng khoa'));

CREATE OR REPLACE VIEW GIAOVU_DANGKY AS
SELECT * FROM PROJECT_DANGKY
WHERE TRUNC(SYSDATE) BETWEEN (SELECT TRUNC(ADD_MONTHS(TO_DATE('01-01-' || NAM, 'DD-MM-YYYY'), (HK - 1) * 4)) FROM PROJECT_KHMO WHERE MAHP = PROJECT_DANGKY.MAHP AND HK = PROJECT_DANGKY.HK AND NAM = PROJECT_DANGKY.NAM)
AND (SELECT TRUNC(ADD_MONTHS(TO_DATE('01-01-' || NAM, 'DD-MM-YYYY'), (HK - 1) * 4) + 14) FROM PROJECT_KHMO WHERE MAHP = PROJECT_DANGKY.MAHP AND HK = PROJECT_DANGKY.HK AND NAM = PROJECT_DANGKY.NAM);

CREATE OR REPLACE PROCEDURE GRANT_ROLE_GIAOVU AS
BEGIN
    -- Grant C##P_NVCOBAN role to C##P_GIAOVU
    EXECUTE IMMEDIATE 'GRANT C##P_NVCOBAN TO C##P_GIAOVU';

    -- Grant select, insert, update on SINHVIEN, DONVI, HOCPHAN, KHMO to C##P_GIAOVU
    EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE ON PROJECT_SINHVIEN TO C##P_GIAOVU';
    EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE ON PROJECT_DONVI TO C##P_GIAOVU';
    EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE ON PROJECT_HOCPHAN TO C##P_GIAOVU';
    EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE ON PROJECT_KHMO TO C##P_GIAOVU';

    -- Grant select on PHANCONG to C##P_GIAOVU
    EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_PHANCONG TO C##P_GIAOVU';
    EXECUTE IMMEDIATE 'GRANT SELECT,UPDATE ON GIAOVU_PHANCONG TO C##P_GIAOVU';

    -- Grant delete, insert on DANGKY to C##P_GIAOVU
    EXECUTE IMMEDIATE 'GRANT DELETE, INSERT ON PROJECT_DANGKY TO C##P_GIAOVU';
END;
/
EXEC GRANT_ROLE_GIAOVU
/
--CS4
CREATE OR REPLACE VIEW PROJECT_V1_TRUONGDONVI_PHANCONG
AS 
    SELECT* FROM PROJECT_PHANCONG PC
    WHERE EXISTS (SELECT HP.MAHP 
    FROM PROJECT_HOCPHAN HP JOIN PROJECT_DONVI DV ON HP.MADV = DV.MADV
    JOIN PROJECT_NHANSU NS2 ON DV.TRGDV = NS2.MANV
    WHERE HP.MAHP = PC.MAHP AND NS2.USERNAME = SYS_CONTEXT('USERENV','SESSION_USER'));
/
CREATE OR REPLACE VIEW PROJECT_V2_TRUONGDONVI_PHANCONG
AS
    SELECT* FROM PROJECT_PHANCONG PC
    WHERE EXISTS(SELECT NS.MANV FROM PROJECT_NHANSU NS
    JOIN PROJECT_DONVI DV ON NS.MADV = DV.MADV 
    JOIN PROJECT_NHANSU NS2 ON DV.TRGDV = NS2.MANV
    WHERE NS.MANV = PC.MAGV AND NS2.USERNAME = SYS_CONTEXT('USERENV','SESSION_USER'));
/
CREATE OR REPLACE TRIGGER PHANCONG_BEFORE_DELETE
BEFORE DELETE
   ON PROJECT_PHANCONG 
   FOR EACH ROW
   
BEGIN
    DELETE FROM PROJECT_DANGKY
    WHERE MAGV = :OLD.MAGV AND MAHP = :OLD.MAHP AND HK = :OLD.HK AND NAM = :OLD.NAM AND MACT = :OLD.MACT;

END;
/
CREATE OR REPLACE PROCEDURE PROJECT_CS#4
AS
    BEGIN
        EXECUTE IMMEDIATE 'GRANT C##P_GIANGVIEN TO C##P_TRUONGDONVI';
        EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, DELETE, UPDATE ON PROJECT_V1_TRUONGDONVI_PHANCONG TO C##P_TRUONGDONVI';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_V2_TRUONGDONVI_PHANCONG TO C##P_TRUONGDONVI';
    END;
/
EXEC PROJECT_CS#4;
/
--CS5
CREATE OR REPLACE VIEW PROJECT_V1_TRUONGKHOA_PHANCONG
AS
    SELECT* FROM PROJECT_PHANCONG PC
    WHERE EXISTS (SELECT HP.MAHP 
    FROM PROJECT_HOCPHAN HP JOIN PROJECT_DONVI DV ON HP.MADV = DV.MADV
    WHERE HP.MAHP = PC.MAHP AND DV.TENDV = N'Văn phòng khoa');
CREATE OR REPLACE PROCEDURE PROJECT_CS#5
AS
    BEGIN
        EXECUTE IMMEDIATE 'GRANT C##P_GIANGVIEN TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT, INSERT, UPDATE ON PROJECT_V1_TRUONGKHOA_PHANCONG TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT,INSERT,DELETE,UPDATE ON PROJECT_NHANSU TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_DANGKY TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_DONVI TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_HOCPHAN TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_KHMO TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_PHANCONG TO C##P_TRUONGKHOA';
        EXECUTE IMMEDIATE 'GRANT SELECT ON PROJECT_SINHVIEN TO C##P_TRUONGKHOA';
    END;
/
EXEC PROJECT_CS#5
--CS6
--SELECT* FROM PROJECT_PHANCONG WHERE MAGV = 23 AND MAHP = 'HTTTDN' AND HK = 3 AND NAM = 2024 AND MACT = 'CQ'
--
--select* from project_nhansu